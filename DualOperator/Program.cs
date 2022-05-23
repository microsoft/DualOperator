using System.Text;
using DualOperator.Helpers;

namespace DualOperator
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Prepare to run
            ApplicationConfiguration.Initialize();

            // Check for command line arguments
            if (args.Length > 0)
            {
                switch (args[0].ToUpper())
                {
                    case "/LIST":
                        // If we received a file name, use that
                        Win32.DeviceAudit(args.Length > 1 ? args[1] : @"DeviceAudit.txt");
                        break;

                    case "/SCAN":
                        Application.Run(new ScanOperator());
                        break;

                    default:
                        StringBuilder message = new StringBuilder();
                        message.AppendLine(@"DualOperator takes up to 2 parameters:");
                        message.AppendLine(@"Parameter 1 is /LIST to produce a list of HID devices on the current machine.");
                        message.AppendLine(@"Parameter 2 is optional and is the full path and file name for the HID output list.");
                        message.AppendLine(@"If you do not specify a file name, DeviceAudit.txt will be created in the current directory.");
                        message.AppendLine(@"Click the OK button to exit.");
                        MessageBox.Show(message.ToString(), @"Dual Operator", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        break;
                }

                // And then get out
                return;
            }
            
            // Load the configuration file if it exists
            if (File.Exists("operators.json"))
            {
                LoadOperator.LoadApps();
            }

            // Launch the application
            Application.Run(new OperatorManager());
        }
    }
}
