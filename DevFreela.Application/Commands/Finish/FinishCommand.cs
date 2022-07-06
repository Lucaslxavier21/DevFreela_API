using MediatR;

namespace DevFreela.API.Commands.Finish
{
    public class FinishCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string CreditCardNumber { get; set; }
        public string Cvv { get; set; }
        public string ExpiresAt { get; set; }
        public string FullName { get; set; }
    }
}
