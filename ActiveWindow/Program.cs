using System.Windows.Automation;

namespace ActiveWindows
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Automation.AddAutomationFocusChangedEventHandler(OnFocusChanged);

            Console.ReadLine();
            Automation.RemoveAllEventHandlers();
        }

        private static AutomationElement? _lastWindow;
        private static void OnFocusChanged(object sender, AutomationFocusChangedEventArgs e)
        {
            AutomationElement? elementFocused = sender as AutomationElement;
            if (elementFocused == null)
                return;

            try
            {
                AutomationElement? topLevelWindow = GetParentWindow(elementFocused);
                if (topLevelWindow == null)
                    return;

                if (topLevelWindow != _lastWindow)
                {
                    _lastWindow = topLevelWindow;
                    Console.WriteLine("Focus moved to window: {0}", topLevelWindow.Current.Name);
                }
            }
            catch (ElementNotAvailableException)
            {
            }
        }

        private static AutomationElement? GetParentWindow(AutomationElement element)
        {
            AutomationElement node = element;
            try
            {
                while (!Equals(node.Current.ControlType, ControlType.Window))
                {
                    node = TreeWalker.ControlViewWalker.GetParent(node);
                    if (node == null)
                        return null;
                }

                return node;
            }
            catch (ElementNotAvailableException)
            {
            }

            return null;
        }
    }
}
