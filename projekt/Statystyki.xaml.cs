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
    /// statystyki
    /// </summary>
    public partial class Statystyki : Window
    {/// <summary>
     /// połączenie z bazą danych
     /// </summary>
        private OleDbConnection connection = new OleDbConnection();

        /// <summary>
        /// tutaj następuje inicjalizacja bazy danych oraz połączenie poprzez lokalne wskazanie ścieżki pliku
        /// </summary>

        public Statystyki()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\agaza\OneDrive\Desktop\Projekt\Baza_kolko_krzyzyk.accdb;
Persist Security Info=False;"; 
        }
        /// <summary>
        /// zdarzenie wyświetlające dane w komókach
        /// </summary>
        
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        /// <summary>
        ///metoda kliknięcia
        ///po kliknięciu w przycisk otwierane jest połączączenie z bazą danych(dokładnie poprzez odwołanie poprzez sql do tabeli przechowującej dane)
        ///w tabeli wyświetlane są wyniki wszystkich graczy
        ///w razie blędnego połączenia z bazą danych wyświetlany jest komunikat o problemach
        /// </summary>
        public void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                connection.Open(); 
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "SELECT Login,Wynik FROM Wyniki"; 
                command.CommandText = query; 

            
                DataSet1 staty = new DataSet1();
                OleDbDataAdapter nowyad = new OleDbDataAdapter(command);
                nowyad.Fill(staty, "Wyniki");
                g_stat.ItemsSource = staty.Tables["Wyniki"].DefaultView;

                connection.Close(); 
         
                }
            
            catch (Exception ex) 
            {
                MessageBox.Show("Błąd połączenia z bazą" + ex); 
            }
            
        }
       
    }
}
