using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.API.Queries.GetProjectById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, ProjectDetailsViewModel>
    {
        private readonly IProjectRepository _projectRepository; 
        public GetByIdQueryHandler(IProjectRepository ProjectRepository)
        {
            _projectRepository = ProjectRepository;
        }
       
        public async Task<ProjectDetailsViewModel> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetDetailsByIdAsync(request.Id);

            if (project == null) return null;

            var projectDetailsViewModel = new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt,
                project.Client.FullName,
                project.Freelancer.FullName
                );

            return projectDetailsViewModel;
        }
    }
}
