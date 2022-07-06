using DevFreela.API.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsCommandHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectsViewModels()
        {
            // Arrange
            var projects = new List<Project>
            {
                new Project("Nome do Teste", "Descricaoo do Teste 1", 1, 2, 10000),
                new Project("Nome do Teste", "Descricaoo do Teste 2", 1, 2, 20000),
                new Project("Nome do Teste", "Descricaoo do Teste 3", 1, 2, 30000)
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery("");
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);


            //Act 
            var projectViewModelIList = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new System.Threading.CancellationToken()); 

            //Assert
            Assert.NotNull(projectViewModelIList);
            Assert.NotEmpty(projectViewModelIList);
            Assert.Equal(projects.Count, projectViewModelIList.Count);

            projectRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
        }
    }
}
