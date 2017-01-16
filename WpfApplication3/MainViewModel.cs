using GalaSoft.MvvmLight;

namespace WpfApplication3
{
    public class MainViewModel : ViewModelBase
    {
        private readonly DAL _dal;

        public KupcisViewModel Kupcis { get; }
        public RobasViewModel Robas { get; }
        public RacunisViewModel Racunis { get; }
        public MainViewModel()
        {
            _dal = new DAL();
            Kupcis = new KupcisViewModel(_dal);

            _dal = new DAL();
            Robas = new RobasViewModel(_dal);

            _dal = new DAL();
            Racunis = new RacunisViewModel(_dal);
        }
    }
}