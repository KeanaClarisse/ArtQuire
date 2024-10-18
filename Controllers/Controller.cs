using Manager.Services;
using Microsoft.AspNetCore.Mvc;
using static Model.ClientModel;

namespace ArtQuire.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Controller : ControllerBase
    {
        private readonly IClientService _clientService;

        public Controller(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Client>> GetClient()
        {
            return Ok(_clientService.GetAllClients());
        }

        [HttpGet("{id}")]
        public ActionResult<Client> GetStudent(int id)
        {
            var student = _clientService.GetClientById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public ActionResult AddClient(Client client)
        {
            _clientService.AddClient(client);
            return CreatedAtAction(nameof(GetStudent), new { id = client.Id }, client);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClient(int id, Client client)
        {
            var existingClient = _clientService.GetClientById(id);
            if (existingClient == null)
            {
                return NotFound();
            }

            _clientService.UpdateClient(id, client);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var client = _clientService.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }

            _clientService.DeleteClient(id);
            return NoContent();
        }
    }
}