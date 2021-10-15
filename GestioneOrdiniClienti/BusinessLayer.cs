using BiblioCore;
using Core.Entita;
using Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestioneOrdiniClienti
{
    public class BusinessLayer:IBusinessLayer
    {
        private IOrdineRepository ordineRepo;
        private IClienteRepository clienteRepo;
        public BusinessLayer(IOrdineRepository repoO, IClienteRepository repoC)
        {
            ordineRepo = repoO;
            clienteRepo = repoC;
        }
        public BusinessLayer()
        {
            ordineRepo = DependencyContainer.Resolve<IOrdineRepository>();
            clienteRepo = DependencyContainer.Resolve<IClienteRepository>();
        }

        #region CLIENTI
        public List<Cliente> GetAllClienti(Func<Cliente,bool> filter=null)
        {
            if (filter != null)
                return clienteRepo.Fetch().Where(filter).ToList();

            return clienteRepo.Fetch();
        }

        public Cliente GetClienteById(int id)
        {
            if (id <= 0)
                return null;

            return clienteRepo.GetById(id);
        }

        public bool CreateNewCliente(Cliente newCliente)
        {
            if (newCliente == null)
                return false;

            return clienteRepo.Add(newCliente);
        }

        public bool EditCliente(Cliente cliente)
        {
            if (cliente == null)
                return false;

            return clienteRepo.Edit(cliente);
        }

        public bool DeleteClienteById(int id)
        {
            if (id <= 0)
                return false;

            Cliente clienteDaEliminare = clienteRepo.GetById(id);

            if (clienteDaEliminare == null)
                return false;

            return clienteRepo.DeleteById(id);
        }

        #endregion

        #region ORDINI

        public List<Ordine> GetAllOrdini(Func<Ordine, bool> filter = null)
        {
            if (filter != null)
                return ordineRepo.Fetch().Where(filter).ToList();

            return ordineRepo.Fetch();
        }

        public Ordine GetOrdineById(int id)
        {
            if (id <= 0)
                return null;

            return ordineRepo.GetById(id);
        }

        public bool CreateNewOrdine(Ordine newOrdine)
        {
            if (newOrdine == null)
                return false;

            return ordineRepo.Add(newOrdine);
        }

        public bool EditOrdine(Ordine ordine)
        {
            if (ordine == null)
                return false;

            return ordineRepo.Edit(ordine);
        }

        public bool DeleteOrdineById(int id)
        {
            if (id <= 0)
                return false;

            Ordine ordineDaEliminare = ordineRepo.GetById(id);

            if (ordineDaEliminare == null)
                return false;

            return ordineRepo.DeleteById(id);
        }
        #endregion
    }
}
