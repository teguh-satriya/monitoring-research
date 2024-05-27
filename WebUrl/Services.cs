using System.Diagnostics;

namespace WebUrl
{
    public static class Services
    {
        public static string GetURL(Process process)
        {
            if (process == null)
                throw new ArgumentNullException("process");

            if (process.MainWindowHandle == IntPtr.Zero)
                return null;

            //AutomationElement elm = AutomationElement.FromHandle(process.MainWindowHandle);
            //if (elm == null)
            //    return null;

            return string.Empty;
        }
    }
}
