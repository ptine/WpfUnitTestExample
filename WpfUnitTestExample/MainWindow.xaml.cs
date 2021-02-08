using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfUnitTestExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel viewModel = new ViewModel();

        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = viewModel;            
        }
        
        private void lstPlaces_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //set  all places as available
            for (int i = 0; i < viewModel.Positions.Length; i++)
            {
                viewModel.Positions[i] = false;
            }

            foreach (int item in lstPlaces.SelectedItems)
            {
                //if item is selected, place at the same index is set to occupied
                viewModel.Positions[item] = true;
            }

            //let's check result
            viewModel.CheckResult();
        }
        
    }
}
