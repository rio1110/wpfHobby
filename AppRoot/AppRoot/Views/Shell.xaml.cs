using AppRoot.Models;
using AppRoot.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AppRoot.Views
{
    /// <summary>
    /// Shell.xaml の相互作用ロジック
    /// </summary>
    public partial class Shell : Window
    {
        private ShellViewModel vm = new ShellViewModel();

        public Shell()
        {
            InitializeComponent();

            // 動的時計
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += (s, e) =>
            {
                this.TxtClock.Content = DateTime.Now.ToString("H:mm:ss");
            };

            timer.Start();

        //    // TreeViewModelの作成
        //    this.treeView.ItemsSource = new List<Category> {
        //        new Category
        //        {
        //            Name = "Web関連",
        //            Children = new List<Category>
        //            {
        //                new Category {Name = "Google Map"}
        //            }
        //        },
        //         new Category
        //        {
        //            Name = "カレンダー",
        //            Children = new List<Category>
        //            {
        //                new Category { Name = "１週間単位" },
        //                new Category { Name = "１カ月単位" }
        //            }
        //        }
        //    };
        }
    }
}
