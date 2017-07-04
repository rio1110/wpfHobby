using AppRoot.Models;
using AppRoot.Module.Calender.Views;
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
        private const string _webName = "Web関連";

        private const string _googleMap = "Google Map";

        private const string _calenderName = "カレンダー";

        private const string _weeklyUnit = "１週間単位";

        private const string _monthlyUnit = "１カ月単位";

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
                     this.SetProperty(ref this.selectedItem, value);

                string str = ((Category)this.SelectedItem).Name;

                    switch (str)
                    {
                        case _googleMap:
                            this.RegionManager.RequestNavigate("MainRegion", nameof(GoogleMapUC));
                            break;

                        case _weeklyUnit:
                        case _monthlyUnit:
                            this.RegionManager.RequestNavigate("MainRegion", nameof(CalenderUC));
                            break;
                    }
                }
        }


        public ShellViewModel()
        {
            // TreeViewModelのリスト作成
            this.Category = new List<Category> {
                new Category
                {
                    Name = _webName,
                    Children = new List<Category>
                    {
                        new Category {Name = _googleMap}
                    }
                },
                 new Category
                {
                    Name = _calenderName,
                    Children = new List<Category>
                    {
                        new Category { Name = _weeklyUnit },
                        new Category { Name = _monthlyUnit }
                    }
                }
            };

        }


    }
}
