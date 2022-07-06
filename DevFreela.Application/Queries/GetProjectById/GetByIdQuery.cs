using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.API.Queries.GetProjectById
{
    public class GetByIdQuery : IRequest<ProjectDetailsViewModel>
    {
        public GetByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
 