using DevFreela.API.Commands.CreateComment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Validators
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(p => p.Content)
                .MaximumLength(255)
                .WithMessage("Tamanho limite do comentário é de 255 caracters");
        }
    }
}
