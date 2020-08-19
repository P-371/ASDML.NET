var target = Argument("target", "Build");
var configuration = Argument("configuration", "Release");

Task("Clean")
    .WithCriteria(c => HasArgument("rebuild"))
    .Does(() =>
{
    CleanDirectory($"./ASDML.NET/bin/{configuration}");
});

Task("Build")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetCoreBuild("./ASDML.NET.sln", new DotNetCoreBuildSettings
    {
        Configuration = configuration,
    });
});

RunTarget(target);
