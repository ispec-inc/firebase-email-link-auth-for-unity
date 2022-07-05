using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;

namespace ispec.FirebaseEmailLinkAuth.Editor
{
    public static class IosBuildPostProcessor
    {
        [PostProcessBuild]
        public static void OnPostprocessBuild(
            BuildTarget target,
            string pathToBuiltProject
        )
        {
            if (target == BuildTarget.iOS)
            {
                OnPostprocessBuildIOS(pathToBuiltProject);
            }
        }

        private static void OnPostprocessBuildIOS(string pathToBuiltProject)
        {
            const string projectPath = "/Unity-iPhone.xcodeproj/project.pbxproj";
            const string targetName = "Unity-iPhone";
            const string entitlementsFileName = "my_app.entitlements";

            var entitlements = new ProjectCapabilityManager(
                pathToBuiltProject + projectPath,
                entitlementsFileName,
                targetName
            );

            entitlements.AddAssociatedDomains(
                new []
                {
                    $"applinks:{Config.GetValue().Domain}"
                }
            );
            entitlements.WriteToFile();
        }
    }
}
