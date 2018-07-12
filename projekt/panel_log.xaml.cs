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
    public partial class panel_log : Window///stworzenie publicznej klasy panel_logowania
    {
        public string gracz { get ; private set;  }/// <summary>
        /// 
        /// </summary>


        private OleDbConnection connection = new OleDbConnection();/// <summary>
        /// połączeie z bazą danych
        /// </summary>
        public panel_log()///metoda panel_logowania
        {
            InitializeComponent();///inicjalizacja komponentów(bazy)
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Projekt\Baza_kolko_krzyzyk.accdb;
Persist Security Info=False;";  //to jest połączenie z bazą danych z lokalizacją na lokalnym dysku komputera
        }
        
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)///metoda dotycząca textboxa
        {

        }
        /// <summary>
        /// Funkcja sprawdzajaca wpisanych danych z danymi znajdujacymi sie w bazie.
        /// </summary>
        private void b_zaloguj_Click(object sender, RoutedEventArgs e)///metoda zaloguj po kliknięciu
        {
            connection.Open();///otwarcie połączenia z bazą danych
            OleDbCommand command = new OleDbCommand();///nowe odwołanie do bazy
            command.Connection = connection;///obiekt połączenia
            command.CommandText = "select * from Uzytkownicy where Login='" + txtb_login.Text + "' and Haslo='" + txtb_haslo.Password + "'";  // odwołanie do tabeli Uzytkownicy, kolumny Login i połączenie go z TextBoxem txt_login oraz do kolumny Haslo i połączenie z tekstboxem txt_password
            OleDbDataReader reader = command.ExecuteReader(); /// tworzymy zmienną lokalną reader 
            int count = 0; /// tworzę zmienną count równą 0(czli odzwierciedlenie wpisanego loginu i hasła);
            while (reader.Read()) /// przy pomocy pętli while zwiększam wartość zmiennej count o 1(będzie to odzwierciedleniem indeksów w bazie, dzięki temu weryfikuje po kolei loginy i hasła wpisane do bazy);
            {
                count = count + 1;
                ///count++;
                //
               
            }
            if (count == 1) /// instrukcja if(jesli hasło jest poprawne i się pokrywa 1:1 to logowanie następuje i pojawia się komunikat. 
            {
                MessageBox.Show("Poprawny login i hasło");///komuikat
           
                connection.Close(); /// connection.Close zamyka połączenie z bazą danych po spełnieniu warunku
                connection.Dispose(); /// baza dysponuje już takimi danymi, dlatego następuje logowanie
                this.Hide(); /// zamyka okno
                konto_u wnd = new konto_u(txtb_login.Text); ///zaczytywanie i przypisywanie loginu do okna Konto uzytkownika
             
                wnd.Show();///pokaż okno
            
           
                reader.Close();///zamknięcie odczytywania bazy danych
            }


            else /// else czyli pozostałe przypadki, jeśli użytkownik wpisze niepoprawne wartości do textboxa loginu lub hasła wyrzuci komunikat o niepoprawnych danych
            {
                MessageBox.Show("Login lub hasło jest niepoprawne");///komunikat
            }
          
            connection.Close();///zakmnięcie połączenia z bazą danych
            reader.Close();///zamknięcie odczytywania danych z bazy
        }

        private void powrot_Click(object sender, RoutedEventArgs e)///metoda do kliknięcia przycisku
        {
            panel1  wnd = new panel1();///przeniesienie po klniknięciu do panelu1
            wnd.Show();///pokazanie okna
            this.Close();///zakmnięcie poprzedniego okna
        }
    }
}
