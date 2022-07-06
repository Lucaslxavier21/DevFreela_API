using DevFreela.Application.ViewModels;
using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.API.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillDTO>>
    {

        private readonly ISkillRepository _skillRepository;
        public GetAllSkillsQueryHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<List<SkillDTO>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            return await _skillRepository.GetAll();
        }

        // USANDO SQL SERVER 

        /* using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT Id, Description FROM Skills";

                return sqlConnection.Query<SkillViewModel>(script).ToList();
            } */
    }
}
