using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SQLite;

namespace eAgenda.Controladores.Shared
{
    public delegate T ConverterDelegate<T>(IDataReader reader);

    public static class Db
    {
        public static readonly string connectionString = "";
        public static readonly string bancoEscolhido = "";

        static Db()
        {
            bancoEscolhido = ConfigurationManager.AppSettings["bancodedados"].Trim();
            connectionString = ConfigurationManager.ConnectionStrings[bancoEscolhido].ConnectionString;
        }

        public static int Insert(string sql, Dictionary<string, object> parameters)
        {
            int id = 0;

            if (bancoEscolhido == "dbsqlite")
                id = DbSQLITE.Insert(sql, parameters);

            if (bancoEscolhido == "DBeAgenda")
                id = DbSQL.Insert(sql, parameters);

            return id;
        }

        public static void Update(string sql, Dictionary<string, object> parameters = null)
        {
            if (bancoEscolhido == "dbsqlite")
                DbSQLITE.Update(sql, parameters);

            if (bancoEscolhido == "DBeAgenda")
                DbSQL.Update(sql, parameters);
        }

        public static void Delete(string sql, Dictionary<string, object> parameters)
        {
            Update(sql, parameters);
        }

        public static List<T> GetAll<T>(string sql, ConverterDelegate<T> convert, Dictionary<string, object> parameters = null)
        { 
            if (bancoEscolhido == "dbsqlite")
                return DbSQLITE.GetAll(sql, convert, parameters);

            if (bancoEscolhido == "DBeAgenda")
                return DbSQL .GetAll(sql, convert, parameters);

            return new List<T>();
        }

        public static T Get<T>(string sql, ConverterDelegate<T> convert, Dictionary<string, object> parameters)
        {            
            if (bancoEscolhido == "dbsqlite")
                return DbSQLITE.Get(sql, convert, parameters);

            if (bancoEscolhido == "DBeAgenda")
                return DbSQL.Get(sql, convert, parameters);
            
            return default;
        }

        public static bool Exists(string sql, Dictionary<string, object> parameters)
        {
            if (bancoEscolhido == "dbsqlite")
                return DbSQLITE.Exists(sql, parameters);

            if (bancoEscolhido == "DBeAgenda")
                return DbSQL.Exists(sql, parameters);

            return false;
        }
    }
}
