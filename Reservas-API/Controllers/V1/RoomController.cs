using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reservas_API.Application.Commands.RoomCommands;
using Reservas_DOMAIN.Exception;

namespace Reservas_API.Controllers.V1
{
    public class RoomController : MainController
    {

        private readonly IMediator _mediator;

        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("GetRoomById")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> GetRoomById(int roomId)
        {

            try
            {
                var result = await _mediator.Send(roomId);
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


        [Route("UpdateStatusRoom")]
        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdateStatusRoom(UpdateStatusRoomCommand updateStatusRoom)
        {

            try
            {
                var result = await _mediator.Send(updateStatusRoom);
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


        [Route("UpdateRoom")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdateRoom(UpdateRoomCommand updateRoomCommand)
        {

            try
            {
                var result = await _mediator.Send(updateRoomCommand);
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

        [Route("CreateRoom")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> CreateRoom(CreateRoomCommand createRoomCommand)
        {

            try
            {
                var result = await _mediator.Send(createRoomCommand);
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
