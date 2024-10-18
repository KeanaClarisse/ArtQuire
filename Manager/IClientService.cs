using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.ClientModel;

namespace Manager.Services
{
    public interface IClientService
    {
        IEnumerable<Client> GetAllClients();
        Client GetClientById(int id);
        void AddClient(Client client);
        void UpdateClient(int id, Client client);
        void DeleteClient(int id);
    }
}
