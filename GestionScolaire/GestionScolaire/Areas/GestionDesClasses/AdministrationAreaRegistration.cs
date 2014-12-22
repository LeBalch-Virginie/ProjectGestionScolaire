using System.Web.Mvc;

namespace GestionScolaire.Areas.GestionDesClasses
{
    public class GestionDesClassesAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GestionDesClasses";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GestionDesClasses_default",
                "GestionDesClasses/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
