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

using Lantern.ViewModels;

namespace Lantern.Views
{
    /// <summary>
    /// Lógica interna para SolutionOne.xaml
    /// </summary>
    public partial class SolutionOne : Window
    {
        private SolutionOneViewModel viewModel = null;
        public SolutionOne()
        {
            InitializeComponent();

            viewModel = new SolutionOneViewModel();
            DataContext = viewModel;
        }

        private void onSairClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
