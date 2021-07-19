using Timelogger.BLL.Services;
using Timelogger.BLL.Services.Interfaces;
using Timelogger.DAL.UnitOfWork;
using Timelogger.UnitTests.TestConfigurations;
using Xunit;

namespace Timelogger.UnitTests.Services
{
    public class ProjectTaskServiceTest : TestBaseFixture
    {
        readonly IProjectTaskService projectTaskService;

        public ProjectTaskServiceTest() : base() =>
            projectTaskService = new ProjectTaskService(new UnitOfWork(Context), Mapper);

        [Theory]
        [InlineData(1)]
        public void Project_ShouldReturnSomeTasks_WhenIdIs1(int id)
        {

            var result = projectTaskService.GetAllTasksByProjectIdAsync(id);

            
            Assert.NotEmpty((System.Collections.IEnumerable)result.Result);
        }
    }
}
