using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PBZ_Lab2.Web.Domain.Models;

namespace PBZ_Lab2.Web.Data
{
    public class DefaultDB
    {
        public static void Init(PBZ_Lab2WebContext context)
        {
            context.Database.EnsureCreated();
            if (!context.User.Any())
            {
                context.User.Add(new User()
                {
                    DrivingLicensePhoto = "DLF",
                    DrivingYearExperience = 5,
                    FullName = "Valentin Pilipeiko",
                    Id = new Guid(),
                    isBlocker = false,
                    Location = new Location()
                    {
                        Id = new Guid(),
                        Latitude = 5.5f,
                        Longitude = 2.5f
                    },
                    PassportPhoto = "PF",
                    PhoneNumber = "+375125124",
                    Rating = 5.5f,
                    RentRecords = new List<RentRecord>()
                    {
                        new RentRecord()
                        {
                            Id = new Guid(),
                            Locations = new List<Location>()
                            {
                                new Location()
                                {
                                    Id = new Guid(),
                                    Latitude = 7.4f,
                                    Longitude = 9.214f
                                }
                            },
                            Vehicle = new Vehicle()
                            {
                                Id = new Guid(),
                                Location = new Location()
                                {
                                    Id = new Guid(),
                                    Latitude = 2.4f,
                                    Longitude = 12312.214f
                                }
                            }
                        }
                    }
                });
            }

            context.SaveChanges();

        }
    }
}
