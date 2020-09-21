using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrivateBusTabrizServices
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static int State =0;
        static void Main()
        {
            ClassLibrary.FilesAndFolder.JFolder.CreateAndSetPermissionFolder(ClassLibrary.JConfig.appPath + "\\CityBankFiles");
            ClassLibrary.FilesAndFolder.JFolder.CreateAndSetPermissionFolder(ClassLibrary.JConfig.appPath + "\\DataTableAvl");
            ClassLibrary.FilesAndFolder.JFolder.CreateAndSetPermissionFolder(ClassLibrary.JConfig.appPath + "\\DataTableAvl\\temp");
            ClassLibrary.FilesAndFolder.JFolder.CreateAndSetPermissionFolder(ClassLibrary.JConfig.appPath + "\\DataTableTicket");
            ClassLibrary.FilesAndFolder.JFolder.CreateAndSetPermissionFolder(ClassLibrary.JConfig.appPath + "\\DataTableTicket\\temp");
            ClassLibrary.FilesAndFolder.JFolder.CreateAndSetPermissionFolder(ClassLibrary.JConfig.appPath + "\\RTPISFile");

            if (State == 1)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new TestForm());
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
            {

                new PrivateBusTabrizServices()
            };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
