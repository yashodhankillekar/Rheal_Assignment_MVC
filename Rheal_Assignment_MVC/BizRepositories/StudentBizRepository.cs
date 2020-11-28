using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rheal_Assignment_MVC.Models;

namespace Rheal_Assignment_MVC.BizRepositories
{
    public class StudentBizRepository : IBizRepository<Student, int>
    {
        RhealAssignmentDBContext context;

        public StudentBizRepository()
        {
            context = new RhealAssignmentDBContext();
        }

        public Student create(Student entity)
        {
            if (entity != null)
            {
                context.Students.Add(entity);
                context.SaveChanges();
                return entity;
            }
            return entity;
        }

        public bool delete(int id)
        {
            var stud = context.Students.Find(id);
            if (stud != null)
            {
                context.Students.Remove(stud);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Student> getData()
        {
            return context.Students.ToList();
        }

        public Student getData(int id)
        {
            Student stud = context.Students.Find(id);
            return stud;
        }

        public Student update(int id, Student entity)
        {
            var stud = context.Students.Find(id);
            if (stud != null)
            {
                stud.StudentAddress = entity.StudentAddress;
                stud.StudentAOIRowId = entity.StudentAOIRowId;
                stud.StudentCity = entity.StudentCity;
                stud.StudentDOB = entity.StudentDOB;
                stud.StudentName = entity.StudentName;
                stud.StudentMobileNo = entity.StudentMobileNo;
                return stud;
            }
            return entity;
        }
    }
}