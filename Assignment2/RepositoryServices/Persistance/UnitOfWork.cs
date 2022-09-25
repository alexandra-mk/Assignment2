using Assignment2.Context;
using Assignment2.Repositories;
using Assignment2.RepositoryServices.Core;
using Assignment2.RepositoryServices.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2.RepositoryServices.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationContext context;
        public UnitOfWork(ApplicationContext dbcontext)
        {
            context = dbcontext;
            Trainers = new TrainerRepository(context);
        }
        public ITrainerRepository Trainers { get; private set; }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}