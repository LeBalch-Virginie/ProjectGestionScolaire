using System.Web.Mvc;

namespace GestionScolaire.Areas.Eleves
{
    public class ElevesAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Eleves";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Eleves_default",
                "Eleves/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
