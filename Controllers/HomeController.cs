using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HtmxDashboard.Models;

namespace HtmxDashboard.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private static int _notificationCount = 3;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.NotificationCount = _notificationCount;
        return View();
    }

    public async Task<IActionResult> NotificationCount()
    {
        var stopwatch = Stopwatch.StartNew();
        
        // Remove any artificial delays that might be causing the 20-second issue
        // Simulate a realistic API call delay instead of blocking for 20 seconds
        await Task.Delay(100); // Short 100ms delay to simulate realistic API response time
        
        var random = new Random();
        _notificationCount = random.Next(0, 10);
        
        stopwatch.Stop();
        _logger.LogInformation($"NotificationCount took {stopwatch.ElapsedMilliseconds}ms");
        
        // Add timing info to response headers for performance monitoring
        Response.Headers.Add("X-Request-Duration", stopwatch.ElapsedMilliseconds.ToString());
        
        return PartialView("_NotificationBadge", _notificationCount);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
