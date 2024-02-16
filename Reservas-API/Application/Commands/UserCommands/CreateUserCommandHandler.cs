using MediatR;
using Reservas_DOMAIN.AggregateModels.UserAggregate;

namespace Reservas_API.Application.Commands.UserCommands
{
    public class CreateUserCommandHandler: IRequestHandler<CreateUserCommand, bool>
    {

        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Name, request.Email, request.Password, request.Role);
            _userRepository.Add(user);
            var saveOk = await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return saveOk;
        }
    }
}
