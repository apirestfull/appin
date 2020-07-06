using ENTIDADES.DTO;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace DAL
{
    public class EjemploDAL
    {
        NpgsqlConnection Conn = new NpgsqlConnection();

        public List<EjemploDTO> obtenerDatos()
        {
            try
            {
                Conn = ConnectionDAL.Singleton.ConnetionFactory;
                Conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT nombre, tipo_doc FROM esq_appin2020.registro_usuarios; ", Conn);
                cmd.CommandType = CommandType.Text;

                DataTable dt = new DataTable();                
                NpgsqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);

                var listaUsuario = (from DataRow fila in dt.Rows
                                    select new EjemploDTO()
                                    {
                                        tipo_doc = fila["tipo_doc"].ToString(),
                                        nombre = fila["nombre"].ToString()
                                    }).ToList();

                return listaUsuario;

            }
            catch (Exception ex)
            {
                throw new Exception(" Error al ejecutar procedimiento almacenado ", ex);
            }
            finally
            {
                Conn.Close();
            }
        }
    }
}
