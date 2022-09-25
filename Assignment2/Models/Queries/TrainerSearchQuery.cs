using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2.Models.Queries
{
    public class TrainerSearchQuery
    {
        public string searchFirstName { get; set; }
        public string searchLastName { get; set; }
        public string searchSubject { get; set; }
    }
}