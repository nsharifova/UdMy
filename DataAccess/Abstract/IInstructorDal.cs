using Core;
using Entites;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IInstructorDal :IEntityRepository<Instructor>
    {
        public Instructor? InstructorCoursesById(int instructorId);
    }
}
