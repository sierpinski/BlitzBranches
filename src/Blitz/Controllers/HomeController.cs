using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Blitz.Data;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Blitz.Controllers
{
    public class HomeController : Controller
    {
        public string BaseUrl;
        public string Project;
        public async Task<IActionResult> Index()
        {
            const string BaseTFSAddress = "https://domain.com/tfs";
            const string Project = "projectName";
            try
            {
                var authHandler = new HttpClientHandler {Credentials = CredentialCache.DefaultNetworkCredentials};
                var httpClient = new HttpClient(authHandler);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Add("Accept","application/json");
                var response = await httpClient.GetStringAsync($"{BaseTFSAddress}/{Project}/_apis/git/repositories?api=1.0");
                var responseObject = JsonConvert.DeserializeObject<Response<IEnumerable<Repository>>>(response);
                var repos = responseObject.value.ToList();
                Debug.WriteLine($"Repos Total: {responseObject.count}");
                var count = 0;
                var pullRequests = new List<PullRequest>();
                Parallel.ForEach(repos, (repo) =>
                {
                    try
                    {
                        Debug.WriteLine($"Open Pull Requests: {count}");
                        var pullResponse =
                            httpClient.GetStringAsync(
                                    $"{BaseTFSAddress}/{Project}/_apis/git/repositories/{repo.id}/pullrequests?api-version=1.0").Result;
                        var pullResponseObject =
                            JsonConvert.DeserializeObject<Response<IEnumerable<PullRequest>>>(pullResponse);
                        if (pullResponseObject.count == 0) return;
                        count += pullResponseObject.count;
                        Parallel.ForEach(pullResponseObject.value, (pull) =>
                        {
                            try
                            {
                                var getPull =
                                    httpClient.GetStringAsync(
                                            $"{BaseTFSAddress}/{Project}/_apis/git/repositories/{pull.repository.id}/pullrequests?api-version=1.0").Result;
                                var pObj = JObject.Parse(getPull).SelectToken("value").ToString();
                                var getPullObj = JsonConvert.DeserializeObject<PullRequest[]>(pObj);
                                foreach (var p in getPullObj)
                                {
                                    p.repository = repo;
                                    p.remoteUrl = p.repository.remoteUrl + "/" +
                                                  $"pullrequest/{p.pullRequestId}#view=discussion";
                                }
                                pullRequests.AddRange(getPullObj);
                            }
                            catch (Exception exception)
                            {
                                Debug.WriteLine(exception.Message);
                            }
                        });
                    }
                    catch (Exception exception)
                    {
                        Debug.WriteLine(exception.Message);
                    }
                });
                var viewModel = new Response<IEnumerable<PullRequest>> {count = count, value = pullRequests};
                httpClient.Dispose();
                return View(viewModel);
            }
            catch (Exception exception)
            {
                var a = exception;
                return View();
            }
        }

        public IActionResult Error()
        {
            return View();
        }
        public IEnumerable<TContent> DownloadContentFromUrls<TContent>(IEnumerable<string> urls)
        {
            var queue = new ConcurrentQueue<TContent>();

            using (var client = new HttpClient())
            {
                Task.WaitAll(urls.Select(url =>
                {
                    return client.GetAsync(url).ContinueWith(response =>
                    {
                        var content = JsonConvert.DeserializeObject<IEnumerable<TContent>>(response.Result.Content.ReadAsStringAsync().Result);

                        foreach (var c in content)
                            queue.Enqueue(c);
                    });
                }).ToArray());
            }

            return queue;
        }

    }

}
