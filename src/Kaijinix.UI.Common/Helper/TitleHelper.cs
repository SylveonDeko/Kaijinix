using Kaijinix.HLE.Loaders.Processes;
using System;

namespace Kaijinix.UI.Common.Helper
{
    public static class TitleHelper
    {
        public static string ActiveApplicationTitle(ProcessResult activeProcess, string applicationVersion, string pauseString = "")
        {
            if (activeProcess == null)
            {
                return String.Empty;
            }

            string titleNameSection = string.IsNullOrWhiteSpace(activeProcess.Name) ? string.Empty : $" {activeProcess.Name}";
            string titleVersionSection = string.IsNullOrWhiteSpace(activeProcess.DisplayVersion) ? string.Empty : $" v{activeProcess.DisplayVersion}";
            string titleIdSection = $" ({activeProcess.ProgramIdText.ToUpper()})";
            string titleArchSection = activeProcess.Is64Bit ? " (64-bit)" : " (32-bit)";

            string appTitle = $"Kaijinix {applicationVersion} -{titleNameSection}{titleVersionSection}{titleIdSection}{titleArchSection}";

            if (!string.IsNullOrEmpty(pauseString))
            {
                appTitle += $" ({pauseString})";
            }

            return appTitle;
        }
    }
}
