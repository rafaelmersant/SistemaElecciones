using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SistemaElecciones
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Candidates",
                url: "Candidates/Candidates",
                defaults: new { controller = "Candidates", action = "index" }
            );

            routes.MapRoute(
               name: "Rounds",
               url: "Rounds/Rounds",
               defaults: new { controller = "Rounds", action = "index" }
           );

            routes.MapRoute(
               name: "VoteGiven",
               url: "Rounds/CandidatesForRound/{roundId}/{candidateId}",
               defaults: new { controller = "Rounds", action = "VoteGiven" }
           );
        }
    }
}
