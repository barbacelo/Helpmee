using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication3;

namespace WpfApplication3
{

    public class RacuniViewModel : ViewModelBase
    {
        private RobaViewModel _roba;
        private string _brev;
        private DateTime _datum;
        private int _idbrojk;
        private int _idbrojr;
        private decimal _kolu;
        private decimal _kolv;
        private decimal _cena;
        private decimal _utro;

        public bool Changed { get; set; }
        public RobaViewModel Roba
        {
            get { return _roba; }
            set
            {                        
                _roba = value;
                RaisePropertyChanged();
                Changed = true;
                idbrojr = _roba.idbroj;
            }
        }
        public string brev
        {
            get { return _brev; }
            set
            {
                _brev = value;
                RaisePropertyChanged();
                Changed = true;
            }
        }
        public DateTime datum
        {
            get { return _datum; }
            set
            {
                _datum = value;
                RaisePropertyChanged();
                Changed = true;
            }
        }

        public int idbrojk
        {
            get { return _idbrojk; }
            set
            {
                _idbrojk = value;
                RaisePropertyChanged();
                Changed = true;
            }
        }

        public int idbrojr
        {
            get { return _idbrojr; }
            set
            {
                _idbrojr = value;
                RaisePropertyChanged();
                Changed = true;
            }
        }
        public decimal kolu
        {
            get { return _kolu; }
            set
            {
                _kolu = value;
                RaisePropertyChanged();
                Changed = true;
            }
        }
        public decimal kolv
        {
            get { return _kolv; }
            set
            {
                _kolv = value;
                RaisePropertyChanged();
                Changed = true;
            }
        }
        public decimal cena
        {
            get { return _cena; }
            set
            {
                _cena = value;
                RaisePropertyChanged();
                Changed = true;
            }
        }
        public decimal utro
        {
            get { return _utro; }
            set
            {
                _utro = value;
                RaisePropertyChanged();
                Changed = true;
            }
        }

        private readonly racuni _model;

        public RacuniViewModel()
        {
            _model = new racuni();
        }
        public RacuniViewModel(racuni k)
        {
            _model = k;

            brev = k.brev;
            datum = k.datum;
            idbrojk = k.idbrojk;
            idbrojr = k.idbrojr;
            kolu = k.kolu;
            kolv = k.kolv;
            cena = k.cena;
            utro = k.utro;

            Changed = false;
        }


        public racuni GetModel()
        {
            _model.brev = brev;
            _model.datum = datum;
            _model.idbrojk = idbrojk;
            _model.idbrojr = idbrojr;
            _model.kolu = kolu;
            _model.kolv = kolv;
            _model.cena = cena;
            _model.utro = utro;

            return _model;
        }
        private bool _isDeleted;
        public bool IsDeleted
        {
            get { return _isDeleted; }
            set
            {
                _isDeleted = value;
                RaisePropertyChanged();
            }
        }
    }
}