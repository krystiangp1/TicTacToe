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
    /// pole gry
    /// </summary>
    public partial class pole_gry : Window
    {
        private OleDbConnection connection = new OleDbConnection();
        /// <summary>
        /// inicjalizuje połączenie z bazą danych
        /// </summary>
        public pole_gry()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\agaza\OneDrive\Desktop\Projekt\Baza_kolko_krzyzyk.accdb;
Persist Security Info=False;";
            ustawienie_poczatkowe();
            lbl_przypisanie();

        }
        /// <summary>
        /// int ilosc = 0 - zmienna okreslająca ilość klilniętych buttonów, domyślnie ustawiona jest na 0(czyli na ekranie nie są wyświetlane żadne znaki na buttonach)
        /// </summary>
        int ilosc = 0;
        string gracz1 = "an";
        static string gracz2 = "dada";
        bool k_gracz = true;


        /// <summary>
        /// funkcja statyczna z parametrem bool, służąca do losowania 
        /// </summary>
        /// <param name="k_gracz">parametr bool, który  </param>
        /// <returns>zwraca losowego gracza, który ma rozpoczynać grę </returns>

        public bool  losuj(bool k_gracz)
        {
            Random rand = new Random();
            for (int i = 1; i <= 2; i++)
            {
                k_gracz = rand.Next(2) == 0 ? false : true;
            }
            return k_gracz;
        }
        /// <summary>
        /// przypisywanie przyciskow x,o w zaleznosci od klikniecia - funkcja obługująca kliknięcie buttona
        /// </summary>
        private void button_click(object sender, RoutedEventArgs e)
        {

            Button b = (Button)sender;
            if (k_gracz)
            {
                b.Content = "X";
            }
            else
            {
                b.Content = "O";
            }

            ktoma_ruch();
            k_gracz = !k_gracz;
            b.IsEnabled = false;
            ilosc++;
            ktowygral();
        }
        /// <summary>
        /// metoda weryfikująca najechanie na button
        /// sprawdzenie przy pomocy warunku if...else czy mysz znajduje się na buttonie, pokazanie w zależności od gracza O lub X
        /// 
        /// </summary>

        private void mysz_zaznaczenie(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            if (b.IsEnabled)
            {
                if (k_gracz)
                {
                    b.Content = "X";
                }
                else
                    b.Content = "O";
            }
        }
        /// <summary>
        /// metoda, w której sprawdzamy czy mysz znajduje się na buttonie i przypisanie pustej nazwy do buttona
        /// /// </summary>

        private void mysz_odznaczenie(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            if (b.IsEnabled)
            {
                b.Content = "";
            }
        }
        /// <summary>
        /// ustawienie poczatkowe gry, zeruje wartosc wygranych remisow, oraz ruch graczy
        /// </summary>
        private void ustawienie_poczatkowe() /// ustawienie zerowych statystyk i etykiet kto gra
        {

            l_wygranych_x.Content = "0";
            l_wygranych_o.Content = "0";
            l_remisow.Content = "0";
            if (k_gracz)
            {
                lbl_ruch.Content = "Teraz ruch ma:";
                lbl_ruch2.Content = gracz1;
            }
            else///
            {
                lbl_ruch.Content = "Teraz ruch ma:";
                lbl_ruch2.Content = gracz2;
            }
        }
        /// <summary>
        /// metoda obslugujaca nowa gre - przypisuje wartość losową, zeruje tą wartość(ilosc=0) oraz przy pomocy pętli przeszukuje elementy w grid
        /// </summary>
        private void nowagra()
        {
            k_gracz = losuj(k_gracz);
            ilosc = 0;
            foreach (UIElement przyciski in gridd.Children)
            {
                if (przyciski.GetType() == typeof(Button))
                {
                    Button btn = (Button)przyciski;///
                    btn.IsEnabled = true;///
                    btn.Content = "";///
                }
            }
        }
        /// <summary>
        /// metoda przypisania tekstu do etykiety - wyświetlenie komunikatu o remisiez
        /// </summary>
        private void lbl_przypisanie()
        {
            lbl_gracz1.Content = gracz1;
            lbl_gracz2.Content = gracz2;
            lbl_remis.Content = "Remis";
        }
        /// <summary>
        /// metoda button_click - zwraca metody nowagra oraz ustwienia_początkowe - jest to metoda przycisku menu
        /// </summary>
        private void nowagra_Click(object sender, RoutedEventArgs e)
        {

            nowagra();
            ustawienie_poczatkowe();
        }
        /// <summary>
        /// metoda wyświetlająca po kliknięciu informacji o programie, za pomocą MessageBox
        /// </summary>

        private void o_programie_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Gra Stworzona przez:\nAgnieszka Zaguła \nKrystian Libuszowski\nMirosław Kiełbowicz", "Informacje");///okno informacyjne, kto stwprzyl grę
        }
        /// <summary>
        /// metoda powodująca zamknięcie aplikacji po kliknięciu w przycisk wyjście
        /// </summary>

        private void wyjscie_click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();///
        }
        /// <summary>
        /// metoda wyświetlenia okna ze statystykami po kliknięciu w przycisk
        /// </summary>

        private void statystyki_Click(object sender, RoutedEventArgs e)
        {
            Statystyki fs = new Statystyki();
            fs.ShowDialog();///
        }
        /// <summary>
        /// metoda sprawdzenia kto ma teraz ruch - wyświetlanie komunikatu o ruchu danego gracza
        /// </summary>
        private void ktoma_ruch()
        {
            if (k_gracz)
            {
                lbl_ruch.Content = "Teraz ruch ma: ";
                lbl_ruch2.Content = gracz2;
            }
            else
            {
                lbl_ruch.Content = "Teraz ruch ma: ";
                lbl_ruch2.Content = gracz1;
            }
        }
        /// <summary>
        /// sprawdzenie kto wygral oraz dodanie wyniku do statystyk poprzez odwołanie do tabeli Uzytkownicy, kolumny Login i połączenie go z TextBoxem txt_login oraz do kolumny Haslo i połączenie z tekstboxem txt_password
        /// </summary>
        public void ktowygral()
        {

            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from Punkty";


            bool zwyciezca = false;

            /// sprawdzenie poziome
            if ((A1.Content == A2.Content) && (A2.Content == A3.Content) && (!A1.IsEnabled))
                zwyciezca = true;
            else if ((B1.Content == B2.Content) && (B2.Content == B3.Content) && (!B1.IsEnabled))
                zwyciezca = true;
            else if ((C1.Content == C2.Content) && (C2.Content == C3.Content) && (!C1.IsEnabled))
                zwyciezca = true;

            /// sprawdzenie pion
            else if ((A1.Content == B1.Content) && (B1.Content == C1.Content) && (!A1.IsEnabled))
                zwyciezca = true;
            else if ((A2.Content == B2.Content) && (B2.Content == C2.Content) && (!A2.IsEnabled))
                zwyciezca = true;
            else if ((A3.Content == B3.Content) && (B3.Content == C3.Content) && (!A3.IsEnabled))
                zwyciezca = true;


            /// sprawdzenie po przekatnej
            else if ((A1.Content == B2.Content) && (B2.Content == C3.Content) && (!A1.IsEnabled))
                zwyciezca = true;
            else if ((A3.Content == B2.Content) && (B2.Content == C1.Content) && (!C1.IsEnabled))
                zwyciezca = true;


            /// <summary>
            /// zapis do bazy wygranej,oraz wyswietlenie zwyciezcy
            /// </summary>
            if (zwyciezca)
            {
                string wys_zwyciezcy = "";
                if (k_gracz)
                {
                    OleDbDataReader reader = command.ExecuteReader();
                    reader.Close();
                    wys_zwyciezcy = gracz2;
                    l_wygranych_o.Content = Convert.ToInt32(l_wygranych_o.Content) + 1;
                    command.CommandText = "insert into Punkty (Login , Punkty) values (@kolumna1 , @kolumna2)"; // zapis do bazy punktu za wygranie rundy
                    command.Parameters.AddWithValue("@kolumna1", wys_zwyciezcy);/// rozpisanie kolumn
                    command.Parameters.AddWithValue("@kolumna2", '1');
                    command.ExecuteNonQuery(); ///zwraca informację o wykonanym zadaniu do bazy danych
                    connection.Close();
                    MessageBox.Show(wys_zwyciezcy + " Wygral!", "Wynik");
                    nowagra();
                }
                else
                {
                    wys_zwyciezcy = gracz1;
                    l_wygranych_x.Content = Convert.ToInt32(l_wygranych_x.Content) + 1;

                    command.CommandText = "insert into Punkty (Login , Punkty) values (@kolumna1 , @kolumna2)"; // zapis do bazy punktu za wygranie rundy
                    command.Parameters.AddWithValue("@kolumna1", wys_zwyciezcy);/// rozpisanie kolumn
                    command.Parameters.AddWithValue("@kolumna2", '1');
                    command.ExecuteNonQuery(); ///zwraca informację o wykonanym zadaniu do bazy danych
                    connection.Close();
                    MessageBox.Show(wys_zwyciezcy + " Wygral!", "Wynik");
                    nowagra();


                }
            }

            else
            {
                if (ilosc == 9)///warunek if
                {
                    l_remisow.Content = Convert.ToInt32(l_remisow.Content) + 1;
                    MessageBox.Show("Remis", "Wynik");///wyświetlenie komunikatu 
                    nowagra();//odwołanie do metody nowagra

                }
            }

            connection.Close(); ///zamknięcie połączenia z baza danych
        }


    }
    }

    