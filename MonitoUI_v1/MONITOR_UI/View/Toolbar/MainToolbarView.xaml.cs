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
using System.Windows.Threading;

namespace MONITOR_UI.View
{
    /// <summary>
    /// MainToolbar.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainToolbarView : UserControl
    {
        public MainToolbarView()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        // 1초에 한번 Tick 이벤트 함수
        private void Timer_Tick(object sender, EventArgs e)
        {
            NowDateText.Text = DateTime.Now.ToString("yyyy.MM.dd");
            NowTimeText.Text = DateTime.Now.ToString("tt hh:mm", new System.Globalization.CultureInfo("en-US"));
        }
    }
}
