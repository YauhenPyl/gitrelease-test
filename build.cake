#tool "nuget:?package=gitreleasemanager"
//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.
var buildDir = Directory("./src/Example/bin") + Directory(configuration);

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    Information("Clean");
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    Information("Restore-NuGet-Packages");
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    Information("Build");
});

Task("Run-Unit-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
    Information("Run-Unit-Test");
});

Task("Publish")
    .Does(() =>
{
    GitReleaseManagerCreate("Yauhen.Pyl@redknee.com", "RKPY$#145a", "YauhenPyl", "gitrelease-test",  new GitReleaseManagerCreateSettings {
        Name              = "0.1.0",
        InputFilePath     = "./README.txt",
        Prerelease        = true
    });
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Run-Unit-Tests");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
