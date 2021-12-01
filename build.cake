#addin "nuget:?package=Cake.Unity&version=0.8.0"


var target = Argument("target", "Build-Windows");

Task("Clean")
    .Does(() =>
{
    CleanDirectory($"./artifacts");
});
using static Cake.Unity.Arguments.BuildTarget;

Task("Build-Windows")
    .IsDependentOn("Clean")
    .Does(() =>
{
    UnityEditor(2022, 1, new UnityEditorArguments
    { 
        BatchMode = true ,
        Quit = true,
        ExecuteMethod = "Editor.CI.Builder.BuildWindows",
        BuildTarget = Windows,
        LogFile = "./artifacts/unity.log"
    }, 
    new UnityEditorSettings 
    { 
        RealTimeLog = true
    }
    );
});


RunTarget(target);