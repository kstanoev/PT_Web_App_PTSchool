﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MvcSchool.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvcSchool.Data.Configuration
{
    class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> subject)
        {
            subject
                .HasMany(sub => sub.Marks)
                .WithOne(m => m.Subject)
                .HasForeignKey(m => m.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
