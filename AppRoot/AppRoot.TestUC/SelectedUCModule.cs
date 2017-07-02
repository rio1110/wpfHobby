using AppRoot.TestUC.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRoot.TestUC
{
    class SelectedUCModule
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
                this.Container.RegisterType<object, SelectedUC>(nameof(SelectedUC));

                //this.RegionManager.RequestNavigate("MainRegion", nameof(SelectedUC));
            }
        }
    }
}
