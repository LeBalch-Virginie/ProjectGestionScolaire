using System.Web.Mvc;

namespace GestionScolaire.Areas.Eval
{
    public class EvalAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Eval";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Eval_default",
                "Eval/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
