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
        CollectionViewSource kupciViewSource;
        CollectionViewSource racuniViewSource;
        CollectionViewSource robaViewSource;
        CollectionViewSource viewracuniViewSource;
        public MainWindow()
        {
            InitializeComponent();
            kupciViewSource = ((CollectionViewSource)(FindResource("kupciViewSource")));
            robaViewSource = ((CollectionViewSource)(FindResource("robaViewSource")));
            racuniViewSource = ((CollectionViewSource)(FindResource("racuniViewSource")));
            viewracuniViewSource = ((CollectionViewSource)(FindResource("viewracuniViewSource")));
            DataContext = this;
            
            
        }
        private void kupciDataGrid_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!kupciDataGrid.IsKeyboardFocusWithin && kupciDataGrid.CanUserAddRows)
            {
                kupciDataGrid.CanUserAddRows = false;
            }
        }


        private void DodajKupcaHandler(object sender, RoutedEventArgs e)
        {
            int brojkupaca = context.kupci.ToList().Count;
            kupciDataGrid.SelectionUnit = DataGridSelectionUnit.Cell;
            kupciDataGrid.CanUserAddRows = true;
            kupciDataGrid.Focus();            
            kupciDataGrid.CurrentCell = new DataGridCellInfo(kupciDataGrid.Items[brojkupaca], kupciDataGrid.Columns[0]);
      //      kupciDataGrid.SelectedCells.Add(kupciDataGrid.CurrentCell);
            kupciDataGrid.BeginEdit();
            kupciDataGrid.SelectionUnit = DataGridSelectionUnit.FullRow;
            DodajKupca.IsEnabled = false;
            SnimiKupci.IsEnabled = true;
        }
        private void SnimiKupciHandler(object sender, RoutedEventArgs e)
        {
      //      using (var kupcicontext = new reversiEntities())
            DodajKupca.IsEnabled = true;
            SnimiKupci.IsEnabled = false;
            
            context.SaveChanges();
            var keyEventArgs = new KeyEventArgs(InputManager.Current.PrimaryKeyboardDevice, PresentationSource.FromDependencyObject(kupciDataGrid), System.Environment.ProcessorCount, Key.Return);
            keyEventArgs.RoutedEvent = UIElement.KeyDownEvent;
            kupciDataGrid.RaiseEvent(keyEventArgs);
            kupciDataGrid.CanUserAddRows = false;
        }
        private void BrisiKupcaHandler(object sender, RoutedEventArgs e)
        {
            kupci currentIndex = kupciDataGrid.SelectedItem as kupci;
            //  if (currentIndex != null)
            //   {
            context.kupci.Remove(currentIndex);
       //     } 
       //     kupciDataGrid.SelectedCells[0].Item as DataGridRow;
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
            context.kupci.Load();
            context.racuni.Load();
            context.roba.Load();
            context.viewracuni.Load();

            kupciViewSource.Source = context.kupci.Local;
            robaViewSource.Source = context.roba.Local;
            racuniViewSource.Source = context.racuni.Local;
            viewracuniViewSource.Source = context.viewracuni.Local;            
        }
    }
}