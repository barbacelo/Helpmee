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
        private ObservableCollection<kupci> _kupcis;

        public ObservableCollection<kupci> Kupcis
        {
            get { return _kupcis; }
            set
            {
                _kupcis = value;
                RaisePropertyChanged();
            }
        }

        public MainViewModel()
        {
            var dal = new DataAcess();

            Kupcis = new ObservableCollection<kupci>(dal.GetKupci());
        }
    }
}