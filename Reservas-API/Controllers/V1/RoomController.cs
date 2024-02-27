using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reservas_API.Application.Commands.RoomCommands;
using Reservas_API.Application.Queries.Reservation;
using Reservas_API.Application.Queries.Room;
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
                RoomByIdQuery roomByIdQuery = new RoomByIdQuery(roomId);
                var result = await _mediator.Send(roomByIdQuery);
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

        [Route("GetRoomByDate")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> GetRoomByDate(DateTime initialDate, DateTime finalDate)
        {

            try
            {
                RoomByDateQuery roomByDateQuery = new RoomByDateQuery(initialDate,finalDate);
                var result = await _mediator.Send(roomByDateQuery);
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

        public async Task<IActionResult> UpdateStatusRoom(int idRoom)
        {

            try
            {
                UpdateStatusRoomCommand updateStatusRoom = new UpdateStatusRoomCommand(idRoom);

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
