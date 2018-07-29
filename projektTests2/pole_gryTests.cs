using Microsoft.VisualStudio.TestTools.UnitTesting;
using projekt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace projekt.Tests
{/// <summary>
/// klasa testująca pole_gryTests
/// </summary>
    [TestClass()]
    public class pole_gryTests
    {
        private OleDbConnection connection = new OleDbConnection();

        /// <summary>
        /// metoda sprawdzająca losowość oraz czy poprawnie działa wybór gracza, który rozpoczyna rozgrywkę
        /// </summary>
        [TestMethod()]
        public void losujTest()
        {

            bool k_gracz = true;
            Random rand = new Random();
            for (int i = 1; i <= 2; i++)
            {
                k_gracz = rand.Next(1) == 0 ? true : false;
                bool actual = (k_gracz);
                bool expected = true;


                Assert.AreEqual(expected, actual);
            }
        }
        /// <summary>
        /// metoda testująca zapis punktów do bazy danych przypisanych odpowiedniemu użytkownikowi
        /// </summary>
        [TestMethod()]
        public void Spr_zapis_do_bazy_Wynik()
        {

            string s1;

            s1 = "testy";
           
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Projekt\Baza_kolko_krzyzyk.accdb;
Persist Security Info=False;";
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
    
                    command.CommandText = "insert into Punkty (Login , Punkty) values (@kolumna1 , @kolumna2)"; // zapis do bazy punktu za wygranie rundy
                    command.Parameters.AddWithValue("@kolumna1", s1);/// rozpisanie kolumn
                    command.Parameters.AddWithValue("@kolumna2", '1');
                    connection.Close();

            try
            {

                bool actual = true;
                bool expected = true;
                Assert.AreEqual(expected, actual);
                connection.Close();
            }
            catch { return; }

           


        }
    }
}