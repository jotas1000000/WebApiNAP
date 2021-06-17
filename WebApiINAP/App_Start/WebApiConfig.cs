using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.WebApi;
using WebApiINAP.Data.Repository;
using WebApiINAP.Services;

namespace WebApiINAP
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();
            var container = new UnityContainer();
            container.RegisterType<IEstudianteService, EstudianteService>();
            container.RegisterType<IEstudianteRepository, EstudianteRepository>();
            config.DependencyResolver = new UnityDependencyResolver(container);

            config.EnableCors();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.
                Add(new System.Net.Http.Formatting.RequestHeaderMapping("Accept", "text/html",
                StringComparison.InvariantCultureIgnoreCase, true, "application/json"));
        }

        
    }
}
