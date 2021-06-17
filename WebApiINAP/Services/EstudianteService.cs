using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiINAP.Data.Repository;
using WebApiINAP.Models;

namespace WebApiINAP.Services
{
    public class EstudianteService : IEstudianteService
    {
        public IEstudianteRepository estudianteRepository;

        public EstudianteService(IEstudianteRepository estudianteRepository)
        {
            this.estudianteRepository = estudianteRepository;
            //estudianteRepository = new EstudianteRepository();
        }

        public void actualizarEstudiante(estudiante estudiante)
        {
            estudianteRepository.actualizarEstudiante(estudiante);
        }

        public void agregarEstudiante(estudiante estudiante)
        {
            estudianteRepository.agregarEstudiante(estudiante);
        }

        public estudiante eliminarEstudiante(int ci)
        {
            estudiante estudiante = estudianteRepository.eliminarEstudiante(ci);
            if (estudiante == null)
            {
                throw new EstudianteNoEncontrado();
            }

            return estudiante;
        }

        public List<estudiante> getEstudiante()
        {
            return estudianteRepository.getEstudiante().ToList();
        }

        public estudiante getEstudiantePorCi(int ci)
        {
            estudiante estudiante = estudianteRepository.getEstudiantePorCi(ci);
            if (estudiante == null)
            {
                throw new EstudianteNoEncontrado();
            }
            return estudiante;
        }
    }
}