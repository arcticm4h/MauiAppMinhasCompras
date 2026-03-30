using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDataBaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }

        public void InsertProduto(Produto p) { }

        public void UpdateProduto(Produto p) { }

        public void DeleteProduto(int id) { }

        public void GetAll()LTW!


    }//Fecha class
}//Fecha namespace
