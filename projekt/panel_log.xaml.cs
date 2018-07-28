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
    ///  panel logowania
    /// </summary>
    public partial class panel_log : Window

    {
        
        /// <summary>
        /// połączenie z bazą danych
        /// </summary>
        private OleDbConnection connection = new OleDbConnection();
        /// <summary>
        /// zaczytanie z jakiej ścieżki panel_log ma zaczytywać bazę danych
        /// </summary>
        public panel_log()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\agaza\OneDrive\Desktop\Projekt\Baza_kolko_krzyzyk.accdb;
Persist Security Info=False;";

        }
        /// <summary>
        /// metoda TextBox
        /// </summary>
        
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)

        {

        }
        /// <summary>
        /// metoda służąca do weryfikowania danych podczas logowania do bazy 
        /// funkcja przy pomocy pętli weryfikuje po kolei rekordy w bazie, jesli natrafi na taki sam login i hasło wpisane przez uzytkownika nastepuje logowanie, jesli nie zwraca komunikat o błędzie
        /// </summary>
       
        public void b_zaloguj_Click(object sender, RoutedEventArgs e)///metoda zaloguj po kliknięciu
        {

            connection.Open();

            OleDbCommand command = new OleDbCommand();

            command.Connection = connection;

            command.CommandText = "select * from Uzytkownicy where Login='" + txtb_login.Text + "' and Haslo='" + txtb_haslo.Password + "'";

            OleDbDataReader reader = command.ExecuteReader();

            int count = 0;

            while (reader.Read()) ///<summary>while (reader.Read()) przy pomocy pętli while zwiększam wartość zmiennej count o 1(będzie to odzwierciedleniem indeksów w bazie, dzięki temu weryfikuje po kolei loginy i hasła wpisane do bazy); ///</summary>
            {
                count = count + 1;
                ///count++;


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
        /// <summary>
        /// metoda kliknięcia w przycisk cofa nas do panel1
        /// </summary>
        
        private void powrot_Click(object sender, RoutedEventArgs e)
        {
            panel1 wnd = new panel1();
            wnd.Show();
            this.Close();
        }
    }
}
