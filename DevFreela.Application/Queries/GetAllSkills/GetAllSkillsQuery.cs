using DevFreela.Application.ViewModels;
using DevFreela.Core.DTOs;
using MediatR;

namespace DevFreela.API.Queries.GetAllSkills
{
    public class GetAllSkillsQuery : IRequest<List<SkillDTO>>
    {

    }
}
