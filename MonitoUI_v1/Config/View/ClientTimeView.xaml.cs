using System.Diagnostics;
using System.Windows.Controls;

namespace Config.View
{
    /// <summary>
    /// Interaction logic for SmsSettingView
    /// </summary>
    public partial class ClientTimeView : UserControl
    {
        private const int _time = 50;

        public ClientTimeView()
        {
            InitializeComponent();
        }

        private void Grid_Initialized(object sender, System.EventArgs e)
        {
            if(sender is Grid)
            {
                Debug.WriteLine("Grid_Initialized");
                Grid grid = sender as Grid;

                for(int i = 0; i < _time; i++)
                {
                    grid.ColumnDefinitions.Add(new ColumnDefinition());
                }
            }
        }
    }
}
