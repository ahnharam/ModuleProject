using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PoleServerWithUI
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        NotifyIcon ni = new NotifyIcon();

        public MainWindow()
        {
            InitializeComponent();
            this.Hide();
            this.Visibility = Visibility.Collapsed;

            System.Windows.Forms.ContextMenu menu = new System.Windows.Forms.ContextMenu();    // Menu 객체

            System.Windows.Forms.MenuItem item1 = new System.Windows.Forms.MenuItem();    // Menu 객체에 들어갈 각각의 menu
            item1.Index = 0;
            item1.Text = "Show";    // menu 이름

            item1.Click += delegate (object click, EventArgs eClick)    // menu 의 클릭 이벤트 등록
            {
                this.Show();
                this.WindowState = WindowState.Normal;
                this.ShowInTaskbar = true;
            };
            System.Windows.Forms.MenuItem item2 = new System.Windows.Forms.MenuItem();    // menu 객체에 들어갈 각 menu
            item2.Index = 1;
            item2.Text = "Exit";    // menu 이름
            item2.Click += delegate (object click, EventArgs eClick)    // menu의 클릭 이벤트 등록
            {
                System.Windows.Application.Current.Shutdown();
            };


            menu.MenuItems.Add(item1);    // Menu 객체에 각각의 menu 등록
            menu.MenuItems.Add(item2);    // Menu 객체에 각각의 menu 등록

            ni.Icon = new System.Drawing.Icon("DB_Device.ico");    // 아이콘 등록 1번째 방법
            
            ni.Visible = true;
            ni.DoubleClick +=
               delegate (object sender, EventArgs args)
               {
                   this.Show();
                   this.WindowState = WindowState.Normal;
                   this.Visibility = Visibility.Visible;
                   this.Width = 800;
                   this.Height = 450;
                   this.ShowInTaskbar = true;
               };
            ni.ContextMenu = menu;    // Menu 객체 등록
            ni.Text = "Pole";    // Tray icon 이름
        }

        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                this.Hide();
                this.Visibility = Visibility.Collapsed;
                this.ShowInTaskbar = false;
            }

            base.OnStateChanged(e);
        }
    }
}
