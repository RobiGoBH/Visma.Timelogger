using AutoMapper;
using Timelogger.BLL.DTO;
using Timelogger.DAL.Entities;
using System;
using Xunit;
using Project = Timelogger.BLL.DTO.Project;

namespace Timelogger.UnitTests.Mappings
{
    public class MappingTest : IClassFixture<MappingFixture>
    { 
        private readonly IMapper mapper;

        public MappingTest(MappingFixture fixture) =>
            mapper = fixture.Mapper;

        [Fact]
        public void ShouldHaveValidConfig()
        {
            mapper.ConfigurationProvider
                .AssertConfigurationIsValid();
        }

        [Theory]
        [InlineData(typeof(DAL.Entities.Project), typeof(Project))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var project = new DAL.Entities.Project { Name = "test" };

            var result = mapper.Map<Project>(project);

            var expected = new Project { Name = "test" };

            Assert.Equal(expected.Name, result.Name);
        }
    }
}
