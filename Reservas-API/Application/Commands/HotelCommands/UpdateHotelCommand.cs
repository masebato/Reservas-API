using FluentValidation;
using MediatR;

namespace Reservas_API.Application.Commands.HotelCommands
{
    public class UpdateHotelCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

        public string? City { get; set; }

        public bool? Status { get; set; }

        public int? Rating { get; set; }

        public string? Description { get; set; }

      
     
   
    }
}
