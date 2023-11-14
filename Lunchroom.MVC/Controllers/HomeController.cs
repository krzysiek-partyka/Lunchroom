﻿using System.Diagnostics;
using Lunchroom.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lunchroom.MVC.Controllers;

public class HomeController : Controller
{
    public IActionResult NoAccess()
    {
        return View();
    }

    public IActionResult Index()
    {
        return View();
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