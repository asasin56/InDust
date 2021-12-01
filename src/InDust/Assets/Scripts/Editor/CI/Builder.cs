using System;
using UnityEditor;
using UnityEditor.Build.Reporting;

namespace Editor.CI
{
   public static  class Builder
   {
      [MenuItem("Build/Windows")]
      public static void BuildWindows()
      {
         var report = BuildPipeline.BuildPlayer(new BuildPlayerOptions()
         {
            target = BuildTarget.StandaloneWindows, 
            locationPathName = "../../artifacts/Game.exe", 
            scenes = new [] {"Assets/Scenes/SampleScene.unity" }
         });
         if (report.summary.result != BuildResult.Succeeded)
            throw new Exception("Failed to build Windows package");
      }
   }
}
