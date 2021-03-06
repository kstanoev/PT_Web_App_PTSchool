﻿using MvcSchool.Data;
using MvcSchool.Services.Models.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcSchool.Services.Implementations
{
    public class SubjectService : ISubjectService
    {
        private readonly MvcSchoolDbContext db;

        public SubjectService(MvcSchoolDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SubjectProfileFullServiceModel> GetAllSubjectProfilesFull()
        {
            return this.db.Subjects.Select(x => new SubjectProfileFullServiceModel
            {
                Id = x.Id,
                Name = x.Name,
                ImageXS = x.ImageXS,
                Description = x.Description,
                TeachersIds = x.Teachers.Select(y => y.TeacherId),
                //TeachersImagesXXS = x.Teachers.Select(y => y.Teacher.ImageXXS),
                ClassesIds = x.Classes.Select(z => z.ClassId),
                //ClassesImagesXXS = x.Classes.Select(z => z.Class.ImageXXS)
            });
        }

        public SubjectProfileFullServiceModel GetSubjectProfileFullById(int id)
        {
            return this.db.Subjects.Where(x => x.Id == id).Select(x => new SubjectProfileFullServiceModel
            {
                Id = x.Id,
                Name = x.Name,
                ImageM = x.ImageM,
                Description = x.Description,
                TeachersIds = x.Teachers.Select(y => y.TeacherId),
                TeachersImagesXXS = x.Teachers.Select(y => y.Teacher.ImageXXS),
                ClassesIds = x.Classes.Select(z => z.ClassId),
                ClassesImagesXXS = x.Classes.Select(z => z.Class.ImageXXS),
            }).FirstOrDefault();
        }
    }
}
