namespace PrivateBusTabrizServices
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PrivateBusTabrizServicesProvider = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstaller1 = new System.ServiceProcess.ServiceInstaller();
            // 
            // PrivateBusTabrizServicesProvider
            // 
            this.PrivateBusTabrizServicesProvider.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.PrivateBusTabrizServicesProvider.Password = null;
            this.PrivateBusTabrizServicesProvider.Username = null;
            // 
            // serviceInstaller1
            // 
            this.serviceInstaller1.ServiceName = "PrivateBusTabrizServices";
            this.serviceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceInstaller1,
            this.PrivateBusTabrizServicesProvider});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller PrivateBusTabrizServicesProvider;
        private System.ServiceProcess.ServiceInstaller serviceInstaller1;
    }
}