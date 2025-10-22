using Microsoft.AspNetCore.Mvc;
using CMCS.Prototype.Models;
using System;
using System.Collections.Generic;

namespace CMCS.Prototype.Controllers
{
    public class DocumentsController : Controller
    {
        private const string ViewsRoot = "~/Views/Documents/";
        private const string IndexView = ViewsRoot + "Index.cshtml";
        private const string UploadView = ViewsRoot + "Upload.cshtml";

        [HttpGet]
        public IActionResult Index()
        {
            var docs = new List<DocumentVm>
            {
                new DocumentVm{ FileName="Oct2025_timesheet.pdf", SizeKb=312, UploadedOn=DateTime.Today.AddDays(-3)},
                new DocumentVm{ FileName="Classlist_support.pdf", SizeKb=145, UploadedOn=DateTime.Today.AddDays(-1)},
                new DocumentVm{ FileName="Moderator_report.pdf", SizeKb=201, UploadedOn=DateTime.Today.AddDays(-6)}
            };

            return View(IndexView, docs);
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View(UploadView);
        }
    }
}
//