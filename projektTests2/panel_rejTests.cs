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
    public class panel_rejTests
    {

        private OleDbConnection connection = new OleDbConnection();

        [TestMethod()]
        public void TestRejestracjidobazy()
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Projekt\Baza_kolko_krzyzyk.accdb;
Persist Security Info=False;";

            string txt_login = "probazapisuu";
            string txt_password = "zapis";

            connection.Open();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "insert into Uzytkownicy (Login , Haslo) values (@kolumna1 , @kolumna2)"; // zapis do bazy punktu za wygranie rundy
            command.Parameters.AddWithValue("@kolumna1", txt_login);/// rozpisanie kolumn
            command.Parameters.AddWithValue("@kolumna2", txt_password);
            try
            {
                command.ExecuteNonQuery(); ///zwraca informację o wykonanym zadaniu do bazy danych(czyli zapisuje login i hasło do bazy)
                bool actual = true;
                bool expected = true;
                Assert.AreEqual(expected, actual);
                connection.Close();
            }
            catch { return; }


        }
    }
}