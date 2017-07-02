using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using AppRoot.Module.GoogleMap.Views;

namespace AppRoot.Module.GoogleMap
{
    public class GoogleMapModule : IModule
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        [Dependency]
        public IRegionManager RegionManager { get; set; }

        public void Initialize()
        {
            //this.Container.RegisterType<MessageProvider>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<object, GoogleMapUC>(nameof(GoogleMapUC));

            //this.RegionManager.RequestNavigate("MainRegion", nameof(GoogleMapUC));
        }
    }
}
