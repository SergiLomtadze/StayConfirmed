using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StayConfirmed.BusinessLogic.Interfaces;
using StayConfirmed.DataAccess.Entities;
using StayConfirmed.Persistence.Configurations;

namespace StayConfirmed.Persistence.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<User>(options), IApplicationDbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StakeholderEntityConfiguration());
        modelBuilder.ApplyConfiguration(new BrandEntityConfiguration());
        modelBuilder.ApplyConfiguration(new CheckRuleEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ProfileEntityConfiguration());       
        modelBuilder.ApplyConfiguration(new PropertyEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ReservationComunicationEntityConfiguration());
        modelBuilder.ApplyConfiguration(new RoleEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ReservationOperationalStatusEntityConfiguration());
        modelBuilder.ApplyConfiguration(new PricingModelEntityConfiguration());
        modelBuilder.ApplyConfiguration(new PropertyContactEntityConfiguration());
        modelBuilder.ApplyConfiguration(new MapProviderEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ReservationEntityConfiguration());
        modelBuilder.ApplyConfiguration(new WalletEntityConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionEntityConfiguration());
        modelBuilder.ApplyConfiguration(new CurrencyEntityConfiguration());
        modelBuilder.ApplyConfiguration(new CurrencyEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ReservationCustomerStatusEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new InputFromCustomerEntityConfiguration());
        base.OnModelCreating(modelBuilder);
    }

    public override DbSet<User> Users { get; set; }
    public DbSet<Stakeholder> Stakeholders { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<CheckRule> CheckRules { get; set; }
    public DbSet<Profile> Profiles { get; set;}
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
    public DbSet<InputFromCustomer> InputFromCustomers { get; set; }
}