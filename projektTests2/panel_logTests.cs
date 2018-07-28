using Microsoft.VisualStudio.TestTools.UnitTesting;
using projekt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
namespace projekt.Tests
{
    [TestClass()]
    public class panel_logTests
    {
        private OleDbConnection connection = new OleDbConnection();
  
        [TestMethod()]
        public void TestLogowania()
        {
           

            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Projekt\Baza_kolko_krzyzyk.accdb;
Persist Security Info=False;";

            connection.Open();
            string s1, s2;

            s1 = "testy";
            s2 = "1234";
            OleDbCommand command = new OleDbCommand();
           
            command.Connection = connection;

           command.CommandText = "select * from Uzytkownicy where Login='" + s1 + "' and Haslo='" + s2 + "'";

        

            OleDbDataReader reader = command.ExecuteReader();
            int count = 0;

            while (reader.Read()) ///<summary>while (reader.Read()) przy pomocy pętli while zwiększam wartość zmiennej count o 1(będzie to odzwierciedleniem indeksów w bazie, dzięki temu weryfikuje po kolei loginy i hasła wpisane do bazy); ///</summary>
            {
                count = count + 1;
                ///count++;


            }
            if (count == 1) /// instrukcja if(jesli hasło jest poprawne i się pokrywa 1:1 to logowanie następuje i pojawia się komunikat. 
            {

                bool actuale = true;
                bool expectede = true;
                Assert.AreEqual(expectede, actuale);
            }

            else /// else czyli pozostałe przypadki, jeśli użytkownik wpisze niepoprawne wartości do textboxa loginu lub hasła wyrzuci komunikat o niepoprawnych danych
            {

                bool actual = false;
                bool expected = true;
                Assert.AreEqual(expected, actual);

            }

            connection.Close();///zakmnięcie połączenia z bazą danych
            reader.Close();///zamknięcie odczytywania danych z bazy
        }
    }
}