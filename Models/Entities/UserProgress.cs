using System;
using System.Collections.Generic;

namespace AcademyPrestudies.Models.Entities
{
    public partial class UserProgress
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public int? UserId { get; set; }
        public bool CourseFinishedId { get; set; }
        public int? ExerciseId { get; set; }
        public bool? ExerciseFinishedId { get; set; }
        public int? ClassId { get; set; }
        public bool? ClassFinishedId { get; set; }
    }
}
