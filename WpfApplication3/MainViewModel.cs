using GalaSoft.MvvmLight;

namespace WpfApplication3
{
    public class MainViewModel : ViewModelBase
    {
        private readonly DAL _dal;

        public KupcisViewModel Kupcis { get; }

        public MainViewModel()
        {
            _dal = new DAL();
            Kupcis = new KupcisViewModel(_dal);
        }
    }
}