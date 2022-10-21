using System;
using System.Linq;
using System.Threading.Tasks;
using AppSampleDynamoDb.DataBase;
using AppSampleDynamoDb.Model;
using Microsoft.AspNetCore.Mvc;

namespace AppSampleDynamoDb.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ClienteController : ControllerBase
  {
    private readonly ClienteRepository _clienteRepository;

    public ClienteController(ClienteRepository clienteRepository)
    {
      _clienteRepository = clienteRepository;
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> Save(Cliente cliente)
    {
      cliente.IdCliente = Guid.NewGuid();
      await this._clienteRepository.Save(cliente);
      return Created($"/{cliente.IdCliente}", cliente);
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAll()
    {
      var result = await this._clienteRepository.GetAll();
      return Ok(result);
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> Save(Guid id)
    {
      var result = await this._clienteRepository.GetById(id);

      if (!result.Any())
        return NotFound();

      return Ok(result.FirstOrDefault());
    }


  }
}
