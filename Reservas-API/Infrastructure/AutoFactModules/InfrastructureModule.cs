using Autofac;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Npgsql;
using Reservas_DOMAIN.AggregateModels.HotelAggregate;
using Reservas_DOMAIN.AggregateModels.ReservationAggregate;
using Reservas_DOMAIN.AggregateModels.RoomAggregate;
using Reservas_DOMAIN.AggregateModels.UserAggregate;
using Reservas_INFRASTRUCTURE.Finder.Reservation;
using Reservas_INFRASTRUCTURE.Finder.Room;
using Reservas_INFRASTRUCTURE.Repository;
using System.Data;

namespace Reservas_API.Infrastructure.AutoFactModules
{

    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // TODO Revisar el scope de cada uno de los siguientes componentes
            builder.RegisterType<HotelRepository>()
          .As<IHotelRepository>()
          .InstancePerLifetimeScope();

            builder.RegisterType<UserRepository>()
          .As<IUserRepository>()
          .InstancePerLifetimeScope();


            builder.RegisterType<ReservationRespository>()
          .As<IReservationRepository>()
          .InstancePerLifetimeScope();

            builder.RegisterType<ReservationFinder>()
        .As<IReservationFinder>()
        .InstancePerLifetimeScope();

            builder.RegisterType<RoomFinder>()
          .As<IRoomFinder>()
          .InstancePerLifetimeScope();

            builder.RegisterType<RoomRepository>()
         .As<IRoomRepository>()
         .InstancePerLifetimeScope();

        }
    }
}
