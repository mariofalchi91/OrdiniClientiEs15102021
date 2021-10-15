using Core.Entita;
using Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework.Repos
{
    public class EFOrdineRepository : IOrdineRepository
    {
        private Context c;
        public EFOrdineRepository()
        {
            c = new Context();
        }
        public bool Add(Ordine newItem)
        {
            if (newItem == null)
                return false;

            try
            {
                c.Ordini.Add(newItem);
                c.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteById(int id)
        {
            if (id <= 0)
                return false;

            try
            {
                var ordineDaEliminare = c.Ordini.Find(id);

                if (ordineDaEliminare != null)
                    c.Ordini.Remove(ordineDaEliminare);

                c.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Ordine item)
        {
            if (item == null)
                return false;

            try
            {
                c.Ordini.Update(item);
                c.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Ordine> Fetch(Func<Ordine, bool> filter = null)
        {
            if (filter != null)
                return c.Ordini.Where(filter).ToList();

            return c.Ordini.ToList();
        }

        public Ordine GetById(int id)
        {
            if (id <= 0)
                return null;

            return c.Ordini.Find(id);
        }
    }
}
