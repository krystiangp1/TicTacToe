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
using System.Data.OleDb;

namespace projekt
{
    /// <summary>
    /// Statystyki
    /// </summary>
    public partial class Statystyki : Window
    {
        private OleDbConnection connection = new OleDbConnection();
        public Statystyki()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Projekt\Baza_kolko_krzyzyk.accdb;
Persist Security Info=False;"; // odwolanie do lokalnej bazy danych
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        /// <summary>
        /// Pobranie danych z bazy do statystyki.
        /// </summary>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                connection.Open(); // otwarcie połączenia z bazą danych po kliknięciu w przycisk
                OleDbCommand command = new OleDbCommand(); //tworzymy zmienną lokalną command
                command.Connection = connection;
                string query = "SELECT Login,Wynik FROM Wyniki"; // odwolanie do sql, które dane ma wyświetlać
                command.CommandText = query; // odwołanie do źródła danych

            
                DataSet1 staty = new DataSet1();
                OleDbDataAdapter nowyad = new OleDbDataAdapter(command);
                nowyad.Fill(staty, "Wyniki");
                g_stat.ItemsSource = staty.Tables["Wyniki"].DefaultView;

                connection.Close(); //zamknięcie połączenia z bazą danych
         


            }



            catch (Exception ex) //wyświetla błędy
            {
                MessageBox.Show("Błąd połączenia z bazą" + ex); // komunikat wyswietlacjacy sie w razie bledu
            }
            
        }
       
    }
}
