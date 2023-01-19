using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace CretaceousClient.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }

        public static AnimalPage GetAnimals()
        {
            var apiCallTask = ApiHelper.GetAll();
            var result = apiCallTask.Result;
            string content = result["pagination"];
            //JObject jsonPagination = JsonConvert.DeserializeObject<JObject>>(content);
            Paging pagingList = JsonConvert.DeserializeObject<Paging>(result["pagination"]);
            
            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result["content"]);
            List<Animal> animalList = JsonConvert.DeserializeObject<List<Animal>>(jsonResponse.ToString());
            AnimalPage ap = new AnimalPage();
            ap.Pagings = pagingList;
            ap.Animals = animalList;
            return ap;
        }

        public static Animal GetDetails(int id)
        {
            var apiCallTask = ApiHelper.Get(id);
            var result = apiCallTask.Result;

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            Animal animal = JsonConvert.DeserializeObject<Animal>(jsonResponse.ToString());

            return animal;
        }

        public static void Post(Animal animal)
        {
            string jsonAnimal = JsonConvert.SerializeObject(animal);
            ApiHelper.Post(jsonAnimal);
        }

        public static void Put(Animal animal)
        {
            string jsonAnimal = JsonConvert.SerializeObject(animal);
            ApiHelper.Put(animal.AnimalId, jsonAnimal);
        }

        public static void Delete(int id)
        {
            ApiHelper.Delete(id);
        }
    }
}