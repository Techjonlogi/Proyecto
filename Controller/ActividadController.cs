using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sistema_de_Prácticas_Profesionales.Logica.AddEnum;
using Sistema_de_Prácticas_Profesionales.DAO;
using Sistema_de_Prácticas_Profesionales.Pojos.Actividad;

namespace Sistema_de_Prácticas_Profesionales.Controller
{
    class ActividadController
    {
        public enum OperationResult
        {
            Success,
            NullAlumno,
            InvalidAlumno,
            UnknowFail,
            SQLFail,
            ExistingRecord
        }

        public OperationResult AddActividad(String id, String nombre, int diaEntrega, int mesEntrega, String añoEntrega, Double valor)
        {

            OperationResult operation = OperationResult.UnknowFail;
            if (GetActividadId(id).IdActividad == null)
            {
                Actividad actividad = new Actividad();

                actividad.IdActividad = id;
                actividad.NombreActividad = nombre;
                actividad.DiaEntregaActividad = diaEntrega;
                actividad.MesEntregaActividad = mesEntrega;
                actividad.AñoEntregaActividad = añoEntrega;
                actividad.ValorActividad = valor;

                ActividadDAO actividadDAO = new ActividadDAO();
                operation = (OperationResult)actividadDAO.AddActividad(actividad);
            }
            else
            {
                operation = OperationResult.ExistingRecord;
            }

            return operation;
        }

        public List<Actividad> GetActividad()
        {
            ActividadDAO actividadDAO = new ActividadDAO();
            List<Actividad> list = actividadDAO.GetActividad();
            return list;
        }

        public Actividad GetActividadId(String id)
        {
            ActividadDAO actividadDAO = new ActividadDAO();
            return actividadDAO.GetActividadID(id);
        }

        public OperationResult DeleteActividadId(String id)
        {
            ActividadDAO actividadDAO = new ActividadDAO();
            return (OperationResult)actividadDAO.DeleteActividadID(id);
        }

    }
}
