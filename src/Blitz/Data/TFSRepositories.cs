using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Blitz.Data
{
    public class Repository
    {
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public Project project { get; set; }
        public List<Commit> commits { get; set; }
        public string remoteUrl { get; set; }
    }

    public class Project
    {
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string state { get; set; }
    }

    public class Response<T>
    {
        public int count { get; set; }
        public T value { get; set; }
    }

    public class Commit
    {
        public string commitId { get; set; }
        public Person author { get; set; }
        public Person committer { get; set; }
        public string comment { get; set; }
        public ChangeCounts changecounts { get; set; }
    }

    public class Person
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string date { get; set; }
        public ChangeCounts churn { get; set; }
    }

    public class ChangeCounts
    {
        public int? Edit { get; set; }
        public int? Add { get; set; }
        public int? Delete { get; set; }
    }

    public class PullRequest
    {
        public Repository repository { get; set; }
        public int pullRequestId { get; set; }
        public string status { get; set; }
        public Createdby createdBy { get; set; }
        public DateTime creationDate { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string sourceRefName { get; set; }
        public string targetRefName { get; set; }
        public string mergeStatus { get; set; }
        public string mergeId { get; set; }
        public Lastmergesourcecommit lastMergeSourceCommit { get; set; }
        public Lastmergetargetcommit lastMergeTargetCommit { get; set; }
        public Lastmergecommit lastMergeCommit { get; set; }
        public Reviewer[] reviewers { get; set; }
        public string url { get; set; }
        public string remoteUrl { get; set; }
        public _Links _links { get; set; }
    }

    public class Createdby
    {
        public string id { get; set; }
        public string displayName { get; set; }
        public string uniqueName { get; set; }
        public string url { get; set; }
        public string imageUrl { get; set; }
    }

    public class Lastmergesourcecommit
    {
        public string commitId { get; set; }
        public string url { get; set; }
    }

    public class Lastmergetargetcommit
    {
        public string commitId { get; set; }
        public string url { get; set; }
    }

    public class Lastmergecommit
    {
        public string commitId { get; set; }
        public string url { get; set; }
    }

    public class _Links
    {
        public Self self { get; set; }
        public Repository1 repository { get; set; }
        public Workitems workItems { get; set; }
        public Sourcebranch sourceBranch { get; set; }
        public Targetbranch targetBranch { get; set; }
        public Sourcecommit sourceCommit { get; set; }
        public Targetcommit targetCommit { get; set; }
        public Createdby1 createdBy { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class Repository1
    {
        public string href { get; set; }
    }

    public class Workitems
    {
        public string href { get; set; }
    }

    public class Sourcebranch
    {
        public string href { get; set; }
    }

    public class Targetbranch
    {
        public string href { get; set; }
    }

    public class Sourcecommit
    {
        public string href { get; set; }
    }

    public class Targetcommit
    {
        public string href { get; set; }
    }

    public class Createdby1
    {
        public string href { get; set; }
    }

    public class Reviewer
    {
        public string reviewerUrl { get; set; }
        public int vote { get; set; }
        public Votedfor[] votedFor { get; set; }
        public string id { get; set; }
        public string displayName { get; set; }
        public string uniqueName { get; set; }
        public string url { get; set; }
        public string imageUrl { get; set; }
        public bool isContainer { get; set; }
    }

    public class Votedfor
    {
        public string reviewerUrl { get; set; }
        public int vote { get; set; }
        public string id { get; set; }
        public string displayName { get; set; }
        public string uniqueName { get; set; }
        public string url { get; set; }
        public string imageUrl { get; set; }
        public bool isContainer { get; set; }
    }
}
