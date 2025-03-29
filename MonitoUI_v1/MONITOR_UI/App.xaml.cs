using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;


namespace MONITOR_UI
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Prism.Unity.PrismApplication
    {
        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            {
                string viewDir = viewType.FullName.Replace(".View.", ".View.");

                var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;

                string viewModelName = string.Empty;

                if (viewDir.EndsWith("Window") && viewDir.Length > 6)
                {
                    var viewName = viewDir.Substring(0, viewDir.Length - 6);

                    viewModelName = $"{viewName}Model, {viewAssemblyName}";
                }
                else
                {
                    var viewName = viewDir;

                    viewModelName = $"{viewName}Model, {viewAssemblyName}";
                }

                Debug.WriteLine("GetTypeViewmodel : " + viewModelName);
                return Type.GetType(viewModelName);
            });
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
            //return null;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<MainWindow>();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Process proc = Process.GetCurrentProcess();
            int count = Process.GetProcesses().Where(p =>
                             p.ProcessName == proc.ProcessName).Count();
            if (count > 1)
            {
                //AutoClosingMessageBox.Show("이미 실행중 입니다.", "Error", 10000);
                App.Current.Shutdown();
            }

            try
            {
                base.OnStartup(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("DLL 에러\n" + ex.Message);
                App.Current.Shutdown();
            }
        }
    }
}
