using Sejlklub23.Models;

namespace Sejlklub23.Interfaces
{
    public interface IPostRepository
    {
        List<Post> GetAllPosts();
        Post GetPost(int id);

        void CreatePost(Post post);
        void UpdatePost(Post post);
        void DeletePost(int id);
    }
}
