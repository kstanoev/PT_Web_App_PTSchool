﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MvcSchool.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvcSchool.Data.Configuration
{
    public class SubjectClassConfiguration : IEntityTypeConfiguration<SubjectClass>
    {
        public void Configure(EntityTypeBuilder<SubjectClass> subjectClass)
        {
            subjectClass
                .HasKey(sC => new { sC.ClassId, sC.SubjectId });

            subjectClass
                .HasOne(sC => sC.Subject)
                .WithMany(sub => sub.Classes)
                .HasForeignKey(cl => cl.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            subjectClass
                .HasOne(sC => sC.Class)
                .WithMany(cl => cl.Subjects)
                .HasForeignKey(sub => sub.ClassId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
