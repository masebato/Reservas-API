using FluentValidation;
using MediatR;
using Reservas_API.Application.DTOs;
using Reservas_DOMAIN.AggregateModels.RoomAggregate;

namespace Reservas_API.Application.Commands.HotelCommands
{
    public class CreateHotelCommand : IRequest<bool>
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Rating { get; set; }
        public bool Status { get; set; }
        public List<CreateRoomDto> Rooms { get; set; } 




        public CreateHotelCommand() { }

        public CreateHotelCommand(string name, string description, string city, string address, int rating, bool status, List<CreateRoomDto> rooms)
        {
            Name = name;
            Description = description;
            City = city;
            Address = address;
            Rating = rating;
            Status = status;
            Rooms = rooms;
        }

        public class CreateHotelCommandValidator : AbstractValidator<CreateHotelCommand>
        {
            public CreateHotelCommandValidator()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.City).NotEmpty();
                RuleFor(x => x.Address).NotEmpty();
                RuleFor(x => x.Rating).InclusiveBetween(1, 5);
                RuleFor(x => x.Status).NotNull();
                RuleFor(x => x.Rooms).NotNull().WithMessage("La lista de habitaciones no puede estar vacía");

            }
        }
    }
}
