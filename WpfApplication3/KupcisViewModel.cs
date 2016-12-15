﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace WpfApplication3
{
    public class KupcisViewModel : ViewModelBase
    {
        private readonly DAL _dal;
        private KupciViewModel _selectedKupci;

        public ICommand SaveCommand => new RelayCommand(Save, CanSave);
        public ICommand DeleteCommand => new RelayCommand(Delete, CanDelete);
        public ICommand AddCommand => new RelayCommand<DataGrid>(Add);

        public KupciViewModel SelectedKupci
        {
            get { return _selectedKupci; }
            set
            {
                _selectedKupci = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<KupciViewModel> Kupcis { get; }

        public KupcisViewModel(DAL dal)
        {
            _dal = dal;
            Kupcis = new ObservableCollection<KupciViewModel>(_dal.GetKupci().Select(x => new KupciViewModel(x)).ToList());
        }

        private bool CanSave()
        {
            return Kupcis.Any(x => x.Changed);
        }

        private void Save()
        {
            var deleted = new List<KupciViewModel>();

            foreach (var k in Kupcis.Where(x => x.Changed))
            {
                if (k.IsDeleted)
                {
                    deleted.Add(k);
                    _dal.Delete(k.GetModel());
                }
                else
                {
                    _dal.Save(k.GetModel());
                    k.Changed = false;
                }
            }

            foreach (var d in deleted)
                Kupcis.Remove(d);
        }
        private bool CanDelete()
        {
            if (SelectedKupci == null)
                return false;

            if (SelectedKupci.IsDeleted)
                return false;

            return true;
        }
        private void Delete()
        {
            if (SelectedKupci == null)
                return;

            SelectedKupci.IsDeleted = true;
        }

        private void Add(DataGrid grid)
        {
            Kupcis.Add(new KupciViewModel());

            var brojkupaca = Kupcis.Count - 1;
            grid.SelectionUnit = DataGridSelectionUnit.Cell;
            grid.Focus();
            grid.CurrentCell = new DataGridCellInfo(grid.Items[brojkupaca], grid.Columns[0]);
            grid.BeginEdit();
            grid.SelectionUnit = DataGridSelectionUnit.FullRow;
        }
    }
}