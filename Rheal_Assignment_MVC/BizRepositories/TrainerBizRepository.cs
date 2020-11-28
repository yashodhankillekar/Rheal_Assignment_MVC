using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rheal_Assignment_MVC.Models;

namespace Rheal_Assignment_MVC.BizRepositories
{
    public class TrainerBizRepository : IBizRepository<Trainer, int>
    {
        RhealAssignmentDBContext context;

        public TrainerBizRepository()
        {
            context = new RhealAssignmentDBContext();
        }

        public Trainer create(Trainer entity)
        {
            if (entity != null)
            {
                context.Trainers.Add(entity);
                context.SaveChanges();
                return entity;
            }
            return entity;
        }

        public bool delete(int id)
        {
            var train = context.Trainers.Find(id);
            if (train != null)
            {
                context.Trainers.Remove(train);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Trainer> getData()
        {
            return context.Trainers.ToList();
        }

        public Trainer getData(int id)
        {
            Trainer train = context.Trainers.Find(id);
            return train;
        }

        public Trainer update(int id, Trainer entity)
        {
            var train = context.Trainers.Find(id);
            if (train != null)
            {
                train.Name = entity.Name;
                //train.ExpertiseRowId = entity.ExpertiseRowId;
                train.Expertise = entity.Expertise;
                return train;
            }
            return entity;
        }
    }
}