using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.API.Commands.Start
{
    public class StartCommandHandler : IRequestHandler<StartCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        public StartCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<Unit> Handle(StartCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

            project.Start();


            await _projectRepository.StartAsync(project);

            return Unit.Value;
        }
    }
}
