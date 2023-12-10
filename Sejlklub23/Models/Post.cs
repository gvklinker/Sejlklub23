namespace Sejlklub23.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public Member PostAuthor { get; set; }

        public Post(int postId, string title, string body, Member postAuthor)
        {
            PostId = postId;
            Title = title;
            Body = body;
            PostAuthor = postAuthor;
        }
    }
}
