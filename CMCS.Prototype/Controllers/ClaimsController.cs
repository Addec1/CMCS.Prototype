using Microsoft.AspNetCore.Mvc;
using CMCS.Prototype.Models;
using System;
using System.Collections.Generic;

namespace CMCS.Prototype.Controllers
{
    public class ClaimsController : Controller
    {
        // static sample claims (front-end prototype only)
        private static readonly List<ClaimVm> _claims =
        [
            new ClaimVm
            {
                ClaimId = Guid.Parse("aaaaaaaa-bbbb-cccc-dddd-000000000001"),
                LecturerName = "Ayesha Khan",
                Month = DateTime.Now.Month, Year = DateTime.Now.Year,
                HourlyRate = 420, TotalHours = 16.5m, Status = ClaimStatus.Submitted,
                Entries =
                {
                    new ClaimEntryVm{ Date = DateOnly.FromDateTime(DateTime.Today.AddDays(-5)), Hours = 3.5m, Description = "Marking & moderation"},
                    new ClaimEntryVm{ Date = DateOnly.FromDateTime(DateTime.Today.AddDays(-3)), Hours = 13.0m, Description = "Lectures + consultations"},
                }
            },
            new ClaimVm
            {
                ClaimId = Guid.Parse("aaaaaaaa-bbbb-cccc-dddd-000000000002"),
                LecturerName = "Daniel Peters",
                Month = DateTime.Now.Month, Year = DateTime.Now.Year,
                HourlyRate = 380, TotalHours = 8m, Status = ClaimStatus.Draft
            },
            new ClaimVm
            {
                ClaimId = Guid.Parse("aaaaaaaa-bbbb-cccc-dddd-000000000003"),
                LecturerName = "Linda Jacobs",
                Month = DateTime.Now.Month-1 <= 0 ? 12 : DateTime.Now.Month-1,
                Year = DateTime.Now.Year,
                HourlyRate = 400, TotalHours = 20m, Status = ClaimStatus.Verified
            }
        ];

        public IActionResult Index() => View(_claims);

        public IActionResult Details(Guid id)
        {
            var claim = _claims.Find(c => c.ClaimId == id);
            return claim is null ? NotFound() : View(claim);
        }

        // Front-end only "Create" page (no POST)
        [HttpGet]
        public IActionResult Create()
        {
            var vm = new ClaimVm
            {
                ClaimId = Guid.NewGuid(),
                LecturerName = "You (Demo)",
                Month = DateTime.Now.Month,
                Year = DateTime.Now.Year,
                HourlyRate = 400
            };
            return View(vm);
        }
    }
}