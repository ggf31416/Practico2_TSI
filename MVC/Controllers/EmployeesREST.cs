using Newtonsoft.Json;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MVC.Controllers
{
    public class EmployeesREST
    {
        readonly string baseUri = "http://localhost:50718/api/employee";

        public List<EmployeeDTO> GetEmployees()
        {
            string uri = baseUri;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                return Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<EmployeeDTO>>(response.Result)).Result;
            }
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            string uri = baseUri + id;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                return Task.Factory.StartNew(() => JsonConvert.DeserializeObject<EmployeeDTO>(response.Result)).Result; // new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All }
            }
        }

        public void AddEmployee(EmployeeDTO emp)
        {
            string uri = baseUri;
            
            using (WebClient web = new WebClient()) { 
            
                var dataString = JsonConvert.SerializeObject(emp);
                web.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                web.UploadString(new Uri(uri), "POST", dataString);
            }
            /*using (HttpClient httpClient = new HttpClient())
            {
                var response =  httpClient.PostAsJsonAsync(uri, emp).Result;
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response.ReasonPhrase);
                }
                
            }*/
        }

        

    }
}