
using System.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Reservas_DOMAIN.AggregateModels.EmergencycontactAggregate;
using Reservas_DOMAIN.AggregateModels.GuestAggregate;
using Reservas_DOMAIN.AggregateModels.HotelAggregate;
using Reservas_DOMAIN.AggregateModels.ReservationAggregate;
using Reservas_DOMAIN.AggregateModels.RoomAggregate;
using Reservas_DOMAIN.AggregateModels.UserAggregate;
using Reservas_DOMAIN.SeedWork;
using Reservas_INFRASTRUCTURE.EntityConfigurations;

namespace Reservas_INFRASTRUCTURE;

public partial class ReservasDbContext : DbContext, IUnitOfWork
{
    public virtual DbSet<Emergencycontact> Emergencycontacts { get; set; } = null!;

    public virtual DbSet<Guest> Guests { get; set; } = null!;

    public virtual DbSet<Hotel> Hotels { get; set; } = null!;

    public virtual DbSet<Reservation> Reservations { get; set; } = null!;   

    public virtual DbSet<Room> Rooms { get; set; } = null!;

    public virtual DbSet<User> Users { get; set; } = null!;

    private readonly IMediator _mediator;

    private IDbContextTransaction _currentTransaction;
    public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;
    public bool HasActiveTransaction => _currentTransaction != null;
    public ReservasDbContext()
    {
    }

    public ReservasDbContext(DbContextOptions<ReservasDbContext> options)
        : base(options)
    {
    }

    public ReservasDbContext(DbContextOptions<ReservasDbContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        System.Diagnostics.Debug.WriteLine("OrderingContext::ctor ->" + this.GetHashCode());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfiguration(new HotelTypeConfiguration());

        modelBuilder.ApplyConfiguration(new EmergencycontactTypeConfiguration());
        modelBuilder.ApplyConfiguration(new GuestTypeConfiguration());


        modelBuilder.ApplyConfiguration(new ReservationTypeConfiguration ());
        modelBuilder.ApplyConfiguration(new RoomTypeConfiguration());

        modelBuilder.ApplyConfiguration(new UserTypeConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        // Dispatch Domain Events collection. 
        // Choices:
        // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
        // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
        // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
        // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
       await _mediator.DispatchDomainEventsAsync(this);

        // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
        // performed through the DbContext will be committed
       
       var result = await base.SaveChangesAsync(cancellationToken);
       
       

        return true;
    }
    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        if (_currentTransaction != null) return null;

        _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

        return _currentTransaction;
    }

    public async Task CommitTransactionAsync(IDbContextTransaction transaction)
    {
        if (transaction == null) throw new ArgumentNullException(nameof(transaction));
        if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

        try
        {
            await SaveChangesAsync();
            transaction.Commit();
        }
        catch
        {
            RollbackTransaction();
            throw;
        }
        finally
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }

    public void RollbackTransaction()
    {
        try
        {
            _currentTransaction?.Rollback();
        }
        finally
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }
}
