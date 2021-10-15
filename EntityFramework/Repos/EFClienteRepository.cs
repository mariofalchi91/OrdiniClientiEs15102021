using Core.Entita;
using Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework.Repos
{
    public class EFClienteRepository : IClienteRepository
    {
        private Context c;
        public EFClienteRepository()
        {
            c = new Context();
        }
        public bool Add(Cliente newItem)
        {
            if (newItem == null)
                return false;

            try
            {
                c.Clienti.Add(newItem);
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
                var clienteDaEliminare = c.Clienti.Find(id);

                if (clienteDaEliminare != null)
                    c.Clienti.Remove(clienteDaEliminare);

                c.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Cliente item)
        {
            if (item == null)
                return false;

            try
            {
                c.Clienti.Update(item);
                c.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Cliente> Fetch(Func<Cliente, bool> filter = null)
        {
            if (filter != null)
                return c.Clienti.Where(filter).ToList();

            return c.Clienti.ToList();
        }

        public Cliente GetById(int id)
        {
            if (id <= 0)
                return null;

            return c.Clienti.Find(id);
        }
    }
}
