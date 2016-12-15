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
        public void Delete(kupci kupci)
        {
            var existing = _context.kupci.FirstOrDefault(x => x.idbroj == kupci.idbroj);

            if (existing != null)
                _context.kupci.Remove(kupci);
        }
        public void DeleteRoba(roba roba)
        {
            var existing = _context.roba.FirstOrDefault(x => x.idbroj == roba.idbroj);

            if (existing != null)
                _context.roba.Remove(roba);
        }

        private readonly reversiEntities _context = new reversiEntities();

        public DAL()
        {

        }

        public List<kupci> GetKupci()
        {
            return _context.Set<kupci>().ToList();
        }
        public List<roba> GetRoba()
        {
            return _context.Set<roba>().ToList();
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
        public void SaveRoba(roba roba)
        {
            try
            {
                var existing = _context.roba.FirstOrDefault(x => x.idbroj == roba.idbroj);

                if (existing == null)
                    _context.roba.Add(roba);
                else
                    _context.Entry(existing).CurrentValues.SetValues(roba);

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