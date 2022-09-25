using Assignment2.Models;
using Assignment2.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.RepositoryServices.Core.Repositories
{
    public interface ITrainerRepository : IGenericRepository<Trainer>
    {
        IEnumerable<Trainer> Filter(IEnumerable<Trainer> trainers, TrainerSearchQuery query);
    }
}
