using Microsoft.AspNetCore.Mvc;
using PetTracker.Web.Models;
using PetTracker.Web.Repository;
using System.Threading.Tasks;

namespace PetTracker.Web.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalService _service;

        public AnimalController(IAnimalService service)
        {
            _service = service;
        }

        public async Task<IActionResult> ListarAnimais(Animal animal)
        {
            var retornoListaAnimais = await _service.ListarAnimais(animal);
            return View(retornoListaAnimais);
        }

        public IActionResult CadastrarAnimal()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAnimal(Animal animal)
        {
            await _service.CadastrarAnimal(animal);
            return RedirectToAction("ListarAnimais");
        }

        public async Task<IActionResult> DeletarAnimal(int Id, bool? teste = false)
        {
            //await _service.DeletarAnimal(Id);
            var retornoAnimal = await _service.ListarAnimalPorId(Id);
            return View(retornoAnimal);
        }

        [HttpPost]
        public async Task<IActionResult> DeletarAnimal(int Id)
        {
            await _service.DeletarAnimal(Id);
            return RedirectToAction("ListarAnimais");
        }

        public async Task<IActionResult> EditarAnimal(int Id)
        {
            var retornoAnimal = await _service.ListarAnimalPorId(Id);
            return View(retornoAnimal);
        }

        [HttpPost]
        public async Task<IActionResult> EditarAnimal(Animal animal)
        {
            await _service.EditarAnimal(animal);
            return RedirectToAction("ListarAnimais");
        }
    }
}
