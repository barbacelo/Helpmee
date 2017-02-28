using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3
{
    public class RevRobasViewModel : ViewModelBase
    {
        private readonly DAL _dal;
        private RevRobaViewModel _selectedRevRoba;

        public RevRobaViewModel SelectedRevRoba
        {
            get { return _selectedRevRoba; }
            set
            {
                _selectedRevRoba = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<RevRobaViewModel> RevRobas { get; }

        public RevRobasViewModel(DAL dal)
        {
            _dal = dal;
            RevRobas = new ObservableCollection<RevRobaViewModel>(_dal.GetRevRoba().Select(x => new RevRobaViewModel(x)).ToList());
        }
    }
}
