using System.Diagnostics;
using System.Windows.Automation;

Process[] procsChrome = Process.GetProcessesByName("firefox");
foreach (Process chrome in procsChrome)
{
    if (chrome.MainWindowHandle == IntPtr.Zero)
    {
        continue;
    }

    AutomationElement elm = AutomationElement.FromHandle(chrome.MainWindowHandle);
    AutomationElement elmUrlBar = elm.FindFirst(TreeScope.Descendants,
      new PropertyCondition(AutomationElement.NameProperty, "Search or enter web address"));

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

Console.WriteLine("Enter to exit.");
Console.ReadLine();
