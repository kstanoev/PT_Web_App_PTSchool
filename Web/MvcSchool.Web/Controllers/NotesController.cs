﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcSchool.Services;
using MvcSchool.Services.Models.Note;
using MvcSchool.Web.Models.Note;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSchool.Web.Controllers
{
    [Authorize(Roles = "Teacher, Parent, Student")]
    public class NotesController : Controller
    {
        private readonly INoteService noteService;

        public NotesController(INoteService noteService)
        {
            this.noteService = noteService;
        }

        public IActionResult AllNotes(int id)
        {
            var notesAll = this.noteService.GetAllNotesProfilesFullByStudentId(id);

            var model = new AllNoteProfilesFullViewModel
            {
                NoteProfilesFull = notesAll
            };

            return this.View(model);
        }

        public IActionResult AddNote(int id)
        {
            var model = new NoteProfileFullToAddViewModel
            {
                StudentId = id
            };
            return this.View(model);
        }

        [HttpPost]
        public IActionResult AddNote(NoteProfileFullToAddViewModel noteProfileToAdd, int id)
        {
            var noteProfileServiceModelToAdd = new NoteProfileFullServiceModel
            {
                StudentId = id,
                SubjectId = (int)noteProfileToAdd.Subject,
                Title = noteProfileToAdd.Title,
                Comment = noteProfileToAdd.Comment,
                DateReceived = noteProfileToAdd.DateReceived,
                TeacherId = 25,
                StatusNote = (int)noteProfileToAdd.StatusNote,
            };

            this.noteService.AddNewNoteProfileToStudentByStudentId(noteProfileServiceModelToAdd);

            return this.RedirectToAction("NoteApproved", new { id = id });
        }

        public IActionResult NoteApproved(int id)
        {
            int idToGiveToView = id;
            return this.View(idToGiveToView);
        }
    }
}
