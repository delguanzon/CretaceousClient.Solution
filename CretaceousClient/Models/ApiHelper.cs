using System.Threading.Tasks;
using RestSharp;

namespace CretaceousClient.Models
{
    public class ApiHelper
    {
        public static async Task<Dictionary<string, string>> GetAll()
        {
            RestClient client = new RestClient("http://localhost:5000/");
            RestRequest request = new RestRequest($"api/animals", Method.Get);
            RestResponse response = await client.GetAsync(request);

            Dictionary<string, string> responseDict = new Dictionary<string, string>();
            //var pagination = response.Headers.Where(x => x.Name == "totalPages").Select(x => x.Value).ToString();
            var pagination = response.Headers.ToList().Find(x => x.Name == "X-Pagination").Value.ToString();
            responseDict.Add("pagination", pagination);
            responseDict.Add("content", response.Content);
            return responseDict;
        }

        public static async Task<string> Get(int id)
        {
            RestClient client = new RestClient("http://localhost:5000/");
            RestRequest request = new RestRequest($"api/animals/{id}", Method.Get);
            RestResponse response = await client.GetAsync(request);
            return response.Content;
            
        }
        
        public static async void Post(string newAnimal)
        {
            RestClient client = new RestClient("http://localhost:5000/");
            RestRequest request = new RestRequest($"api/animals", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(newAnimal);
            await client.PostAsync(request);
        }

        public static async void Put(int id, string newAnimal)
        {
            RestClient client = new RestClient("http://localhost:5000/");
            RestRequest request = new RestRequest($"api/animals/{id}", Method.Put);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(newAnimal);
            await client.PutAsync(request);
        }

        public static async void Delete(int id)
        {
            RestClient client = new RestClient("http://localhost:5000/");
            RestRequest request = new RestRequest($"api/animals/{id}", Method.Delete);
            request.AddHeader("Content-Type", "application/json");
            await client.DeleteAsync(request);
        }

        
    }
}