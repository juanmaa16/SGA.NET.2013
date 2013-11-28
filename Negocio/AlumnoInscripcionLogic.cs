using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Data.Database;

namespace Negocio
{
    public class AlumnoInscripcionLogic : BusinessLogic
    {
        AlumnoInscripcionAdapter aiData;

        public AlumnoInscripcionLogic()
        {
            this.aiData = new AlumnoInscripcionAdapter();
        }

        public AlumnoInscripcionAdapter AlumnoInscripcionData
        { get; set; }

        public List<AlumnoInscripcion> GetAll()
        {
            return aiData.GetAll();
        }

        public List<AlumnoInscripcion> GetAllByIdCurso(int IdCurso)
        {
            return aiData.GetAllByIdCurso(IdCurso);
        }


        public AlumnoInscripcion GetOne(int IdAlumno, int IdCurso)
        {
            return aiData.GetOne(IdAlumno, IdCurso);
        }

        public void Delete(int IdAlumno, int IdCurso)
        {
            aiData.Delete(IdAlumno, IdCurso); 
        }

        public void Save(AlumnoInscripcion alumnoInscripcion)
        {
            aiData.Save(alumnoInscripcion);
        }
    }
}
