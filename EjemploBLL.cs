using DAL;
using ENTIDADES.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BLL
{
    public class EjemploBLL
    {
        public List<EjemploDTO> GetObtenerDatos()
        {
            EjemploDAL dato = new EjemploDAL();
            return dato.obtenerDatos();
        }
        
    }
}
