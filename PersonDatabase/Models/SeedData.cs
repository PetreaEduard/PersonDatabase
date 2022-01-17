using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonDatabase.Data;
using System;
using System.Linq;

namespace PersonDatabase.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PersonDatabaseContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PersonDatabaseContext>>()))
            {
                // Look for any movies.
                if (context.Person.Any())
                {
                    return;   // DB has been seeded
                }

                /*public string? Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirtDate { get; set; }
        public string? Age { get; set; }
        public string? Job { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Adress { get; set; }*/

                context.Person.AddRange(
                            new Person
                            {
                                Name = "Mike Stoklasa",
                                BirthDate = DateTime.Parse("1989-2-12"),
                                Age = 32,
                                Job = "Unemployed",
                                PhoneNumber = "210-385-2355",
                                Adress = "something",
                                Town = "Athens"


                            },

                            new Person
                            {
                                Name = "Ryan Mcgee",
                                BirthDate = DateTime.Parse("1982-11-09"),
                                Age = 39,
                                Job = "Entrepreneur",
                                PhoneNumber = "252-757-4196",
                                Adress = "something",
                                Town = "Athens"
                            },

                            new Person
                            {
                                Name = "Matthew Watson",
                                BirthDate = DateTime.Parse("1992-08-27"),
                                Age = 29,
                                Job = "Performance artist",
                                PhoneNumber = "509-848-0922",
                                Adress = "something",
                                Town = "Detroit"
                            },

                            new Person
                            {
                                Name = "Steve Rambo",
                                BirthDate = DateTime.Parse("1996-02-20"),
                                Age = 25,
                                Job = "Computer engineer",
                                PhoneNumber = "718-642-9902",
                                Adress = "something",
                                Town = "Bacau"
                            }
                        );
                context.SaveChanges();
            }
        }
    }
}
