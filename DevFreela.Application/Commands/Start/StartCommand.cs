using MediatR;

namespace DevFreela.API.Commands.Start
{
    public class StartCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
