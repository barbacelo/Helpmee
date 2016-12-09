using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication3
{
    public class DAL
    {
        private readonly reversiEntities _context = new reversiEntities();

        public DAL()
        {

        }

        public List<kupci> GetKupci()
        {
            return _context.Set<kupci>().ToList();
        }

        public void Save(kupci kupci)
        {
            try
            {
                var existing = _context.kupci.FirstOrDefault(x => x.idbroj == kupci.idbroj);

                if (existing == null)
                    _context.kupci.Add(kupci);
                else
                    _context.Entry(existing).CurrentValues.SetValues(kupci);

                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbx)
            {
                foreach (var er in dbx.EntityValidationErrors)
                    MessageBox.Show(string.Join(Environment.NewLine, er.ValidationErrors.Select(x => x.PropertyName + ": " + x.ErrorMessage)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}