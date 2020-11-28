using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rheal_Assignment_MVC.Models;


namespace Rheal_Assignment_MVC.BizRepositories
{
    public class CourseBizRepository : IBizRepository<Course, int>
    {

        RhealAssignmentDBContext context;

        public CourseBizRepository()
        {
            context = new RhealAssignmentDBContext();
        }

        public Course create(Course entity)
        {
            if (entity != null)
            {
                context.Courses.Add(entity);
                context.SaveChanges();
                return entity;
            }
            return entity;
        }

        public bool delete(int id)
        {
            var cour = context.Courses.Find(id);
            if (cour != null)
            {
                context.Courses.Remove(cour);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Course> getData()
        {
            return context.Courses.ToList();
        }

        public Course getData(int id)
        {
            Course cour = context.Courses.Find(id);
            return cour;
        }

        public Course update(int id, Course entity)
        {
            var cour = context.Courses.Find(id);
            if (cour != null)
            {
                cour.CourseNoOfModules = entity.CourseNoOfModules;
                cour.CoursePrice = entity.CoursePrice;
                //cour.CourseTrainerId = entity.CourseTrainerId;
                cour.CourseTrainer = entity.CourseTrainer;
                return cour;
            }
            return entity;
        }
    }
}