using System;
using System.Collections.Generic;

namespace AcademyPrestudies.Models.Entities
{
    public partial class Tips
    {
        public int Id { get; set; }
        public string TipInfo { get; set; }
        public int ExerciseId { get; set; }

        public Exercise Exercise { get; set; }
    }
}
