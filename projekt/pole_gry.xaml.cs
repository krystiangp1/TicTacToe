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

namespace projekt
{
    /// <summary>
    /// Logika interakcji dla klasy Window4.xaml
    /// </summary>
    public partial class pole_gry : Window
    {
        public pole_gry()
        {
            
            InitializeComponent();
            ustawienie_poczatkowe(); // odwolanie do metody
            lbl_przypisanie(); // odwolanie do metody
        }


        int ilosc = 0;
        static string gracz1 = "Gracz 1", gracz2 = "Gracz 2";
        bool k_gracz = true;

        static bool losuj(bool k_gracz) // losowanie gracza kto zaczyna
        {
            Random rand = new Random();
            for (int i = 1; i <= 2; i++)
            {
                k_gracz = rand.Next(2) == 0 ? false : true;
            }
            return k_gracz;
        }

        private void button_click(object sender, RoutedEventArgs e) // obsluga klikniecia buttona
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

        private void mysz_zaznaczenie(object sender, MouseEventArgs e) // najechanie na button
        {
            Button b = (Button)sender;
            if (b.IsEnabled) // sprawdzenie czy mysz znajduje sie na buttonie
            {
                if (k_gracz)
                {
                    b.Content = "X"; // pokazanie X na buttonie
                }
                else
                    b.Content = "O"; // pokazanie O na buttonie
            }
        }

        private void mysz_odznaczenie(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            if (b.IsEnabled) // sprawdzenie czy mysz znajduje sie na buttonie
            {
                b.Content = ""; // nadanie pustej nazwy buttona
            }
        }

        private void ustawienie_poczatkowe() // ustawienie zerowych statystyk i etykiet kto gra
        {

            l_wygranych_x.Content = "0";
            l_wygranych_o.Content = "0";
            l_remisow.Content = "0";
            if (k_gracz)
            {
                lbl_ruch.Content = "Teraz ruch ma:";
                lbl_ruch2.Content = gracz1;
            }
            else
            {
                lbl_ruch.Content = "Teraz ruch ma:";
                lbl_ruch2.Content = gracz2;
            }
        }

        private void nowagra() // metoda obslugujaca nowa gre
        {
            k_gracz = losuj(k_gracz); // przypisanie wartosci losowej
            ilosc = 0; //zerowanie wartosci
            foreach (UIElement przyciski in gridd.Children)  //petla przeszukanie elementow w grid,
            {
                if (przyciski.GetType() == typeof(Button)) //typ button
                {
                    Button btn = (Button)przyciski;
                    btn.IsEnabled = true;
                    btn.Content = "";
                }
            }
        }

        private void lbl_przypisanie() // przypisanie tekstu etykieta label
        {
            lbl_gracz1.Content = gracz1;
            lbl_gracz2.Content = gracz2;
            lbl_remis.Content = "Remis";
        }

        private void nowagra_Click(object sender, RoutedEventArgs e) //przycisk menu
        {
            nowagra();
            ustawienie_poczatkowe();
        }

        private void o_programie_Click(object sender, RoutedEventArgs e) // menu o programie
        {
            MessageBox.Show("Gra Stworzona przez:\nAgnieszka Zaguła \nKrystian Libuszowski\nMirosław Kiełbowicz", "Informacje");
        }

        private void wyjscie_click(object sender, RoutedEventArgs e) // menu zamkniecie aplikacji
        {
            Application.Current.Shutdown();
        }

        private void statystyki_Click(object sender, RoutedEventArgs e) // menu statystyki
        {
            Statystyki fs = new Statystyki();
            fs.ShowDialog();
        }

        private void ktoma_ruch() //metoda sprawdzenia kto ma teraz ruch
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

        private void ktowygral() //sprawdzenie kto wygral oraz dodanie statystyk
        {
            bool zwyciezca = false;

            // sprawdzenie poziome
            if ((A1.Content == A2.Content) && (A2.Content == A3.Content) && (!A1.IsEnabled))
                zwyciezca = true;
            else if ((B1.Content == B2.Content) && (B2.Content == B3.Content) && (!B1.IsEnabled))
                zwyciezca = true;
            else if ((C1.Content == C2.Content) && (C2.Content == C3.Content) && (!C1.IsEnabled))
                zwyciezca = true;

            // sprawdzenie pion
            else if ((A1.Content == B1.Content) && (B1.Content == C1.Content) && (!A1.IsEnabled))
                zwyciezca = true;
            else if ((A2.Content == B2.Content) && (B2.Content == C2.Content) && (!A2.IsEnabled))
                zwyciezca = true;
            else if ((A3.Content == B3.Content) && (B3.Content == C3.Content) && (!A3.IsEnabled))
                zwyciezca = true;


            // sprawdzenie po przekatnej
            else if ((A1.Content == B2.Content) && (B2.Content == C3.Content) && (!A1.IsEnabled))
                zwyciezca = true;
            else if ((A3.Content == B2.Content) && (B2.Content == C1.Content) && (!C1.IsEnabled))
                zwyciezca = true;


            if (zwyciezca)
            {
                string wys_zwyciezcy = "";
                if (k_gracz)
                {
                    wys_zwyciezcy = gracz2;
                    l_wygranych_o.Content = Convert.ToInt32(l_wygranych_o.Content) + 1;
                }
                else
                {
                    wys_zwyciezcy = gracz1;
                    l_wygranych_x.Content = Convert.ToInt32(l_wygranych_x.Content) + 1;
                }
                MessageBox.Show(wys_zwyciezcy + " Wygral!", "Wynik");
                nowagra();
            }
            else
            {
                if (ilosc == 9)
                {
                    l_remisow.Content = Convert.ToInt32(l_remisow.Content) + 1;
                    MessageBox.Show("Remis", "Wynik");
                    nowagra();
                }
            }
        }

    }
}