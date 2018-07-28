using Microsoft.VisualStudio.TestTools.UnitTesting;
using projekt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace projekt.Tests
{
    [TestClass()]
    public class StatystykiTests
    {
        public OleDbConnection connection = new OleDbConnection();
      
   
        [TestMethod]
        public void SprawdzenieBazy()
        {
           
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Projekt\Baza_kolko_krzyzyk.accdb;
Persist Security Info=False;";

            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                bool actual = true;
                bool expected = true;
                Assert.AreEqual(expected, actual);
            }

        }
        }
    }
