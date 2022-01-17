#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonDatabase.Models;

namespace PersonDatabase.Data
{
    public class PersonDatabaseContext : DbContext
    {
        public PersonDatabaseContext (DbContextOptions<PersonDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<PersonDatabase.Models.Person> Person { get; set; }
    }
}
