using Assignment2.RepositoryServices.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.RepositoryServices.Core
{
    internal interface IUnitOfWork : IDisposable
    {
        ITrainerRepository Trainers { get; }

        int Complete();
    }
}
