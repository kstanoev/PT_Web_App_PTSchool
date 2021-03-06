﻿using MvcSchool.Data;
using MvcSchool.Data.Models;
using MvcSchool.Services.Models.Note;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcSchool.Services.Implementations
{
    public class NoteService : INoteService
    {
        private readonly MvcSchoolDbContext db;

        public NoteService(MvcSchoolDbContext db)
        {
            this.db = db;
        }

        public void AddNewNoteProfileToStudentByStudentId(NoteProfileFullServiceModel noteToAdd)
        {
            this.db.Notes.Add(new Note
            {
                StatusNote = (EnumStatusNote)noteToAdd.StatusNote,
                Title = noteToAdd.Title,
                Comment = noteToAdd.Comment,
                DateReceived = noteToAdd.DateReceived,
                DateConfirmed = noteToAdd.DateConfirmed,
                StudentId = noteToAdd.StudentId,
                SubjectId = noteToAdd.SubjectId,
                TeacherId = noteToAdd.TeacherId,
            });
            db.SaveChanges();
        }

        public IEnumerable<NoteProfileFullServiceModel> GetAllNotesProfilesFullByStudentId(int id)
        {
            return this.db.Notes.Where(x => x.StudentId == id).Select(x => new NoteProfileFullServiceModel
            {
                Id = x.Id,
                StatusNote = (int)x.StatusNote,
                Title = x.Title,
                Comment = x.Comment,
                StudentId = x.StudentId,
                StudentName = x.Student.FirstName + " " + x.Student.FirstName,
                StudentImageM = x.Student.ImageM,
                SubjectId = x.SubjectId,
                SubjectImageXXS = x.Subject.ImageXXS,
                TeacherId = x.TeacherId,
                TeacherImageXXS = x.Teacher.ImageXXS,
                DateReceived = x.DateReceived,
                DateConfirmed = x.DateConfirmed,
            }).OrderByDescending(x => x.DateReceived);
        }
    }
}
