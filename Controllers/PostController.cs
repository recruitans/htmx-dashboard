using Microsoft.AspNetCore.Mvc;
using HtmxDashboard.Services;
using HtmxDashboard.Models;
using System.Diagnostics;
using System.Linq;

namespace HtmxDashboard.Controllers
{
    public class PostController : Controller
    {
        private readonly JsonPlaceholderService _jsonPlaceholderService;
        private readonly ILogger<PostController> _logger;

        public PostController(JsonPlaceholderService jsonPlaceholderService, ILogger<PostController> logger)
        {
            _jsonPlaceholderService = jsonPlaceholderService;
            _logger = logger;
        }

        public async Task<IActionResult> LoadPosts(int page = 1)
        {
            var stopwatch = Stopwatch.StartNew();
            
            var posts = await _jsonPlaceholderService.GetPostsAsync(page, 10);
            
            stopwatch.Stop();
            var recordsProcessed = posts?.Count ?? 0;
            var totalComments = posts?.Sum(p => p.CommentCount) ?? 0;
            
            _logger.LogInformation($"LoadPosts page {page} took {stopwatch.ElapsedMilliseconds}ms, processed {recordsProcessed} posts with {totalComments} total comments");
            
            // Add timing and record count info to response headers
            Response.Headers.Add("X-Request-Duration", stopwatch.ElapsedMilliseconds.ToString());
            Response.Headers.Add("X-Records-Processed", recordsProcessed.ToString());
            Response.Headers.Add("X-Comments-Processed", totalComments.ToString());
            Response.Headers.Add("X-Page-Number", page.ToString());
            
            ViewBag.NextPage = page + 1;
            ViewBag.CurrentPage = page;
            ViewBag.RecordsProcessed = recordsProcessed;
            ViewBag.CommentsProcessed = totalComments;
            
            if (page == 1)
            {
                return PartialView("_PostList", posts);
            }
            
            return PartialView("_PostListAppend", posts);
        }

        public async Task<IActionResult> LoadComments(int postId)
        {
            var stopwatch = Stopwatch.StartNew();
            
            _logger.LogInformation($"Loading comments for post {postId}");
            
            // Simulate loading delay
            await Task.Delay(500);
            
            var comments = await _jsonPlaceholderService.GetCommentsForPostAsync(postId);
            
            stopwatch.Stop();
            var commentsCount = comments?.Count ?? 0;
            
            _logger.LogInformation($"LoadComments for post {postId} took {stopwatch.ElapsedMilliseconds}ms, loaded {commentsCount} comments");
            
            // Add timing and record count info to response headers
            Response.Headers["X-Request-Duration"] = stopwatch.ElapsedMilliseconds.ToString();
            Response.Headers["X-Comments-Loaded"] = commentsCount.ToString();
            Response.Headers["X-Post-Id"] = postId.ToString();
            
            _logger.LogInformation($"Comments loaded for post {postId}: {commentsCount} comments");
            
            if (comments == null || !comments.Any())
            {
                _logger.LogWarning($"No comments found for post {postId}");
                return Content("<div class='alert alert-info mt-3'><small>No comments found for this post.</small></div>");
            }
            
            _logger.LogInformation($"Returning _Comments partial view with {comments.Count} comments");
            return PartialView("_Comments", comments);
        }
        
        // Debug endpoint to test comments directly
        public async Task<IActionResult> TestComments(int postId = 1)
        {
            var comments = await _jsonPlaceholderService.GetCommentsForPostAsync(postId);
            ViewBag.PostId = postId;
            ViewBag.CommentsJson = Newtonsoft.Json.JsonConvert.SerializeObject(comments, Newtonsoft.Json.Formatting.Indented);
            return View(comments);
        }
    }
}