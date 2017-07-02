using AppRoot.Models;
using AppRoot.Module.GoogleMap.Views;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace AppRoot.ViewModels
{
    class ShellViewModel : BindableBase
    {
        [Dependency]
        public IRegionManager RegionManager { get; set; }

        private List<Category> category;

        public List<Category> Category
        {
            get { return this.category; }
            set { this.SetProperty(ref this.category, value); }
        }

        private object selectedItem;

        public object SelectedItem
        {
            get { return this.selectedItem; }
            set {
                    if (this.SetProperty(ref this.selectedItem, value))
                    {
                        this.RegionManager.RequestNavigate("MainRegion", nameof(GoogleMapUC));
                    };
                }
        }


        public ShellViewModel()
        {
            // TreeViewModelのリスト作成
            this.Category = new List<Category> {
                new Category
                {
                    Name = "Web関連",
                    Children = new List<Category>
                    {
                        new Category {Name = "Google Map"}
                    }
                },
                 new Category
                {
                    Name = "カレンダー",
                    Children = new List<Category>
                    {
                        new Category { Name = "１週間単位" },
                        new Category { Name = "１カ月単位" }
                    }
                }
            };

            this.GoogleMapCommand = new DelegateCommand<string>(x =>
            {
                this.RegionManager.RequestNavigate("MainRegion", nameof(GoogleMapUC), new NavigationParameters($"id ={x}"));
            });
        }

        public DelegateCommand<string> GoogleMapCommand { get; }


    }
}
