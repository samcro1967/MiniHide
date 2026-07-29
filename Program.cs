using System.Threading;

namespace MiniHide
{
    internal static class Program
    {
        private static Mutex? mutex;

        [STAThread]
        static void Main()
        {
            const string mutexName = "MiniHide_SingleInstance";

            bool createdNew;

            mutex = new Mutex(true, mutexName, out createdNew);

            if (!createdNew)
            {
                MessageBox.Show(
                    "MiniHide is already running.\n\nUse the tray icon to access it.",
                    "MiniHide",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            // âœ… Enable WinForms exception handling
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // âœ… Hook global exception handlers
            Application.ThreadException += (sender, args) =>
            {
                HandleException(args.Exception);
            };

            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                if (args.ExceptionObject is Exception ex)
                {
                    HandleException(ex);
                }
            };

            ApplicationConfiguration.Initialize();

            try
            {
                Application.Run(new MiniHideContext());
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }

        // âœ… Crash logger
        private static void HandleException(Exception ex)
        {
            try
            {
                string folder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "MiniHide");

                Directory.CreateDirectory(folder);

                string file = Path.Combine(folder, "crash.log");

                string message =
                    $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]\n" +
                    $"Type: {ex.GetType().FullName}\n" +
                    $"Message: {ex.Message}\n" +
                    $"Stack:\n{ex.StackTrace}\n\n";

                File.AppendAllText(file, message);

                MessageBox.Show(
                    "MiniHide encountered an unexpected error and needs to close.\n\n" +
                    "A crash log has been saved to:\n\n" +
                    file + "\n\n" +
                    "Please open this file and share it for support.",
                    "MiniHide Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch
            {
                // Never crash while handling a crash
            }
        }
    }
}



