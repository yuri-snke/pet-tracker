using Microsoft.AspNetCore.Mvc;
using PetTracker.Api.Model;
using PetTracker.Api.Repository;

namespace PetTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AnimaisController : ControllerBase
    {
        private readonly IAnimalRepository _repository;

        public AnimaisController(IAnimalRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("cadastraranimal")]
        public IActionResult CadastrarAnimal([FromBody] Animal animal)
        {
            _repository.CadastrarAnimal(animal);
            return Ok();
        }

        [HttpGet("listaranimais")]
        public IActionResult ListarAnimais([FromQuery] Animal animal)
        {
            var retornoListaAnimais = _repository.ListarAnimais(animal);

            return Ok(retornoListaAnimais);
        }

        [HttpGet("listaranimais/{id}")]
        public IActionResult ListarAnimalPorId(int Id)
        {
            var retornoAnimalId = _repository.ListarAnimalPorId(Id);
            return Ok(retornoAnimalId);
        }

        [HttpPut("atualizaranimal")]
        public IActionResult AtualizarAnimal([FromBody] Animal animal)
        {
            _repository.AtualizarAnimal(animal);
            return Ok();
        }

        [HttpDelete("deletaranimal/{Id}")]
        public IActionResult DeletarAnimal(int Id)
        {
            _repository.DeletarAnimal(Id);
            return Ok();
        }
    }
}
