﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcSchool.Services;
using MvcSchool.Web.Models.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MvcSchool.Web.Controllers
{
    [Authorize(Roles = "Teacher, Parent, Student")]
    public class SubjectsController : Controller
    {
        private readonly ISubjectService subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        public IActionResult AllSubjects()
        {
            var allSubjects = this.subjectService.GetAllSubjectProfilesFull();

            var model = new AllSubjectProfilesFullViewModel
            {
                AllSubjectsFull = allSubjects
            };

            return this.View(model);
        }

        public IActionResult Subject(int id)
        {
            var subjectById = this.subjectService.GetSubjectProfileFullById(id);

            var model = new SubjectProfileFullBySubjectIdViewModel
            {
                SubjectProfileFullById = subjectById
            };

            return this.View(model);
        }
    }
}
