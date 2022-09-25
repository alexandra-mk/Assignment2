namespace Assignment2.Migrations
{
    using Assignment2.Models;
    using Assignment2.Models.Enums;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Assignment2.Context.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Assignment2.Context.ApplicationContext context)
        {
            Trainer t1 = new Trainer() { FirstName = "Ektoras", LastName = "Gkatsos", SubjectString = "CSharp" };
            Trainer t2 = new Trainer() { FirstName = "Periklis", LastName = "Aidinopoulos", SubjectString = "CSharp" };
            Trainer t3 = new Trainer() { FirstName = "Giorgos", LastName = "Pasparakis", SubjectString = "Java" };
            Trainer t4 = new Trainer() { FirstName = "Panagiotis", LastName = "Bozas", SubjectString = "CSharp" };
            Trainer t5 = new Trainer() { FirstName = "Giorgos", LastName = "Irakleidis", SubjectString = "Java" };
            Trainer t6 = new Trainer() { FirstName = "Sandra", LastName = "Tirovola", SubjectString = "Python" };
            Trainer t7 = new Trainer() { FirstName = "Antonis", LastName = "Thodos", SubjectString = "JavaScript" };

            context.Trainers.AddOrUpdate(t => t.LastName, t1, t2, t3, t4, t5, t6, t7);
            context.SaveChanges();
        }
    }
}
