using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rheal_Assignment_MVC.Models;


namespace Rheal_Assignment_MVC.BizRepositories
{
    public class StudentCourseBizRepository : IBizRepository<StudentCourse, int>
    {
        RhealAssignmentDBContext context;

        public StudentCourseBizRepository()
        {
            context = new RhealAssignmentDBContext();
        }

        public StudentCourse create(StudentCourse entity)
        {
            if (entity != null)
            {
                context.StudentCourses.Add(entity);
                context.SaveChanges();
                return entity;
            }
            return entity;
        }

        public bool delete(int id)
        {
            var aoi = context.StudentCourses.Find(id);
            if (aoi != null)
            {
                context.StudentCourses.Remove(aoi);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<StudentCourse> getData()
        {
            return context.StudentCourses.ToList();
        }

        public StudentCourse getData(int id)
        {
            StudentCourse aoi = context.StudentCourses.Find(id);
            return aoi;
        }

        public StudentCourse update(int id, StudentCourse entity)
        {
            var studCour = context.StudentCourses.Find(id);
            if (studCour != null)
            {
                studCour.CourseId = entity.CourseId;
                return studCour;
            }
            return entity;
        }
    }
}