﻿using MvcSchool.Services.Models.Club;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSchool.Web.Models.Club
{
    public class AllClubProfilesFullViewModel
    {
        public IEnumerable<ClubProfileFullServiceModel> AllClubsFull { get; set; }
    }
}
