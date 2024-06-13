using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using UIAutomationClient;

namespace Browser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Process[] procsChrome = Process.GetProcessesByName("firefox");
            foreach (Process chrome in procsChrome)
            {
                if (chrome.MainWindowHandle == IntPtr.Zero)
                {
                    continue;
                }

                AutomationElement elm = AutomationElement.FromHandle(chrome.MainWindowHandle);
                AutomationElement elmUrlBar = elm.FindFirst(TreeScope.Descendants,
                  new PropertyCondition(AutomationElement.NameProperty, "Address and search bar"));

                if (elmUrlBar != null)
                {
                    AutomationPattern[] patterns = elmUrlBar.GetSupportedPatterns();
                    if (patterns.Length > 0)
                    {
                        ValuePattern val = (ValuePattern)elmUrlBar.GetCurrentPattern(patterns[0]);
                        Console.WriteLine("Chrome URL found: " + val.Current.Value);
                    }
                }
            }
            */
        }
    }
}
