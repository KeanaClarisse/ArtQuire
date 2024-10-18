using Manager.Services;
using static Model.ClientModel;

namespace SampleManager.Managers
{
    public class ClientManager : IClientService
    {
        //Temporary data for testing before database connections
        private readonly List<Client> _client = new List<Client>
        {
            new Client { Id = 1, FirstName = "Keana", LastName = "Consebido", Email = "kconsebido@gmail.com" },
            new Client { Id = 2, FirstName = "Clarisse", LastName = "Encarnacion", Email = "clariincarnation@gmail.com" }
        };

        //Function that displays all clients within the list
        public IEnumerable<Client> GetAllClients()
        {
            return _client;
        }
        //Function to display the details of the client if there is a matching Id
        public Client GetClientById(int id)
        {
            return _client.FirstOrDefault(s => s.Id == id);
        }
        //Function that displays adds a clients to the list
        public void AddClient(Client client)
        {
            client.Id = _client.Max(s => s.Id) + 1;
            _client.Add(client);
        }
        //Function that update a client's information if it exists
        public void UpdateClient(int id, Client client)
        {
            var existingClient = _client.FirstOrDefault(s => s.Id == id);
            if (existingClient != null)
            {
                existingClient.FirstName = client.FirstName;
                existingClient.LastName = client.LastName;
                existingClient.Email = client.Email;
            }
        }
        //Function that deletes a client from the list
        public void DeleteClient(int id)
        {
            var student = _client.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _client.Remove(student);
            }
        }
    }
}
