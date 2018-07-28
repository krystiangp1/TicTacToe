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
    /// konto uzytkownika
    /// </summary>
  
    public partial class konto_u : Window
   
    {
        /// <summary>
        /// połączenie z bazą danych
        /// </summary>
        private OleDbConnection connection = new OleDbConnection();
     


        /// <summary>
        /// konto_u pobranie z bazy nazwy zalogowanego uzytkownika i wyswietlenie.
        /// </summary>
        public konto_u(string user)
      
        {
            ///<summary>po zalogowaniu w panelu logowania w etykiecie zostaje wyświetlona nazwa użytkowanika</summary>
            InitializeComponent();
          
            nazwa_gracza_baza.Content = "Witaj "+ user+"!";
           
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\agaza\OneDrive\Desktop\Projekt\Baza_kolko_krzyzyk.accdb;
Persist Security Info=False;";
                     
        }
        
        /// <summary>
        /// metoda kliknięcia w przycisk przenosi nas do pola gry
        /// </summary>
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            pole_gry wnd = new pole_gry();
            wnd.Show();
            this.Close();
            
        }
   
    }
}
