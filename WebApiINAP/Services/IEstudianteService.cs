using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiINAP.Models;

namespace WebApiINAP.Services
{
    public interface IEstudianteService
    {
        List<estudiante> getEstudiante();
        estudiante getEstudiantePorCi(int ci);
        void actualizarEstudiante(estudiante estudiante);
        void agregarEstudiante(estudiante estudiante);
        estudiante eliminarEstudiante(int ci);

    }
}
