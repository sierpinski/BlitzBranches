# Blitz
##What is it?
This extension puts all non-master git branches across all repositories in your project into a queue. This allows users to find lost or behind branches.

##Widget
It comes with a widget you can add to any hub screen. Here's how it looks:
![Widget Showing Active Pull Requests](https://sierpinski.gallery.vsassets.io/_apis/public/gallery/publisher/sierpinski/extension/blitz-allbranches/0.4.8/assetbyname/Microsoft.VisualStudio.Services.Screenshots.2 "Active Pull Requests Widget")

##Details
This is for VSTS (VSO, TFS 2015). This extension shows all of the non-master branches in a project. The approver can then follow a link to see that branch on its repository's "Branches" screen.

##Screenshot
Here is an example list of branches:
![Screenshot of Active Pull Requests](https://sierpinski.gallery.vsassets.io/_apis/public/gallery/publisher/sierpinski/extension/blitz-allbranches/0.4.8/assetbyname/Microsoft.VisualStudio.Services.Screenshots.1 "Screenshot/Active Pull Requests")

##Update 0.5.6
Improve branch name handling. (thanks Rob Pierce and tmadsen)

##Features On Release
* Widget, showing count of non-master branches across all repositories.
* Filter to only branches that you created.
* Shows how many commits the branch is ahead and behind.

##Why did I make it?
On [my pull request app](https://marketplace.visualstudio.com/items?itemName=sierpinski.blitz-allpulls-extension) Marcus Mobley asked in a comment if I would make this app, so here it is!

##Source Code and Issue Reporting
Here is the source: [GitHub repository](https://github.com/sierpinski/BlitzBranches). Please open issues with the extension there so I can track them more easily.

##Feature Ideas
Highlight branches which can be deleted or perhaps even offer a delete option with confirmation.