namespace WindowsService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ServiceProcessInstallerName = new System.ServiceProcess.ServiceProcessInstaller();
            this.ServiceInstallerName = new System.ServiceProcess.ServiceInstaller();
            // 
            // ServiceProcessInstallerName
            // 
            this.ServiceProcessInstallerName.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.ServiceProcessInstallerName.Password = null;
            this.ServiceProcessInstallerName.Username = null;
            // 
            // ServiceInstallerName
            // 
            this.ServiceInstallerName.Description = "A我的服务Description......................";
            this.ServiceInstallerName.DisplayName = "A我的服务DisplayName.....................";
            this.ServiceInstallerName.ServiceName = "TestServiceName";
            this.ServiceInstallerName.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.ServiceProcessInstallerName,
            this.ServiceInstallerName});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller ServiceProcessInstallerName;
        protected System.ServiceProcess.ServiceInstaller ServiceInstallerName;
    }
}