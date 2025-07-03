using Microsoft.AspNetCore.Mvc;
using HtmxDashboard.Services;

namespace HtmxDashboard.Controllers
{
    public class UserController : Controller
    {
        private readonly JsonPlaceholderService _jsonPlaceholderService;

        public UserController(JsonPlaceholderService jsonPlaceholderService)
        {
            _jsonPlaceholderService = jsonPlaceholderService;
        }

        [HttpPost]
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query) || query.Length < 3)
            {
                return Content("<p class='text-muted'>Type at least 3 characters to search...</p>");
            }

            var users = await _jsonPlaceholderService.SearchUsersAsync(query);
            var recordsProcessed = users?.Count ?? 0;
            
            // Add record count info to response headers
            Response.Headers.Add("X-Records-Processed", recordsProcessed.ToString());
            Response.Headers.Add("X-Search-Query", query);
            
            if (!users.Any())
            {
                return Content("<p class='text-warning'>No users found.</p>");
            }

            return PartialView("_UserSearchResults", users);
        }
    }
}