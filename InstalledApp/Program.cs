using Microsoft.Win32;
using System.Globalization;

string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
{
    foreach (string subkey_name in key.GetSubKeyNames())
    {
        using (RegistryKey subkey = key.OpenSubKey(subkey_name))
        {
            if (subkey.GetValue("DisplayName") != null) 
            {
                DateTime? dt = null;
                if (subkey.GetValue("InstallDate") != null)
                {
                    dt = DateTime.ParseExact(subkey.GetValue("InstallDate").ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
                }

                string display = $"App : {subkey.GetValue("DisplayName")} | Version : {subkey.GetValue("DisplayVersion")} | Publisher : {subkey.GetValue("Publisher")} | Installed Date : {dt?.ToString("yyyy-MM-dd")}";

                Console.WriteLine(display);
            }
            
        }
    }
}

Console.WriteLine("Enter to exit.");
Console.ReadLine();
