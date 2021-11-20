using PetTracker.Api.Model;
using System.Collections.Generic;

namespace PetTracker.Api.Repository
{
    public interface IAnimalRepository
    {
        void CadastrarAnimal(Animal animal);

        List<Animal> ListarAnimais(Animal animal);

        Animal ListarAnimalPorId(int id);

        void AtualizarAnimal(Animal animal);

        void DeletarAnimal(int Id);
    }
}
