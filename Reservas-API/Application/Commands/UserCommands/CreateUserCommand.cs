using FluentValidation;
using MediatR;


namespace Reservas_API.Application.Commands.UserCommands
{
    public class CreateUserCommand : IRequest<bool>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }




        public CreateUserCommand() { }

        public CreateUserCommand(string name, string email, string password, string role)
        {
            Name = name;
            Email = email;
            Email = email;
            Password = password;
            Role = role;
          
        }

        public class  CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
        {
            public CreateUserCommandValidator()
        {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.Email).EmailAddress();
                RuleFor(x => x.Password).NotEmpty();
                RuleFor(x => x.Role).NotEmpty().Must(x => x.Equals("VIAJERO") || x.Equals("AGENCIA"));

            }
        }   

    }
}
