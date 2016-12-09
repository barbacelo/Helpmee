using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3
{
    class DataAcess
    {
        private reversiEntities context = new reversiEntities();

        public DataAcess()
        {

        }

        public List<kupci> GetKupci()
        {
            return context.Set<kupci>().ToList();
        }
    }
}