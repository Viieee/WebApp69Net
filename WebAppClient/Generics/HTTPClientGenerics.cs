using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebAppClient.Generics
{
    // the main reference for using jwt token
    public class HTTPClientGenerics<Entity>
        where Entity : class
    {
        string EndPoint; // setting dynamic end point
        public HTTPClientGenerics(string EndPoint)
        {
            this.EndPoint = EndPoint;
        }
        string BaseUrl = "https://localhost:44364/api/";
        // getting all data 
        public IEnumerable<Entity> Get(string token = null) // setting the default value of the token to be null
        {
            IEnumerable<Entity> entity = null;
            using (var client = new HttpClient())
            {
                if (token != null)
                {
                    // if token is provided, use token on request header
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                client.BaseAddress = new Uri(BaseUrl);
                // http get
                var responseTask = client.GetAsync(EndPoint);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    // if successful, get the response 
                    var resultJson = result.Content.ReadAsStringAsync();
                    resultJson.Wait();
                    // parsing the json
                    JObject objectResult = JObject.Parse(resultJson.Result);
                    JArray data = (JArray)objectResult["data"];
                    // converting json into .net type (in this case its ienumerable, so we use List inside the <>)
                    entity = JsonConvert.DeserializeObject<List<Entity>>(JsonConvert.SerializeObject(data));
                }
                else
                {
                    // if not successful, return empty ienumerable with entity type
                    entity = Enumerable.Empty<Entity>();
                }
                return entity;
            }
        }

        // get by id 
        public Entity Get(int? id, string token = null)
        {
            Entity entity = null;
            using (var client = new HttpClient())
            {
                if (token != null)
                {
                    // if token is provided, use token on request header
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                client.BaseAddress = new Uri(BaseUrl);
                var responseTask = client.GetAsync($"{EndPoint}/{id.ToString()}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    // if successful, get the response 
                    var resultJson = result.Content.ReadAsStringAsync();
                    resultJson.Wait();
                    // parsing the json
                    JObject objectResult = JObject.Parse(resultJson.Result);
                    JObject data = (JObject)objectResult["data"];
                    // converting json into .net type (in this case its the entity's type)
                    entity = JsonConvert.DeserializeObject<Entity>(JsonConvert.SerializeObject(data));
                }
                else
                {
                    // if not successful, return null
                    entity = null;
                }
            }
            return entity;
        }

        // post 
        public string Create(Entity entity, string token = null)
        {
            string StatusCode = null;
            using (var client = new HttpClient())
            {
                if (token != null)
                {
                    // if token is provided, use token on request header
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                client.BaseAddress = new Uri(BaseUrl);
                var postTask = client.PostAsJsonAsync<Entity>(EndPoint, entity);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    // if operation is successful
                    var resultJson = result.Content.ReadAsStringAsync();
                    resultJson.Wait();
                    JObject objectResult = JObject.Parse(resultJson.Result);
                    // returning the status code
                    StatusCode = objectResult.SelectToken("status").Value<string>();
                }
            }
            return StatusCode;
        }

        // put
        public string Edit(Entity entity, int id, string token = null)
        {
            string StatusCode = null;
            using (var client = new HttpClient())
            {
                if (token != null)
                {
                    // if token is provided, use token on request header
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                client.BaseAddress = new Uri(BaseUrl);

                // edit task
                var putTask = client.PutAsJsonAsync<Entity>($"{EndPoint}/{id.ToString()}", entity);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    // if operation is successful
                    var resultJson = result.Content.ReadAsStringAsync();
                    resultJson.Wait();
                    JObject objectResult = JObject.Parse(resultJson.Result);
                    // returning the status code
                    StatusCode = objectResult.SelectToken("status").Value<string>();
                }
            }
            return StatusCode;
        }

        // delete
        public string Delete(int? id, string token = null)
        {
            string StatusCode = null;
            using (var client = new HttpClient())
            {
                if (token != null)
                {
                    // if token is provided, use token on request header
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                client.BaseAddress = new Uri(BaseUrl);
                // delete task 
                var deleteTask = client.DeleteAsync($"{EndPoint}/{id.ToString()}");
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    // if operation is successful
                    var resultJson = result.Content.ReadAsStringAsync();
                    resultJson.Wait();
                    JObject objectResult = JObject.Parse(resultJson.Result);
                    // returning the status code
                    StatusCode = objectResult.SelectToken("status").Value<string>();
                }
            }
            return StatusCode;
        }
    }
}
