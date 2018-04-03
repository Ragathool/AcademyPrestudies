using AcademyPrestudies.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyPrestudies.Views.Shared.Components.UserStatusBox
{
    public class UserStatusBoxViewComponent : ViewComponent
    {
        private AssignmentRepository assignmentRepository;
        private AccountRepository accountRepository;


        public UserStatusBoxViewComponent(AssignmentRepository assignmentRepository, AccountRepository accountRepository)
        {
            this.assignmentRepository = assignmentRepository;
            this.accountRepository = accountRepository;
        }

        public IViewComponentResult InvokeAsync(int userId, int courseId)
        {
            var courseCount = assignmentRepository.GetAllAssignments();
            var finishedcourses = assignmentRepository.GetFinishedCourses(userId);
            var progressbar = finishedcourses / courseCount.Count;
            var progressbarpercent = progressbar * 100;

            return View();
        }
    }
}
