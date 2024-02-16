using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reservas_API.Application.Commands.HotelCommands;
using Reservas_API.Application.Commands.ReservationCommands;
using Reservas_API.Application.Queries.Reservation;
using Reservas_DOMAIN.Exception;

namespace Reservas_API.Controllers.V1
{
    public class ReservationController : MainController
    {

        private readonly IMediator _mediator;

        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("CreateReservation")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> CreateReservation(CreateReservationCommand createReservation)
        {

            try
            {
                var result = await _mediator.Send(createReservation);
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

        [Route("GetReservationsByUser")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> GetReservationsByUser(int idUser )
        {

            try
            {
                ReservationByUserQuery reservationByUser = new ReservationByUserQuery(idUser);
                var result = await _mediator.Send(reservationByUser);
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


        [Route("GetReservationsDetail")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> GetReservationsDetailByIdr(int reservationId)
        {

            try
            {
                ReservationDetailQuery reservationByUser = new ReservationDetailQuery(reservationId);
                var result = await _mediator.Send(reservationByUser);
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
