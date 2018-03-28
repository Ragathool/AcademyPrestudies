using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AcademyPrestudies.Models.Entities
{
    public partial class AssignmentContext : DbContext
    {
        public AssignmentContext(DbContextOptions<AssignmentContext> options) : base(options)
        {
        }
    }
}
