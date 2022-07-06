using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;
        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository; 
        }
        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            // Utilizar o mesmo algoritmo para criar o hash dessa senha
            var passwordHash = _authService.ComputerSha256Hash(request.Password);

            // Buscar no banco de dados um user que tenha meu email e minha senha no formato hash
            var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

            // Se não existir, erro no login 
            if (user == null)
            {
                return null;
            }

            // Se exitir, gero o token usando os dados de usuário
            var token = _authService.GenerateJwtToken(user.Email, user.Role);

            return new LoginUserViewModel(user.Email, token);
        }
    }
}
