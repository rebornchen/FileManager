using System.Windows;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;


namespace CL.UI.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }

        //[STAThread]
        //public static void Main()
        //{
        //    App myApp = new App();
        //    myApp.ShutdownMode = ShutdownMode.OnExplicitShutdown;
        //    myApp.Run();
        //}
    }
}
