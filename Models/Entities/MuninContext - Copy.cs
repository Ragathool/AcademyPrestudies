using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AcademyPrestudies.Models.Entities
{
    public partial class MuninContext : DbContext
    {
        public MuninContext(DbContextOptions<MuninContext> options) : base(options)
        {
        }
    }
}
