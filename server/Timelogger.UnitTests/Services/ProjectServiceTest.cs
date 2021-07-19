using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timelogger.BLL.Services;
using Timelogger.BLL.Services.Interfaces;
using Timelogger.DAL.Entities;
using Timelogger.DAL.UnitOfWork;
using Timelogger.UnitTests.TestConfigurations;
using Xunit;

namespace Timelogger.UnitTests.Services
{
    public class ProjectServiceTest : TestBaseFixture
    {
        readonly IProjectService projectService;

        public ProjectServiceTest() : base() =>
            projectService = new ProjectService(new UnitOfWork(Context), Mapper);

        [Theory]
        [InlineData(1)]
        public void Project_ShouldReturnExpectedProjectWithTitle_WhenIdIs1(int id)
        {

            var result = projectService.GetProjectByIdAsync(id);

            var expectedProject = new Project { Name = "e-conomic programming test" };

            Assert.Equal(expectedProject.Name, result.Result.Name);
        }
    }
}
