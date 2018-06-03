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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace projekt
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class panel1 : Window
    {
        public panel1()
        {
            InitializeComponent();
        }

        private void Przycisk1_Click(object sender, RoutedEventArgs e)
        {
            panel_rej wnd = new panel_rej();
          wnd.Show();
            this.Close();
        }

        private void Przycisk2_Click(object sender, RoutedEventArgs e)
        {
          panel_log wnd2 = new panel_log();
           wnd2.Show();
            this.Close();
        }
    }
}
