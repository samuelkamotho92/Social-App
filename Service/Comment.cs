using Newtonsoft.Json;
using Social_App.Model;
using Social_App.Service.Iservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Social_App.Service
{
    public class Comment :IComment
    {
        private readonly HttpClient _httpClient;
        private readonly string URL = "https://jsonplaceholder.typicode.com/comments";
        public Comment()
        {
            _httpClient = new HttpClient();
        }
        public  async Task<List<CommentModel>> GetComment(int id)
        {
            var resp = await _httpClient.GetAsync(URL);
            var content = await resp.Content.ReadAsStringAsync();
            List<CommentModel> comments = JsonConvert.DeserializeObject<List<CommentModel>>(content);
            List<CommentModel> commentUserList = comments.Where(element => element.postId == id).ToList();
            Console.WriteLine(commentUserList);
            if (resp.IsSuccessStatusCode && commentUserList != null)
            {
                foreach (var comment in commentUserList)
                {
                    Console.WriteLine("User comments are this");
                    Console.WriteLine($"{comment.id}:{comment.body}");
                }
                return commentUserList;
            }
            else
            {
                Console.WriteLine("comment does not exist");
            }
            return comments;
        }
    }
}
