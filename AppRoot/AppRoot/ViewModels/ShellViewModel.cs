using AppRoot.Models;
using Microsoft.Practices.Unity;
using Prism.Mvvm;
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
        private Category _category;

        public Category _Category
        {
            get { return this._category; }
            set { this.SetProperty(ref this._category, value); }
        }


        public ShellViewModel()
        {
            // TreeViewModelの作成
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
        }

        private List<Category> category;

        public List<Category> Category
        {
            get { return this.category; }
            set { this.SetProperty(ref this.category, value); }
        }
    }
}
