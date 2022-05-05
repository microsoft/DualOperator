using System.Text.Json;
using DualOperator.Models;

namespace DualOperator.Helpers
{
    internal static class LoadOperator
    {
        public static List<RunningApp> OperatorApps = new List<RunningApp>();
        public static void LoadApps()
        {
            // First, get the config info
            List<OperatorApp>? appList = JsonSerializer.Deserialize<List<OperatorApp>>(File.ReadAllText("operators.json"));

            // Sanity check - did we get anything
            if (appList == null || appList.Count == 0)
            {
                return;
            }

            // Process the first item
            RunningApp appItem = new RunningApp
            {
                Keyboard = appList[0].Keyboard,
                WindowHandle = IntPtr.Zero,
                WindowTitle = appList[0].ApplicationTitle
            };
            OperatorApps.Add(appItem);

            // And now the second item
            if (appList.Count <= 1)
            {
                return;
            }

            appItem = new RunningApp
            {
                Keyboard = appList[1].Keyboard,
                WindowHandle = IntPtr.Zero,
                WindowTitle = appList[1].ApplicationTitle
            };
            OperatorApps.Add(appItem);
        }
    }
}
