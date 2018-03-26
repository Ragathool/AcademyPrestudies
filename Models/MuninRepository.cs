using AcademyPrestudies.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyPrestudies.Models
{
    public class MuninRepository
    {
        private readonly MuninContext context;

        public MuninRepository(MuninContext context)
        {
            this.context = context;
        }
    }
}
