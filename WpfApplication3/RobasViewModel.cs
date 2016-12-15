using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace WpfApplication3
{
    public class RobasViewModel : ViewModelBase
    {
        private readonly DAL _dal;
        private RobaViewModel _selectedRoba;

        public ICommand SaveCommand => new RelayCommand(Save, CanSave);
        public ICommand DeleteCommand => new RelayCommand(Delete, CanDelete);
        public ICommand AddCommand => new RelayCommand<DataGrid>(Add);

        public RobaViewModel SelectedRoba
        {
            get { return _selectedRoba; }
            set
            {
                _selectedRoba = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<RobaViewModel> Robas { get; }

        public RobasViewModel(DAL dal)
        {
            _dal = dal;
            Robas = new ObservableCollection<RobaViewModel>(_dal.GetRoba().Select(x => new RobaViewModel(x)).ToList());
        }

        private bool CanSave()
        {
            return Robas.Any(x => x.Changed);
        }

        private void Save()
        {
            var deleted = new List<RobaViewModel>();

            foreach (var k in Robas.Where(x => x.Changed))
            {
                if (k.IsDeleted)
                {
                    deleted.Add(k);
                    _dal.DeleteRoba(k.GetModel());
                }
                else
                {
                    _dal.SaveRoba(k.GetModel());
                    k.Changed = false;
                }
            }

            foreach (var d in deleted)
                Robas.Remove(d);
        }
        private bool CanDelete()
        {
            if (SelectedRoba == null)
                return false;

            if (SelectedRoba.IsDeleted)
                return false;

            return true;
        }
        private void Delete()
        {
            if (SelectedRoba == null)
                return;

            SelectedRoba.IsDeleted = true;
        }

        private void Add(DataGrid grid)
        {
            Robas.Add(new RobaViewModel());

            var brojrobe = Robas.Count - 1;
            grid.SelectionUnit = DataGridSelectionUnit.Cell;
            grid.Focus();
            grid.CurrentCell = new DataGridCellInfo(grid.Items[brojrobe], grid.Columns[0]);
            grid.BeginEdit();
            grid.SelectionUnit = DataGridSelectionUnit.FullRow;
        }
    }
}