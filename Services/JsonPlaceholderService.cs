using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HtmxDashboard.Models;

namespace HtmxDashboard.Services
{
    public class JsonPlaceholderService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://jsonplaceholder.typicode.com";

        public JsonPlaceholderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new System.Uri(BaseUrl);
        }

        public async Task<List<Post>> GetPostsAsync(int page = 1, int limit = 10)
        {
            // Get posts for the page
            var response = await _httpClient.GetAsync($"/posts?_page={page}&_limit={limit}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var posts = JsonConvert.DeserializeObject<List<Post>>(content);
            
            // Get comment counts for each post to sort posts with comments first
            var postsWithCommentCounts = new List<(Post post, int commentCount)>();
            
            foreach (var post in posts)
            {
                try
                {
                    var commentsResponse = await _httpClient.GetAsync($"/posts/{post.Id}/comments");
                    if (commentsResponse.IsSuccessStatusCode)
                    {
                        var commentsContent = await commentsResponse.Content.ReadAsStringAsync();
                        var comments = JsonConvert.DeserializeObject<List<Comment>>(commentsContent);
                        var commentCount = comments?.Count ?? 0;
                        post.CommentCount = commentCount; // Set the comment count on the post
                        postsWithCommentCounts.Add((post, commentCount));
                    }
                    else
                    {
                        post.CommentCount = 0;
                        postsWithCommentCounts.Add((post, 0));
                    }
                }
                catch
                {
                    // If there's an error getting comments, assume 0 comments
                    post.CommentCount = 0;
                    postsWithCommentCounts.Add((post, 0));
                }
            }
            
            // Sort posts: posts with comments first, then by comment count descending, then by post ID
            return postsWithCommentCounts
                .OrderByDescending(x => x.commentCount > 0) // Posts with comments first
                .ThenByDescending(x => x.commentCount)      // Then by comment count descending
                .ThenBy(x => x.post.Id)                     // Then by post ID for consistency
                .Select(x => x.post)
                .ToList();
        }

        public async Task<Post> GetPostAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/posts/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Post>(content);
        }

        public async Task<List<Comment>> GetCommentsForPostAsync(int postId)
        {
            var response = await _httpClient.GetAsync($"/posts/{postId}/comments");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            var comments = JsonConvert.DeserializeObject<List<Comment>>(content);
            
            // Debug: Log the actual response
            System.Diagnostics.Debug.WriteLine($"GetCommentsForPostAsync({postId}): Response length: {content?.Length ?? 0}, Comments count: {comments?.Count ?? 0}");
            
            return comments ?? new List<Comment>();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var response = await _httpClient.GetAsync("/users");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<User>>(content);
        }

        public async Task<List<User>> SearchUsersAsync(string query)
        {
            var users = await GetUsersAsync();
            if (string.IsNullOrWhiteSpace(query))
                return users;

            query = query.ToLower();
            return users.FindAll(u => 
                u.Name.ToLower().Contains(query) || 
                u.Username.ToLower().Contains(query) ||
                u.Email.ToLower().Contains(query)
            );
        }
    }
}