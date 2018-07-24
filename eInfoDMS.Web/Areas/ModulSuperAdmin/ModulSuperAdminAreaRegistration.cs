using System.Web.Mvc;

namespace eInfoDMS.Web.Areas.ModulSuperAdmin
{
    public class ModulSuperAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ModulSuperAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ModulSuperAdmin_default",
                "ModulSuperAdmin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}