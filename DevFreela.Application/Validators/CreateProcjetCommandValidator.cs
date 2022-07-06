using DevFreela.API.Commands.CreateProject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Validators
{
    public class CreateProcjetCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProcjetCommandValidator()
        {
            RuleFor(p => p.Description)
                .MaximumLength(255)
                .WithMessage("Tamnho máximo de Descrição é de 255 caracteres");

            RuleFor(p => p.Title)
                .MaximumLength(30)
                .WithMessage("Tamanho máximo de Título é de 30 caracteres");
        }
    }
}
