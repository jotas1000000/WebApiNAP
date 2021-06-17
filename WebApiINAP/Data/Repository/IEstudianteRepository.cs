using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiINAP.Models;

namespace WebApiINAP.Data.Repository
{
    public interface IEstudianteRepository
    {
        IQueryable<estudiante> getEstudiante();
        estudiante getEstudiantePorCi(int ci);
        void actualizarEstudiante(estudiante estudiante);
        void agregarEstudiante(estudiante estudiante);
        estudiante eliminarEstudiante(int ci);
    }   
}
