using Assignment2.Context;
using Assignment2.Models;
using Assignment2.Models.Queries;
using Assignment2.RepositoryServices.Core.Repositories;
using Assignment2.RepositoryServices.Persistance;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment2.Repositories
{
    public class TrainerRepository : GenericRepository<Trainer>, ITrainerRepository
    {
      
        public TrainerRepository(ApplicationContext context) : base(context)
        {
            
        }

        public IEnumerable<Trainer> Filter(IEnumerable<Trainer> trainers, TrainerSearchQuery query)
        {
            if (!string.IsNullOrWhiteSpace(query.searchFirstName))
            {
                trainers = trainers.Where(t => t.FirstName.ToUpper().Contains(query.searchFirstName.ToUpper())).ToList();
            }

            if (!string.IsNullOrWhiteSpace(query.searchLastName))
            {
                trainers = trainers.Where(t => t.LastName.ToUpper().Contains(query.searchLastName.ToUpper())).ToList();
            }

            if (!string.IsNullOrWhiteSpace(query.searchSubject))
            {
                trainers = trainers.Where(t => t.SubjectString == query.searchSubject).ToList();
            }

            return trainers;
        }
    }
}