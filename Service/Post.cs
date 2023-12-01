using Newtonsoft.Json;
using Social_App.Model;
using Social_App.Service.Iservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_App.Service
{
    public class Post : IPost
    {
        private readonly HttpClient _httpClient;
        private readonly string URL = "https://jsonplaceholder.typicode.com/posts";
        public Post()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<PostModel>> GetPost(int id)
        {
            //URL + "/" + id
            var resp = await _httpClient.GetAsync(URL);
            var content = await resp.Content.ReadAsStringAsync();
            List<PostModel> posts = JsonConvert.DeserializeObject <List<PostModel>>(content);
            List<PostModel> postUserList = posts.Where(element => element.userId == $"{id}").ToList();
            if (resp.IsSuccessStatusCode && posts != null)
            {
                foreach (var userpost in postUserList)
                {
                    Console.WriteLine($"{userpost.id}:{userpost.title}");
                    return posts;
                }
            }
            else
            {
                Console.WriteLine("User Post does not exists");
            }
            return posts;
        }
    }

}
