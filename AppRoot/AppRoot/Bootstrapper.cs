using AppRoot.Views;
using AppRoot.Module.GoogleMap;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;
using System.Linq;
using System.Windows;
using AppRoot.Module.Calender.Views;
using AppRoot.Module.Calender;

namespace AppRoot
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return this.Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            ((Window)this.Shell).Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            var catalog = (ModuleCatalog)this.ModuleCatalog;
            catalog.AddModule(typeof(GoogleMapModule));
            catalog.AddModule(typeof(CalenderModule));

            //this.Container.RegisterTypes(
            //  AllClasses.FromLoadedAssemblies()
            //      .Where(x => x.Namespace.EndsWith(".Views")),
            //  getFromTypes: _ => new[] { typeof(object) },
            //  getName: WithName.TypeName);
        }
    }
}
