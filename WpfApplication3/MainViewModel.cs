using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Data.Entity;
using System.Data.Entity.Validation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace WpfApplication3
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand SaveCommand => new RelayCommand(Save);

        private ObservableCollection<KupciViewModel> _kupcis;
        public ObservableCollection<KupciViewModel> Kupcis
        {
            get { return _kupcis; }
            set
            {
                _kupcis = value;
                RaisePropertyChanged();
            }
        }

        private readonly DAL _dal;

        public MainViewModel()
        {
            _dal = new DAL();

            Kupcis = new ObservableCollection<KupciViewModel>(_dal.GetKupci().Select(x => new KupciViewModel(x)));
        }

        private void Save()
        {
            foreach (var k in Kupcis)
                _dal.Save(k.GetModel());
        }
    }
}