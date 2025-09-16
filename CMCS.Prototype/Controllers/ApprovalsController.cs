using Microsoft.AspNetCore.Mvc;
using CMCS.Prototype.Models;
using System;
using System.Collections.Generic;

namespace CMCS.Prototype.Controllers
{
    public class ApprovalsController : Controller
    {
        public IActionResult Index()
        {
            // sample "inbox" for Coordinator/Manager
            var list = new List<ApprovalVm>
            {
                new ApprovalVm{ ClaimId = Guid.Parse("aaaaaaaa-bbbb-cccc-dddd-000000000001"),
                    LecturerName="Ayesha Khan", Stage = ApprovalStage.Coordinator,
                    Status = ClaimStatus.Submitted, SubmittedOn = DateTime.Today.AddDays(-2) },
                new ApprovalVm{ ClaimId = Guid.Parse("aaaaaaaa-bbbb-cccc-dddd-000000000003"),
                    LecturerName="Linda Jacobs", Stage = ApprovalStage.Manager,
                    Status = ClaimStatus.Verified, SubmittedOn = DateTime.Today.AddDays(-7) },
            };
            return View(list);
        }

        public IActionResult Details(Guid id)
        {
            // lightweight demo details page
            var vm = new ApprovalVm
            {
                ClaimId = id,
                LecturerName = "(Sample)",
                Stage = ApprovalStage.Manager,
                Status = ClaimStatus.Verified,
                SubmittedOn = DateTime.Today.AddDays(-1)
            };
            return View(vm);
        }
    }
}
