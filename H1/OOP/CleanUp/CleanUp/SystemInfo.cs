using System;
using System.Management;

namespace CleanUp
{
    public class SystemInfo
    {
        public void GetUser()
        {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();
            foreach (ManagementObject result in results)
            {
                Console.WriteLine("User:\t{0}", result["RegisteredUser"]);
                Console.WriteLine("Org.:\t{0}", result["Organization"]);
                Console.WriteLine("O/S :\t{0}", result["Name"]);
            }
        }

        public void GetBootDevice()
        {
            Console.WriteLine("Getting :");
            ManagementScope scope = new ManagementScope("\\\\.\\ROOT\\cimv2");

            //create object query
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");

            //create object searcher
            ManagementObjectSearcher searcher =
                                    new ManagementObjectSearcher(scope, query);

            //get a collection of WMI objects
            ManagementObjectCollection queryCollection = searcher.Get();

            //enumerate the collection.
            foreach (ManagementObject m in queryCollection)
            {
                // access properties of the WMI object
                Console.WriteLine("BootDevice : {0}", m["BootDevice"]);

            }
        }

        public void GetMemory()
        {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();

            foreach (ManagementObject result in results)
            {
                Console.WriteLine("Total Visible Memory: {0}KB", result["TotalVisibleMemorySize"]);
                Console.WriteLine("Free Physical Memory: {0}KB", result["FreePhysicalMemory"]);
                Console.WriteLine("Total Virtual Memory: {0}KB", result["TotalVirtualMemorySize"]);
                Console.WriteLine("Free Virtual Memory: {0}KB", result["FreeVirtualMemory"]);
            }
        }

        public void GetDiskMetadata()
        {
            global::System.Management.ManagementScope managementScope = new global::System.Management.ManagementScope();
            global::System.Management.ObjectQuery objectQuery = new global::System.Management.ObjectQuery("select FreeSpace, Size, Name from Win32_LogicalDisk where DriveType=3");

            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();

            foreach (ManagementObject managementObject in managementObjectCollection)
            {
                Console.WriteLine("Disk Name : " + managementObject["Name"].ToString());
                Console.WriteLine("FreeSpace: " + managementObject["FreeSpace"].ToString());
                Console.WriteLine("Disk Size: " + managementObject["Size"].ToString());
                Console.WriteLine("---------------------------------------------------");
            }
        }

        public string GetHardDiskSerialNumber(string drive = "C")
        {
            ManagementObject managementObject = new ManagementObject("Win32_LogicalDisk.DeviceID=\"" + drive + ":\"");

            managementObject.Get();
            Console.WriteLine(managementObject["VolumeSerialNumber"].ToString());

            return managementObject["VolumeSerialNumber"].ToString();
        }

        public void GetProcessor()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfOS_Processor");
            foreach (ManagementObject obj in searcher.Get())
            {
                var usage = obj["PercentProcessorTime"];
                var name = obj["Name"];
                Console.WriteLine(name + " : " + usage);
                Console.WriteLine("CPU");
            }
        }

        public void ListAllServices()
        {
            Console.WriteLine("Process searching: ");
            ManagementObjectSearcher windowsServicesSearcher = new ManagementObjectSearcher("root\\cimv2", "select * from Win32_Service");
            ManagementObjectCollection objectCollection = windowsServicesSearcher.Get();

            Console.WriteLine("There are {0} Windows services: ", objectCollection.Count);

            foreach (ManagementObject windowsService in objectCollection)
            {
                PropertyDataCollection serviceProperties = windowsService.Properties;
                foreach (PropertyData serviceProperty in serviceProperties)
                {
                    if (serviceProperty.Value != null)
                    {
                        Console.WriteLine("Windows service property name: {0}", serviceProperty.Name);
                        Console.WriteLine("Windows service property value: {0}", serviceProperty.Value);
                    }
                }
                Console.WriteLine("---------------------------------------");
            }
        }
    }
}
