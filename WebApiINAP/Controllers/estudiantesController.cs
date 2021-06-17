using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebApiINAP.Data.Repository;
using WebApiINAP.Models;
using WebApiINAP.Services;

namespace WebApiINAP.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class estudiantesController : ApiController
    {        
        private IEstudianteService estudianteService;

        public estudiantesController(IEstudianteService estudianteService)
        {
            this.estudianteService = estudianteService;
            //estudianteService = new EstudianteService();
        }     
        
        // GET: api/estudiantes
        public List<estudiante> Getestudiante()
        {
            //return estudianteRepository.getEstudiante();
            return estudianteService.getEstudiante();
        }

        // GET: api/estudiantes/5
        [ResponseType(typeof(estudiante))]
        public IHttpActionResult Getestudiante(int id)
        {
            /*estudiante estudiante = estudianteRepository.getEstudiantePorCi(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return Ok(estudiante);*/
            try
            {
                estudiante estudiante = estudianteService.getEstudiantePorCi(id);
                return Ok(estudiante);
            }
            catch (EstudianteNoEncontrado)
            {
                return NotFound();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT: api/estudiantes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putestudiante(int id, estudiante estudiante)
        {
            /*if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estudiante.ci)
            {
                return BadRequest();
            }*/
                        

            try
            {
                estudianteService.actualizarEstudiante(estudiante);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/estudiantes
        [ResponseType(typeof(estudiante))]
        public IHttpActionResult Postestudiante(estudiante estudiante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                        
            try
            {
                estudianteService.agregarEstudiante(estudiante);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return CreatedAtRoute("DefaultApi", new { id = estudiante.ci }, estudiante);
        }

        // DELETE: api/estudiantes/5
        [ResponseType(typeof(estudiante))]
        public IHttpActionResult Deleteestudiante(int id)
        {
            /*estudiante estudiante = estudianteRepository.eliminarEstudiante(id);
            if (estudiante == null)
            {
                return NotFound();
            }
                       

            return Ok(estudiante);*/

            try
            {
                estudiante estudiante = estudianteService.eliminarEstudiante(id);
                return Ok(estudiante);
            }
            catch (EstudianteNoEncontrado)
            {
                return NotFound();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool estudianteExists(int id)
        {
            return db.estudiante.Count(e => e.ci == id) > 0;
        }*/
    }
}