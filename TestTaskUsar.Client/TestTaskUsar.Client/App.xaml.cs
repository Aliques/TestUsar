using Microsoft.Extensions.DependencyInjection;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TestTaskUsar.Core.Interfaces.Serivces;
using TestTaskUsar.Core.Services;
using TestTaskUsar.ViewModels;

namespace TestTaskUsar.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public App()
        {
        }
        

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IHttpClientServiceImplementation>().To<HttpClientMessageCrudService>();
            kernel.Bind<IFileService>().To<JsonFileService>();
            kernel.Bind<IDialogService>().To<DefaultDialogService>();

            var mainVm = kernel.Get<MainViewModel>();

            MainWindow = new MainWindow();
            MainWindow.DataContext = mainVm;
            MainWindow.Show();
        }
    }
}
