﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AerolineaFrba.Classes
{
    class Milla
    {
        public void CrearMillas()
        {

        }

        
        public static void TraerMillasDisponible(ref int millasDisp, ref int idUsuario, string ape, string dni)
        {
            SqlConnection objConexion = new SqlConnection(Conexion.strCon);
            string strProc = "THE_BTREES.GetCantMillasDisponibles";
            SqlCommand comando = new SqlCommand(strProc, objConexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Apellido", ape);
            comando.Parameters.AddWithValue("@DNI", dni);
            comando.Parameters.AddWithValue("@Fecha", DateTime.Today);
            SqlParameter idCli = new SqlParameter("@ClienteRef", 0);
            idCli.Direction = ParameterDirection.Output;
            comando.Parameters.Add(idCli);
            SqlParameter cantMil = new SqlParameter("@CantMillasDisponibles", 0);
            cantMil.Direction = ParameterDirection.Output;
            comando.Parameters.Add(cantMil);
            objConexion.Open();
            comando.ExecuteNonQuery();
            idUsuario = Convert.ToInt32(comando.Parameters["@ClienteRef"].Value);
            millasDisp = Convert.ToInt32(comando.Parameters["@CantMillasDisponibles"].Value);
            objConexion.Close();
            objConexion.Dispose();
        }

        public static DataTable TraerDetalleTransMillas(int clienteRef)
        {
            DataTable dt = new DataTable();
            string strProc = "THE_BTREES.GetCantMillasDisponibles";

            using (var da = new SqlDataAdapter(strProc, Conexion.strCon))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@ClienteRef", clienteRef);
                da.SelectCommand.Parameters.AddWithValue("@Fecha", DateTime.Now);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
