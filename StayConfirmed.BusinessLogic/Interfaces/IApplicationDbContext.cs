using Microsoft.EntityFrameworkCore;
using StayConfirmed.DataAccess.Entities;

namespace StayConfirmed.BusinessLogic.Interfaces;

public interface IApplicationDbContext
{
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    public DbSet<User> Users { get; set; }
    public DbSet<Stakeholder> Stakeholders { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<CheckRule> CheckRules { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Property> PropertyInfos { get; set; }
    public DbSet<ReservationComunication> ReservationComunications { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<ReservationOperationalStatus> ReservationOperationalStatuses { get; set; }
    public DbSet<PricingModel> PricingModels { get; set; }
    public DbSet<PropertyContact> PropertyContacts { get; set; }
    public DbSet<MapProvider> MapProviders { get; set; }
    public DbSet<PropertyProviderMapper> PropertyProviderMappers { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<ReservationCustomerStatus> ReservationCustomerStatuses { get; set; }
}