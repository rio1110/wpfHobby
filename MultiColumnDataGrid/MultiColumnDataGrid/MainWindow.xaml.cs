using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MultiColumnDataGrid
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private ScrollViewer _headerScrollViewer;

        private ScrollViewer _dataGridScrollViewer;

        public MainWindow()
        {
            InitializeComponent();

            InitializeComponent();
            // DataContextにPersonのコレクションを設定する
            DataTable dt = new DataTable();

            dt.Columns.Add("No", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Age", typeof(string));
            dt.Columns.Add("Sex", typeof(string));

            for (int i = 1; i < 200; i++)
            {
                DataRow dr = dt.NewRow();

                dr["No"] = "No" +i;
                dr["Name"] = "Name" + i;
                dr["Age"] = "Age" + i;
                dr["Sex"] = "Sex" + i;
                dt.Rows.Add(dr);
            }

            this.DataContext = dt;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this._headerScrollViewer = this.HeaderScrollViewer;

            this._dataGridScrollViewer = ScrollViewerFromFrameworkElement(this.datagrid1);

            this._dataGridScrollViewer.ScrollChanged += scrollViewer_datagrid1Changed;


        }

        private void scrollViewer_datagrid1Changed(object sender, ScrollChangedEventArgs e)
        {
            if (this._headerScrollViewer == null)
            {
                this._headerScrollViewer.ScrollToVerticalOffset(_dataGridScrollViewer.VerticalOffset);
                this._headerScrollViewer.ScrollToHorizontalOffset(_dataGridScrollViewer.HorizontalOffset);
            }

            if (_headerScrollViewer.HorizontalOffset != _dataGridScrollViewer.HorizontalOffset)
            {
                _headerScrollViewer.ScrollToHorizontalOffset(_dataGridScrollViewer.HorizontalOffset);
            }
        }

        /// <summary>
        /// ScrollViewer取得
        /// </summary>
        /// <param name="frameworkElement"></param>
        /// <returns></returns>
        private ScrollViewer ScrollViewerFromFrameworkElement(FrameworkElement frameworkElement)
        {
            if (VisualTreeHelper.GetChildrenCount(frameworkElement) == 0) return null;

            FrameworkElement child = VisualTreeHelper.GetChild(frameworkElement, 0) as FrameworkElement;

            if (child == null) return null;

            if (child is ScrollViewer)
            {
                return (ScrollViewer)child;
            }

            return ScrollViewerFromFrameworkElement(child);
        }
    }
}
