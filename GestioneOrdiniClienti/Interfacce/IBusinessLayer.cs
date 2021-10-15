using Core.Entita;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfacce
{
    public interface IBusinessLayer
    {
        // clienti
        List<Cliente> GetAllClienti(Func<Cliente, bool> filter = null);
        Cliente GetClienteById(int id);
        bool CreateNewCliente(Cliente newCliente);
        bool EditCliente(Cliente cliente);
        bool DeleteClienteById(int id);
        
        // ordini
        List<Ordine> GetAllOrdini(Func<Ordine, bool> filter = null);
        Ordine GetOrdineById(int id);
        bool CreateNewOrdine(Ordine newOrdine);
        bool EditOrdine(Ordine ordine);
        bool DeleteOrdineById(int id);
    }
}
