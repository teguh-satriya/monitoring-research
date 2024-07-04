using Microsoft.Win32;
using System.Management;

namespace SystemInfo 
{
    public class Program
    {
        public static void Main(string[] args)
        {
            getOperatingSystemInfo();
            getProcessorInfo();
            Console.ReadLine();
        }

        public static void getOperatingSystemInfo()
        {
            Console.WriteLine("Displaying operating system info....\n");

            ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
            foreach (ManagementObject managementObject in mos.Get())
            {
                if (managementObject["Caption"] != null)
                {
                    Console.WriteLine("Operating System Name  :  " + managementObject["Caption"].ToString()); 
                }
                if (managementObject["OSArchitecture"] != null)
                {
                    Console.WriteLine("Operating System Architecture  :  " + managementObject["OSArchitecture"].ToString());
                }
                if (managementObject["CSDVersion"] != null)
                {
                    Console.WriteLine("Operating System Service Pack   :  " + managementObject["CSDVersion"].ToString());
                }
            }
        }

        public static void getProcessorInfo()
        {
            Console.WriteLine("\n\nDisplaying HW Info....");
            RegistryKey processor_name = Registry.LocalMachine.OpenSubKey(@"Hardware\Description\System\CentralProcessor\0", RegistryKeyPermissionCheck.ReadSubTree);

            if (processor_name != null)
            {
                if (processor_name.GetValue("ProcessorNameString") != null)
                {
                    Console.WriteLine(processor_name.GetValue("ProcessorNameString"));
                }
            }

            var memoryInfo = GC.GetGCMemoryInfo();
           
            Console.WriteLine($"Total Memory: {memoryInfo.TotalAvailableMemoryBytes / (1024.0 * 1024.0)} MB");

            using (var searcher = new ManagementObjectSearcher("select * from Win32_VideoController"))
            {
                Console.WriteLine("\nDisplaying GPU Info....");
                foreach (ManagementObject obj in searcher.Get())
                {
                    Console.WriteLine("Name: " + obj["Name"]);
                    Console.WriteLine("Adapter RAM: " + obj["AdapterRAM"]);
                    Console.WriteLine("Driver Version: " + obj["DriverVersion"]);
                    Console.WriteLine("Video Processor: " + obj["VideoProcessor"]);
                    Console.WriteLine("Video Architecture: " + obj["VideoArchitecture"]);
                }
            }
        }
    }
}