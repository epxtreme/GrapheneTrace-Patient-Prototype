using System;
using System.Collections.Generic;
using System.Linq;
using GrapheneTrace.Models;
using Microsoft.AspNetCore.Mvc;

namespace GrapheneTrace.Controllers
{
    public class PatientController : Controller
    {
        // In-memory list of comments shared by Dashboard and Comments pages
        private static List<Comment> _comments = new List<Comment>();

        // GET: /Patient/Dashboard
        [HttpGet]
        public IActionResult Dashboard()
        {
            var model = new DashboardViewModel
            {
                PeakPressureIndex = 240,
                ContactAreaPercent = 65,
                AveragePressure = 180,
                Comments = _comments
                    .OrderByDescending(c => c.CreatedAt)
                    .ToList()
            };

            return View(model);
        }

        // POST: /Patient/Dashboard  (add new comment from dashboard)
        [HttpPost]
        public IActionResult Dashboard(string commentText)
        {
            if (!string.IsNullOrWhiteSpace(commentText))
            {
                _comments.Add(new Comment
                {
                    Text = commentText,
                    CreatedAt = DateTime.Now
                });
            }

            return RedirectToAction("Dashboard");
        }

        // GET: /Patient/Comments  (previous comments page)
        [HttpGet]
        public IActionResult Comments()
        {
            var orderedComments = _comments
                .OrderByDescending(c => c.CreatedAt)
                .ToList();

            return View(orderedComments);
        }
    }
}
