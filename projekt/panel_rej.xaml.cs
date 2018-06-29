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
        private OleDbConnection connection = new OleDbConnection();
        public panel_rej()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Projekt\Baza_kolko_krzyzyk.accdb;
Persist Security Info=False;";  //to jest połączenie z bazą danych z lokalizacją na lokalnym dysku komputera

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void b_zarejestruj_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from Uzytkownicy where Login='" + txt_login.Text + "' and Haslo='" + txt_password.Password + "'";  // odwołanie do tabeli Uzytkownicy, kolumny Login i połączenie go z TextBoxem txt_login oraz do kolumny Haslo i połączenie z tekstboxem txt_password
            OleDbDataReader reader = command.ExecuteReader();

            int count = 0; // tworzę zmienną count równą 0(będzie to odzwierciedleniem loginów i haseł w bazie, dzięki temu weryfikuje po kolei loginy i hasła wpisane do bazy);
            while (reader.Read()) // przy pomocy pętli while przesuwam się po rekordach naszej bazy
            {
                count = count + 1;
                //count++;
                //

                
            }
            if (count < 1) // instrukcja if(jesli loginów i haseł jest mniej niż 1 zapisuje konto)
            {
                reader.Close();

                // command.CommandText = "insert into Uzytkownicy(Login, Haslo) values('"+txt_login.Text + "','" + txt_password.Password +"',)"; // odwołanie do bazy danych aby po spełnieniu warunku if nasze dane zostają zapisane w tabeli w odpowiednich kolumnach

                command.CommandText = "insert into Uzytkownicy (Login , Haslo) values (@kolumna1 , @kolumna2)"; // zapis do bazy punktu za wygranie rundy
                command.Parameters.AddWithValue("@kolumna1", txt_login.Text);// rozpisanie kolumn
                command.Parameters.AddWithValue("@kolumna2", txt_password.Password);


                try
                {
                    command.ExecuteNonQuery(); //zwraca informację o wykonanym zadaniu do bazy danych(czyli zapisuje login i hasło do bazy)
                    MessageBox.Show("Konto zostało zapisane!");
                    connection.Close();
                }
                catch { MessageBox.Show("bl"); }
               
                // connection.Close zamyka połączenie z bazą danych po spełnieniu warunku
                if (count == 1) // jeśli przy logowaniu wartość takiego samego loginu i hasła jest taka sama, zwraca komunikat o istniejącym loginie lub haśle
                {
                    reader.Close();
                    MessageBox.Show("Login lub hasło istnieje");

                    connection.Close();
                    connection.Dispose(); //baza danych dysponuje już takimi danymi 
                }
            }
            if (count == 1) // jeśli przy logowaniu wartość takiego samego loginu i hasła jest taka sama, zwraca komunikat o istniejącym loginie lub haśle
            {
                MessageBox.Show("Login lub hasło istnieje");
                connection.Close();
                connection.Dispose(); //baza danych dysponuje już takimi danymi 

            }
            else  // else czyli pozostałe przypadki, jeśli użytkownik wpisze niepoprawne wartości do textboxa loginu lub hasła wyrzuci komunikat o niepoprawnych danych
            {
                MessageBox.Show("Login lub hasło jest niepoprawne");
            }
            reader.Close();
            connection.Close();
        }

        private void sprbaze_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = @" Provider = Microsoft.ACE.OLEDB.12.0;"
     + @"data source=D:\Projekt\Baza_kolko_krzyzyk.accdb"; // rowniez odwołanie do lokalnej bazy danych
                connection.Open();
                labelspr.Content = "Polaczenie poprawne"; // to powinno wyświetlać po zdebugowaniu, gdy połączenie z bazą jest poprawne
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Blad polaczenia" + ex); // w razie problemów z bazą wyświetli komunikat "Blad polaczenia"
            }

        }

        private void powrot_Click(object sender, RoutedEventArgs e)
        {
            panel1 wnd = new panel1();
            wnd.Show();
            this.Close();
        }
    }
}
