﻿using System;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PoleServerWithUI.ViewModel;

namespace PoleServerWithUI.View
{
    /// <summary>
    /// DeviceStateView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DeviceStateView : UserControl
    {
        DeviceStateViewModel deviceStateViewModel;

        public DeviceStateView()
        {
            InitializeComponent();

            deviceStateViewModel = new DeviceStateViewModel();
            this.DataContext = deviceStateViewModel;
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            deviceStateViewModel.UnLoaded();
        }

        private void ListBox_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.OriginalSource is ScrollViewer scrollViewer &&
                    Math.Abs(e.ExtentHeightChange) > 0.0)
            {
                scrollViewer.ScrollToBottom();
            }
        }
    }
}
