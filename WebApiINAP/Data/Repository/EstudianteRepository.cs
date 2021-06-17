using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiINAP.Models;

namespace WebApiINAP.Data.Repository
{
    public class EstudianteRepository : IEstudianteRepository
    {
        public bdInapEntities db = new bdInapEntities();

        public EstudianteRepository()
        {

        }
        public void actualizarEstudiante(estudiante estudiante)
        {
            db.Entry(estudiante).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void agregarEstudiante(estudiante estudiante)
        {
            db.estudiante.Add(estudiante);
            db.SaveChanges();
        }

        public estudiante eliminarEstudiante(int ci)
        {
            estudiante estudiante = db.estudiante.Find(ci);
            if (estudiante != null)
            {
                db.estudiante.Remove(estudiante);
                db.SaveChanges();
            }
            return estudiante;
        }

        public IQueryable<estudiante> getEstudiante()
        {
            return db.estudiante;
        }

        public estudiante getEstudiantePorCi(int ci)
        {
            return db.estudiante.Find(ci);
        }       
    }
}