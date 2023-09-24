using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Blackboard_Notification_Service
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public static string[] StartArgs = null;

        protected override void OnStartup(StartupEventArgs e)
        {
            StartArgs = e.Args;  // 保存启动参数

            base.OnStartup(e);
        }
    }
}
