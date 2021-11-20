using Newtonsoft.Json;
using PetTracker.Web.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PetTracker.Web.Repository
{
    public class AnimalService : IAnimalService
    {
        public async Task<List<Animal>> ListarAnimais(Animal animal)
        {
            //Consulta de API Externa
            HttpClient client = new HttpClient();

            var resultado = await client.GetAsync("https://localhost:5001/api/animais/listaranimais");

            var animais = await resultado.Content.ReadAsStringAsync();

            //Deserialização do objeto para lista
            var listaAnimais = JsonConvert.DeserializeObject<List<Animal>>(animais);

            return listaAnimais;
        }

        public async Task CadastrarAnimal(Animal animal)
        {
            HttpClient client = new HttpClient();

            await client.PostAsJsonAsync("https://localhost:5001/api/animais/cadastraranimal/", animal);
        }

        public async Task<Animal> ListarAnimalPorId(int Id)
        {
            HttpClient client = new HttpClient();
            var resultado = await client.GetAsync("https://localhost:5001/api/animais/listaranimais/" + Id);

            var animais = await resultado.Content.ReadAsStringAsync();

            //Deserialização do objeto para lista
            var listaAnimais = JsonConvert.DeserializeObject<Animal>(animais);

            return listaAnimais;
        }

        public async Task DeletarAnimal(int Id)
        {
            HttpClient client = new HttpClient();
            await client.DeleteAsync("https://localhost:5001/api/animais/deletaranimal/" + Id);
        }

        public async Task EditarAnimal(Animal animal)
        {
            HttpClient client = new HttpClient();
            await client.PutAsJsonAsync("https://localhost:5001/api/animais/atualizaranimal/", animal);
        }
    }
}
