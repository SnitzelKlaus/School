using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace FileHelper
{
    public partial class FileHelper : ServiceBase
    {
        public FileHelper()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            System.IO.Directory.Move(@"C:\Users\Snitzel Klaus\Desktop\Test\Source", @"C:\Users\Snitzel Klaus\Desktop\Test\Destination");
        }

        protected override void OnStop()
        {
            System.IO.Directory.Delete(@"C:\Users\Snitzel Klaus\Desktop\Test");
        }
    }
}
