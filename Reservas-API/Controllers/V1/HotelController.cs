using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reservas_API.Application.Commands.HotelCommands;
using Reservas_DOMAIN.Exception;

namespace Reservas_API.Controllers.V1
{
    public class HotelController : MainController
    {
        private readonly IMediator _mediator;

        public HotelController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [Route("CreateHotel")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> CreateHotel(CreateHotelCommand createHotel)
        {

            try
            {
                var result = await _mediator.Send(createHotel);
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


        [Route("UpdateStatusHotel")]
        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdateStatusHotel(int idHotel)
        {

            try
            {
                UpdateStatusHotelCommand updateStatusHotel = new UpdateStatusHotelCommand(idHotel);

                var result = await _mediator.Send(updateStatusHotel);
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

        [Route("UpdateHotel")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdateHotel(UpdateHotelCommand updateHotel)
        {

            try
            {
                var result = await _mediator.Send(updateHotel);
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
