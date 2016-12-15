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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        reversiEntities context = new reversiEntities();
        CollectionViewSource racuniViewSource;
        CollectionViewSource viewracuniViewSource;
        public MainWindow()
        {
            InitializeComponent();
            racuniViewSource = ((CollectionViewSource)(FindResource("racuniViewSource")));
            viewracuniViewSource = ((CollectionViewSource)(FindResource("viewracuniViewSource")));
            DataContext = new MainViewModel();
        }
        private void DodajRobuHandler(object sender, RoutedEventArgs e)
        {
            int brojrobe = context.roba.ToList().Count;
            robaDataGrid.CanUserAddRows = true;
            robaDataGrid.Focus();
            robaDataGrid.CurrentCell = new DataGridCellInfo(robaDataGrid.Items[brojrobe], robaDataGrid.Columns[0]);
      //      robaDataGrid.SelectedCells.Add(robaDataGrid.CurrentCell);
            robaDataGrid.BeginEdit();
            DodajRobu.IsEnabled = false;
            SnimiRobu.IsEnabled = true;
        }
        private void SnimiRobuHandler(object sender, RoutedEventArgs e)
        {
            DodajRobu.IsEnabled = true;
            SnimiRobu.IsEnabled = false;
            context.SaveChanges();
            var keyEventArgs = new KeyEventArgs(InputManager.Current.PrimaryKeyboardDevice, PresentationSource.FromDependencyObject(robaDataGrid), System.Environment.ProcessorCount, Key.Return);
            keyEventArgs.RoutedEvent = UIElement.KeyDownEvent;
            robaDataGrid.RaiseEvent(keyEventArgs);
            robaDataGrid.CanUserAddRows = false;
        }
        private void robaDataGrid_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!robaDataGrid.IsKeyboardFocusWithin && robaDataGrid.CanUserAddRows)
            {
                robaDataGrid.CanUserAddRows = false;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
 
            context.racuni.Load();
            context.viewracuni.Load();

  
            racuniViewSource.Source = context.racuni.Local;
            viewracuniViewSource.Source = context.viewracuni.Local;            
        }
    }
}