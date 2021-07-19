using Timelogger.DAL.Entities;
using System.Collections.Generic;
using System.Text;
using System;
using System.Globalization;

namespace Timelogger.DAL.Base
{
    public static class TimeloggerContextSeeder
    {   

        public static void Seed(TimeloggerContext context)
        {
            var projects = new List<Project>
            {
                new Project
                {
                    Id = 1,
                    Name = "e-conomic programming test",
                    Deadline = DateTime.Parse("18/07/2021 23:59:59", CultureInfo.GetCultureInfo("en-GB").DateTimeFormat),                   
                    StartDate = DateTime.Parse("15/07/2021 18:30:00", CultureInfo.GetCultureInfo("en-GB").DateTimeFormat),
                    EndDate = DateTime.Parse("18/07/2021 23:00:00", CultureInfo.GetCultureInfo("en-GB").DateTimeFormat),
                    Status = Entities.Enums.ProjectStatus.Closed,
                    Tasks = new List<ProjectTask>
                    {
                        new ProjectTask
                        {
                            Id = 1,
                            Name = "Build the API Basics",
                            Type = "R & D",
                            StartDate = DateTime.Parse("15/07/2021 18:30:00", CultureInfo.GetCultureInfo("en-GB").DateTimeFormat),
                            EndDate = DateTime.Parse("15/07/2021 23:00:00", CultureInfo.GetCultureInfo("en-GB").DateTimeFormat),
                            ProjectId = 1
                        },
                        new ProjectTask
                        {
                            Id = 2,
                            Name = "Build the API Integration Test",
                            Type = "R & D",
                            StartDate = DateTime.Parse("16/07/2021 18:30:00", CultureInfo.GetCultureInfo("en-GB").DateTimeFormat),
                            EndDate = DateTime.Parse("16/07/2021 21:00:00", CultureInfo.GetCultureInfo("en-GB").DateTimeFormat),
                            ProjectId = 1
                        },
                        new ProjectTask
                        {
                            Id = 3,
                            Name = "Build the API Unit Test",
                            Type = "R & D",
                            StartDate = DateTime.Parse("16/07/2021 21:30:00", CultureInfo.GetCultureInfo("en-GB").DateTimeFormat),
                            EndDate = DateTime.Parse("16/07/2021 23:00:00", CultureInfo.GetCultureInfo("en-GB").DateTimeFormat),
                            ProjectId = 1
                        }
                    }
                    
                },
                new Project
                {
                    Id = 2,
                    Name = "e-conomic Interview",
                    Deadline = DateTime.Parse("20/07/2021 23:59:59", CultureInfo.GetCultureInfo("en-GB").DateTimeFormat),
                    StartDate = DateTime.Parse("20/07/2021 09:00:00", CultureInfo.GetCultureInfo("en-GB").DateTimeFormat),
                    EndDate = DateTime.Parse("20/07/2021 17:00:00", CultureInfo.GetCultureInfo("en-GB").DateTimeFormat),
                    Status = Entities.Enums.ProjectStatus.Open,
                    Tasks = new List<ProjectTask>
                    {
                        new ProjectTask
                        {
                            Id = 4,
                            Name = "Present the solution",
                            Type = "Meeting",
                            StartDate = DateTime.Parse("20/07/2021 11:00:00", CultureInfo.GetCultureInfo("en-GB").DateTimeFormat),
                            EndDate = DateTime.Parse("20/07/2021 12:00:00", CultureInfo.GetCultureInfo("en-GB").DateTimeFormat),
                            ProjectId = 2
                        }
                    }
                }
            };

            //foreach (var proj in projects)
            //{
            //    context.Projects.Add(proj);
            //    foreach (var task in proj.Tasks)
            //    {
            //        context.Tasks.Add(task);
            //    }
            //}

            foreach (var proj in projects)
            {
                context.Projects.Add(proj);                
            }

            context.SaveChanges();
        }
    }
}
