using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Blackboard_Notification_Service
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            BorderTopNotification.Visibility = Visibility.Collapsed;
            GridBottomNotification.Visibility = Visibility.Collapsed;

            string title = "无启动参数";
            string subtitle = "无启动参数";
            double showTime = 2;
            bool isTopNotification = true;

            if (App.StartArgs != null)
            {
                try
                {
                    title = App.StartArgs[0].ToString();

                    subtitle = App.StartArgs[1].ToString();

                    if (App.StartArgs.Contains("-t"))
                    {
                        showTime = Convert.ToDouble(App.StartArgs[Array.IndexOf(App.StartArgs, "-t") + 1]);
                    }

                    if (App.StartArgs.Contains("-bottom")) isTopNotification = false;
                }
                catch { }
            }

            TextBlockTitle.Text = title;
            TextBlockSubtitle.Text = subtitle;



            if (isTopNotification)
            {
                BorderTopNotification.Margin = new Thickness(0, -150, 0, 0);
                BorderTopNotification.Visibility = Visibility.Visible;
                StartTopAppearAnimation();
            }
            else GridBottomNotification.Visibility = Visibility.Visible;

            DelayExit(showTime);
        }

        private async void DelayExit(double delayTime)
        {
            await Task.Delay(TimeSpan.FromSeconds(delayTime + 0.75));
            StartTopDisappearAnimation();

            await Task.Delay(TimeSpan.FromSeconds(0.75));
            Application.Current.Dispatcher.Invoke(() =>
            {
                Application.Current.Shutdown(); // 关闭应用程序
            });
        }

        private void StartTopAppearAnimation()
        {
            var appearAnimation = new ThicknessAnimation()
            {
                From = new Thickness(0, -150, 0, 0),
                To = new Thickness(0),
                Duration = new Duration(TimeSpan.FromMilliseconds(750)),
                EasingFunction = new ExponentialEase() { EasingMode = EasingMode.EaseOut, Exponent = 4 }
            };

            var opacityAnimation = new DoubleAnimation()
            {
                From = 0.75,
                To = 1,
                Duration = new Duration(TimeSpan.FromMilliseconds(750)),
                EasingFunction = new ExponentialEase() { EasingMode = EasingMode.EaseOut, Exponent = 4 }
            };

            BorderTopNotification.BeginAnimation(OpacityProperty, opacityAnimation);
            BorderTopNotification.BeginAnimation(MarginProperty, appearAnimation);
        }

        private void StartTopDisappearAnimation()
        {
            var disappearAnimation = new ThicknessAnimation()
            {
                From = new Thickness(0),
                To = new Thickness(0, -150, 0, 0),
                Duration = new Duration(TimeSpan.FromMilliseconds(750)),
                EasingFunction = new ExponentialEase() { EasingMode = EasingMode.EaseIn, Exponent = 4 }
            };

            var opacityAnimation = new DoubleAnimation()
            {
                From = 1,
                To = 0.75,
                Duration = new Duration(TimeSpan.FromMilliseconds(750)),
                EasingFunction = new ExponentialEase() { EasingMode = EasingMode.EaseIn, Exponent = 4 }
            };

            BorderTopNotification.BeginAnimation(OpacityProperty, opacityAnimation);
            BorderTopNotification.BeginAnimation(MarginProperty, disappearAnimation);
        }
    }
}
