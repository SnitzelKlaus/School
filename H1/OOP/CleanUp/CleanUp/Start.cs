using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanUp
{
    class Start
    {
        public void Program()
        {
            SystemInfo SystemInfo = new SystemInfo();
            UIGraphics uiGraphics = new UIGraphics();

            char userInput;

            while (true)
            {
                uiGraphics.Menu();
                userInput = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (userInput)
                {
                    case '1':
                        SystemInfo.GetUser();
                        break;
                    case '2':
                        SystemInfo.GetBootDevice();
                        break;
                    case '3':
                        SystemInfo.GetMemory();
                        break;
                    case '4':
                        SystemInfo.GetDiskMetadata();
                        break;
                    case '5':
                        SystemInfo.GetHardDiskSerialNumber();
                        break;
                    case '6':
                        SystemInfo.GetProcessor();
                        break;
                    case '7':
                        SystemInfo.ListAllServices();
                        break;
                    default:
                        Console.WriteLine("The option entered doesn't exist!");
                        break;
                }

                Console.ReadKey();
            }
        }
    }
}
