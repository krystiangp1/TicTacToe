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
    /// Interaction logic for konto_u.xaml
    /// </summary>
  

    public partial class konto_u : Window///klasa publiczna konto_u
    {
    
        private OleDbConnection connection = new OleDbConnection();///prywatne połączenie z bazą danych


        /// <summary>
        /// Konto_u pobranie z bazy nazwy zalogowanego uzytkownika i wyswietlenie.
        /// </summary>
        public konto_u(string user) /// konstruktor z obiektem typu string
        {
           
            InitializeComponent();///inicjalizacja bazy
            nazwa_gracza_baza.Content = "Witaj "+ user+"!"; /// Powitanie użytkownika wyświetlenie nazwy zgodnie z uzytkownikiem, który się zalogował w panelu logowania
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Projekt\Baza_kolko_krzyzyk.accdb;
Persist Security Info=False;";  ///to jest połączenie z bazą danych z lokalizacją na lokalnym dysku komputera
          
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)///metoda do kliknięcia myszką na przycisk
        {
            pole_gry wnd = new pole_gry();///przeniesienie po wcisnięciu do okna pole gry
            wnd.Show();///otwarcie okna
            this.Close();///zamknięcie okna bieżącego
        }
    }
}
