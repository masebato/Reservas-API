using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reservas_API.Application.Commands.UserCommands;
using Reservas_DOMAIN.Exception;


namespace Reservas_API.Controllers.V1
{
    public class UserController : MainController
    {

        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("CreateUser")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> CreateUser(CreateUserCommand createUser)
        {

            try
            {
                var result = await _mediator.Send(createUser);
                return await SuccessResquest(result);
            }
            catch (EntityNotFoundException r)
            {
                return await UnSuccessRequestNotFound(r.Message);
            }
            catch (ReservasException r)
            {
                return await UnSuccessRequest(r.Message);
            }
            catch (BadRequestException b)
            {
                return await UnSuccessRequest(b.Message);
            }
            catch (Exception e)
            {
                return await UnexpectedErrorResquest(e.Message);
            }
        }


    }
}
