using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using PetTracker.Api.Model;
using System;
using System.Collections.Generic;

namespace PetTracker.Api.Repository
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly string connectionString;

        public AnimalRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("ConnectionStrings:mysql");
        }

        public void CadastrarAnimal(Animal animal)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                bool SRD = false;
                SRD = animal.SRD;
                string query = @"insert into tbl_animal (Tipo, Raca, SRD, Nome, Idade, Porte,Sexo) values('" + animal.Tipo + "', '"
                    + animal.Raca + "', " + SRD + ", '" + animal.Nome + "', " + animal.Idade + ", '" + animal.Porte + "', '" + animal.Sexo + "')";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Done.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Animal> ListarAnimais(Animal animal)
        {
            try
            {
                List<Animal> listaAnimais = new List<Animal>();
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string query = "select * from tbl_animal";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Animal animalLista = new Animal();
                    animalLista.Id = int.Parse(reader["Id"].ToString());
                    animalLista.Tipo = reader["Tipo"].ToString();
                    animalLista.Raca = reader["Raca"].ToString();
                    animalLista.SRD = (bool)reader["SRD"];
                    animalLista.Nome = reader["Nome"].ToString();
                    animalLista.Idade = int.Parse(reader["Idade"].ToString());
                    animalLista.Porte = reader["Porte"].ToString();
                    animalLista.Sexo = reader["Sexo"].ToString();

                    listaAnimais.Add(animalLista);
                }
                conn.Close();
                Console.WriteLine("Done.");
                return listaAnimais;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Animal ListarAnimalPorId(int Id)
        {
            try
            {
                Animal animalLista = new Animal();
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string query = "select * from tbl_animal where Id = " + Id + "";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    animalLista.Id = int.Parse(reader["Id"].ToString());
                    animalLista.Tipo = reader["Tipo"].ToString();
                    animalLista.Raca = reader["Raca"].ToString();
                    animalLista.SRD = (bool)reader["SRD"];
                    animalLista.Nome = reader["Nome"].ToString();
                    animalLista.Idade = int.Parse(reader["Idade"].ToString());
                    animalLista.Porte = reader["Porte"].ToString();
                    animalLista.Sexo = reader["Sexo"].ToString();
                }
                conn.Close();
                Console.WriteLine("Done.");
                return animalLista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AtualizarAnimal(Animal animal)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                bool SRD = false;
                SRD = animal.SRD;
                string query = @"update tbl_animal SET Tipo = '" + animal.Tipo + "', Raca = '" + animal.Raca + "' , SRD = " + SRD + ", Nome = '" + animal.Nome + "' , Idade = "
                    + animal.Idade + ", Porte = '" + animal.Porte + "', Sexo = '" + animal.Sexo + "' where Id = " + animal.Id + "";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Done.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeletarAnimal(int Id)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string query = "delete from tbl_animal where Id = " + Id + "";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Done.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
