using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rheal_Assignment_MVC.Models;


namespace Rheal_Assignment_MVC.BizRepositories
{
    public class AreaOfInterestBizRepository : IBizRepository<AreaOfInterest, int>
    {
        RhealAssignmentDBContext context;

        public AreaOfInterestBizRepository()
        {
            context = new RhealAssignmentDBContext();
        }

        public AreaOfInterest create(AreaOfInterest entity)
        {
            if (entity != null)
            {
                context.AreaOfInterests.Add(entity);
                context.SaveChanges();
                return entity;
            }
            return entity;
        }

        public bool delete(int id)
        {
            var aoi = context.AreaOfInterests.Find(id);
            if (aoi != null)
            {
                context.AreaOfInterests.Remove(aoi);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<AreaOfInterest> getData()
        {
            return context.AreaOfInterests.ToList();
        }

        public AreaOfInterest getData(int id)
        {
            AreaOfInterest aoi = context.AreaOfInterests.Find(id);
            return aoi;
        }

        public AreaOfInterest update(int id, AreaOfInterest entity)
        {
            var aoi = context.AreaOfInterests.Find(id);
            if (aoi != null)
            {
                aoi.Name = entity.Name;
                return aoi;
            }
            return entity;
        }
    }
}