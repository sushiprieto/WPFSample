﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

// Esta clase contiene los métodos necesarios para trabajar con el acceso a una base de datos SQL Server
//PROPIEDADES
//   _database: cadena, básica. Consultable/modificable.
//   _user: cadena, básica. Consultable/modificable.
//   _pass: cadena, básica. Consultable/modificable.

// MÉTODOS
//   Function getConnection() As SqlConnection
//       Este método abre una conexión con la base de datos. Lanza excepciones de tipo: SqlExcepion, InvalidOperationException y Exception.
//   
//   Sub closeConnection(ByRef connection As SqlConnection)
//       Este método cierra una conexión con la base de datos. Lanza excepciones de tipo: SqlExcepion, InvalidOperationException y Exception.
//


namespace WPFSample_DAL
{
    public class clsMyConnection
    {
        //Atributos
        public String host { get; set; }
        public String dataBase { get; set; }
        public String user { get; set; }
        public String pass { get; set; }

        public SqlConnection connection { get; set; }

        //Constructores

        public clsMyConnection()
        {
            //this.host = "192.168.0.161"; //IP de Fernando
            this.host = "iesnervion.database.windows.net";
            this.dataBase = "WPFSample";
            //El primer usuario es de de la base de datos del instituto, el segundo la de casa
            this.user = "prueba";
            //this.user = "pruebaResident";
            //this.pass = "123";
            this.pass = "iesnervion123.";

        }
        //Con parámetros por si quisiera cambiar las conexiones
        public clsMyConnection(String host, String database, String user, String pass)
        {
            this.host = host;
            this.dataBase = database;
            this.user = user;
            this.pass = pass;
        }


        //METODOS



        /// <summary>
        /// Método que abre una conexión con la base de datos
        /// </summary>
        /// <pre>Nada.</pre>
        /// <returns>Una conexión con la base de datso</returns>
        public void getConnection()
        {
            connection = new SqlConnection();
            try
            {
                //connection.ConnectionString = "Data Source=" & My.Computer.Name & "Initial Catalog=" & _database & ";uid=" & _user & ";pwd=" & _user & ";"
                //connection.ConnectionString = "server=(local);database=" + dataBase + ";uid=" + user + ";pwd=" + pass + ";";
                //Muy cómoda esta forma de escribir la cadena conStringFormat, metiendo los parametros entre llaves y asignandoselo tras la coma
                connection.ConnectionString = string.Format("server={0};database={1};uid={2};pwd={3};", host, dataBase, user, pass);
                connection.Open();
            }
            catch (SqlException)
            {
                throw;
            }

            //return connection;

        }

        /// <summary>
        /// Este metodo cierra una conexión con la Base de datos
        /// </summary>
        /// <post>The connection is closed.</post>
        /// <param name="connection">La entrada es la conexión a cerrar
        /// </param>
        public void closeConnection()
        {
            try
            {
                connection.Close();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw; 
            }
            catch (Exception)
            {
            throw;
            }
        }


    }

}
