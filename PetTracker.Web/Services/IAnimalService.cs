using PetTracker.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetTracker.Web.Repository
{
    public interface IAnimalService
    {
        Task CadastrarAnimal(Animal animal);

        Task<List<Animal>> ListarAnimais(Animal animal);

        Task<Animal> ListarAnimalPorId(int Id);

        Task DeletarAnimal(int Id);

        Task EditarAnimal(Animal animal);
    }
}
