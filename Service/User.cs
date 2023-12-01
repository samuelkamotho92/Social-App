using Newtonsoft.Json;
using Social_App.Model;
using Social_App.Service.Iservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Social_App.Service
{
    public class User: IUser
    {


        private readonly HttpClient _httpClient;
        private readonly string URL = "https://jsonplaceholder.typicode.com/users";

        public User()
        {
            _httpClient = new HttpClient();
        }

        //<List<UserModel>>
        public async Task<List<UserModel>> GetUsers()
        {
            var resp = await _httpClient.GetAsync(URL);
            var content = await resp.Content.ReadAsStringAsync();
            List<UserModel> users = JsonConvert.DeserializeObject<List<UserModel>>(content);
            if (resp.IsSuccessStatusCode && users != null)
            {
                Console.WriteLine("Users Registered");
                foreach (var item in users)
                {
                    Console.WriteLine($"{item.id} :{item.username}");
                }
               
            }
            else
            {
                Console.WriteLine("Users does not exists");
            } 
            //Select a user you want to see
            Console.WriteLine("choose Users you want to see his post");
            int promptVal = int.Parse(Console.ReadLine());
            await GetUser(promptVal);
            return users;
        }

        public async Task GetUser(int id)
        {
            Console.WriteLine($"You choose user {id}");
            Post post = new Post();
             await post.GetPost(id);

            Console.WriteLine("choose Post you want to see the comments");

            int postId = int.Parse(Console.ReadLine());
            Comment comment = new Comment();
           await comment.GetComment(postId);
        }

    }
}
