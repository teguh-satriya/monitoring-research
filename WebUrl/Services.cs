using System.Diagnostics;
using UIAutomationClient;
using TreeScope = UIAutomationClient.TreeScope;

namespace WebUrl
{
    public static class ServiceListener 
    {
        public static string GetBrowserUrl(Process process)
        {
            string result = string.Empty;

            CUIAutomation _automation = new CUIAutomation();

            IUIAutomationElement elm = _automation.ElementFromHandle(process.MainWindowHandle);
            IUIAutomationCondition Cond = _automation.CreatePropertyCondition(30003, 50004);
            IUIAutomationElementArray elm2 = elm.FindAll(TreeScope.TreeScope_Descendants, Cond);
            for (int i = 0; i < elm2.Length; i++)
            {
                IUIAutomationElement elm3 = elm2.GetElement(i);
                IUIAutomationValuePattern val = (IUIAutomationValuePattern)elm3.GetCurrentPattern(10002);
                if (val.CurrentValue != "")
                {
                    return val.CurrentValue;
                }
            }

            return result;
        }
    }

    
}
