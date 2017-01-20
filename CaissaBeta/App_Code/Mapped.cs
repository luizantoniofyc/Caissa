using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient; //MYSQL
using System.Data; //DATASET
using System.Configuration; //Web.config

namespace Caissa
{
    public class Mapped
    {
        public enum conexao
        {
            ServerExplorer,
            AppSettings
        }
        //Retorna uma conexao com oo BD Aberta
        public static IDbConnection Connection(conexao conn)
        {
            MySqlConnection obj=null;
            switch (conn)
            {
                case conexao.ServerExplorer:
                    obj = new MySqlConnection(ConfigurationManager.ConnectionStrings["frameworkBeta"].ConnectionString);
                    break;
                case conexao.AppSettings:
                    obj = new MySqlConnection(ConfigurationManager.AppSettings["strConexao"]);
                    break;
                default:
                    break;
            }
            
            obj.Open();
            return obj;
        }
        
        //Criar um comando de excução no BD
        public static IDbCommand Command(string query, IDbConnection conexao)
        {
            IDbCommand comm = conexao.CreateCommand();
            comm.CommandText = query;
            return comm;
        }

        //Criar comando para seleção (SELECT)
        public static IDataAdapter Adapter(IDbCommand command)
        {
            IDbDataAdapter adap = new MySqlDataAdapter();
            adap.SelectCommand = command;
            return adap;
        }

        //Criar parametro para SQL
        public static IDbDataParameter Parameter(string name, object value)
        {
            return new MySqlParameter(name, value);
        }

        //Criar parametro para SQL
        public static IDbDataParameter Parameter(string name, object value, DbType type, ParameterDirection direction)
        {
            MySqlParameter p = new MySqlParameter();
            p.ParameterName = name;
            p.Value = value;
            p.DbType = type;
            p.Direction = direction; 
            return p;
        }

        public Mapped()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}