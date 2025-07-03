namespace HtmxDashboard.Models
{
    public class Post
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int CommentCount { get; set; } = 0; // Number of comments for this post
    }
}