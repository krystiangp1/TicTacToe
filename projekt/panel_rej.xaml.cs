using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.OleDb;
using System.Text;
namespace projekt
{
    /// <summary>
    /// Logika interakcji dla klasy Window2.xaml
    /// </summary>
    public partial class panel_rej : Window
    {
        public panel_rej()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            panel1 wnd1 = new panel1();
            wnd1.Show();
            this.Close();


        }
        private void Label_Content (object sender,EventArgs e )
        {         
        

        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\DemiX\Desktop\Baza_kolko_krzyzyk.accdb;
Persist Security Info=False;";  //to jest połączenie z bazą danych, dla testu chcę komunikat wyświetlić na labelu, ale mi nie działa
                connection.Open();
                Baza.Content = "Polaczenie poprawne"; // to powinno wyświetlać po zdebugowaniu 
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }
    }
}
