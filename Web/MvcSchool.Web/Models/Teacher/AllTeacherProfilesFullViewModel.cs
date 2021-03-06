﻿using Microsoft.EntityFrameworkCore.Internal;
using MvcSchool.Services.Models.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSchool.Web.Models.Teacher
{
    public class AllTeacherProfilesFullViewModel
    {
        public IEnumerable<TeacherProfileFullServiceModel> AllTeachersFull { get; set; }


        public int PageSize { get; set; }

        public int CurrentPage { get; set; }

        public int TotalCount { get; set; }

        public int FirstPage => 1;
        public int LastPage
        {
            get
            {
                return (int)Math.Ceiling((double)this.TotalCount / this.PageSize);
            }
        }

        public int PreviousPage => this.CurrentPage - 1;
        public int NextPage => this.CurrentPage + 1;

        public bool IsPreviousPageDisabled => this.CurrentPage == 1;
        public bool IsNextPageDisabled
        {
            get
            {
                return CurrentPage == Math.Ceiling((double)this.TotalCount / this.PageSize);
            }
        }

        
    }
}
