using Sejlklub23.Helpers;
using Sejlklub23.Interfaces;
using Sejlklub23.Models;

namespace Sejlklub23.Services
{
    public class PostRepository : IPostRepository
    {
        private string jsonFileName = @"Data\BlogPosts.json";

        public List<Post> GetAllPosts()
        {
            return JsonFileReader<Post>.ReadJson(jsonFileName);
        }

        public void CreatePost(Post post)
        {
            List<int> ids = new List<int>();
            List<Post> posts = GetAllPosts();
            //Looks for through the IDs of the boats
            foreach (var item in posts) {
                ids.Add(item.PostId);
            }
            //based on whether this is the first entry or not it either gives the boat an ID of 1 or 1+the highest value ID in the current list
            if (ids.Count != 0)
                post.PostId = ids.Max() + 1;
            else
                post.PostId = 1;
            posts.Add(post);
            JsonFileWriter<Post>.WriteToJson(posts, jsonFileName);
        }

        public void DeletePost(int id)
        {
            List<Post> posts = GetAllPosts();
            posts.Remove(posts.Find(post => post.PostId == id));
            JsonFileWriter<Post>.WriteToJson(posts, jsonFileName );
        }

        public Post GetPost(int id)
        {
            return GetAllPosts().Find(post => post.PostId == id);
        }

        public void UpdatePost(Post post)
        {
            if(post != null) {
                List<Post> posts = GetAllPosts();

                foreach (var item in posts) {
                    if (item.PostId == post.PostId) {
                        item.Title = post.Title;
                        item.Body = post.Body;
                        break;
                    }
                }
                JsonFileWriter<Post>.WriteToJson(posts, jsonFileName);
            }
        }
    }
}
