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
    /// Logika interakcji dla klasy Window3.xaml
    /// </summary>
    public partial class panel_log : Window
    {
        public string gracz { get ; private set;  }


        private OleDbConnection connection = new OleDbConnection();
        public panel_log()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Projekt\Baza_kolko_krzyzyk.accdb;
Persist Security Info=False;";  //to jest połączenie z bazą danych z lokalizacją na lokalnym dysku komputera
        }
        
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        /// <summary>
        /// Funkcja sprawdzajaca wpisanych danych z danymi znajdujacymi sie w bazie.
        /// </summary>
        private void b_zaloguj_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from Uzytkownicy where Login='" + txtb_login.Text + "' and Haslo='" + txtb_haslo.Password + "'";  // odwołanie do tabeli Uzytkownicy, kolumny Login i połączenie go z TextBoxem txt_login oraz do kolumny Haslo i połączenie z tekstboxem txt_password
            OleDbDataReader reader = command.ExecuteReader(); // tworzymy zmienną lokalną reader 
            int count = 0; // tworzę zmienną count równą 0(czli odzwierciedlenie wpisanego loginu i hasła);
            while (reader.Read()) // przy pomocy pętli while zwiększam wartość zmiennej count o 1(będzie to odzwierciedleniem indeksów w bazie, dzięki temu weryfikuje po kolei loginy i hasła wpisane do bazy);
            {
                count = count + 1;
                //count++;
                //
               
            }
            if (count == 1) // instrukcja if(jesli hasło jest poprawne i się pokrywa 1:1 to logowanie następuje i pojawia się komunikat. 
            {
                MessageBox.Show("Poprawny login i hasło");
           
                connection.Close(); // connection.Close zamyka połączenie z bazą danych po spełnieniu warunku
                connection.Dispose(); // baza dysponuje już takimi danymi, dlatego następuje logowanie
                this.Hide(); // zamyka okno
                konto_u wnd = new konto_u(txtb_login.Text); //zaczytywanie i przypisywanie loginu do okna Konto uzytkownika
             
                wnd.Show();
            
           
                reader.Close();
            }


            else // else czyli pozostałe przypadki, jeśli użytkownik wpisze niepoprawne wartości do textboxa loginu lub hasła wyrzuci komunikat o niepoprawnych danych
            {
                MessageBox.Show("Login lub hasło jest niepoprawne");
            }
          
            connection.Close();
            reader.Close();
        }

        private void powrot_Click(object sender, RoutedEventArgs e)
        {
            panel1  wnd = new panel1();
            wnd.Show();
            this.Close();
        }
    }
}
