using MVCDIDemo.Components;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCDIDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            // RegisterCustomControllerFactory();
            RegisterMef();
        }

        private void RegisterCustomControllerFactory()
        {
            // IControllerFactory factory = new CustomControllerFactory("Mvc4.Controllers");
            IControllerFactory factory = new CustomControllerFactory();
        }

        private void RegisterMef()
        {
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var composition = new CompositionContainer(catalog);
            IControllerFactory mefControllerFactory = new MefControllerFactory(composition);
            ControllerBuilder.Current.SetControllerFactory(mefControllerFactory);
        }
    }
}