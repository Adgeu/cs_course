using DocumentsEF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace DocumentsEF
{
    public class DocumentsContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<DocumentStatus> DocumentStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
			const string connection = "Server=tcp:shadow-art.database.windows.net,1433;" +
                                      "Initial Catalog=reminder;" +
                                      "Persist Security Info=False;" +
                                      "User ID=a_faradjaev@shadow-art;" +
                                      "Password=5NL8x7wga6qS8RdbQAX8;" +
                                      "Encrypt=True;";

            optionsBuilder
				.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
				.UseSqlServer(connection, builder => builder.EnableRetryOnFailure());
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnEntityModelCreating(modelBuilder.Entity<Document>());
            OnEntityModelCreating(modelBuilder.Entity<City>());
            OnEntityModelCreating(modelBuilder.Entity<Address>());
            OnEntityModelCreating(modelBuilder.Entity<Position>());
            OnEntityModelCreating(modelBuilder.Entity<Employee>());
            OnEntityModelCreating(modelBuilder.Entity<Status>());
            OnEntityModelCreating(modelBuilder.Entity<DocumentStatus>());
        }

        private static void OnEntityModelCreating(EntityTypeBuilder<Document> documents)
        {
            documents.ToTable("Document");
            documents.Property(document => document.Id);
            documents.Property(document => document.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(250);
            documents.Property(document => document.Pages)
                .IsRequired();
            documents.HasKey(employees => employees.Id);
            documents.HasIndex(document => new { document.Name, document.Pages }).IsUnique();
        }

        private static void OnEntityModelCreating(EntityTypeBuilder<DocumentStatus> documentStatuses)
        {
            documentStatuses.ToTable("DocumentStatus");
            documentStatuses.Property(documentStatus => documentStatus.Id);            
            documentStatuses
                .HasOne(documentStatus => documentStatus.Document)
                .WithMany(document => document.DocumentStatuses)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            documentStatuses
                .HasOne(documentStatus => documentStatus.Sender)
                .WithMany(sender => sender.SenderDocuments)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            documentStatuses
                .HasOne(documentStatus => documentStatus.SenderAddress)
                .WithMany(senderAddress => senderAddress.SenderDocumentStatuses)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            documentStatuses
                .HasOne(documentStatus => documentStatus.Receiver)
                .WithMany(receiver => receiver.ReceiverDocuments)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            documentStatuses
                .HasOne(documentStatus => documentStatus.ReceiverAddress)
                .WithMany(receiverAddress => receiverAddress.ReceiverDocumentStatuses)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            documentStatuses
                .HasOne(documentStatus => documentStatus.Status)
                .WithMany(status => status.DocumentStatuses)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            documentStatuses.Property(documentStatus => documentStatus.DateTime)
                .IsRequired();
            documentStatuses.HasKey(documentStatus => documentStatus.Id);
        }

        private static void OnEntityModelCreating(EntityTypeBuilder<Employee> employees)
        {
            employees.ToTable("Employee");
            employees.Property(employee => employee.Id);
            employees.Property(employee => employee.FirstName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(250);
            employees.Property(employee => employee.LastName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(250);
            employees
                .HasOne(employee => employee.Position)
                .WithMany(positions => positions.Employees)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            employees.HasKey(employees => employees.Id);
        }

        private static void OnEntityModelCreating(EntityTypeBuilder<Position> positions)
        {
            positions.ToTable("Position");
            positions.Property(position => position.Id);
            positions.Property(position => position.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);
            positions.HasKey(position => position.Id);
            positions.HasIndex(position => position.Name).IsUnique();
        }

        private static void OnEntityModelCreating(EntityTypeBuilder<Status> statuses)
        {
            statuses.ToTable("Status");
            statuses.Property(status => status.Id);
            statuses.Property(status => status.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);
            statuses.HasKey(status => status.Id);
            statuses.HasIndex(status => status.Name).IsUnique();
        }

        private static void OnEntityModelCreating(EntityTypeBuilder<Address> addresses)
        {
            addresses.ToTable("Address");
            addresses.Property(address => address.Id);
            addresses.Property(address => address.Street)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(250);
            addresses.Property(address => address.House)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);
            addresses
                .HasOne(address => address.City)
                .WithMany(city => city.Addresses)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            addresses.HasKey(address => address.Id);
        }

        private static void OnEntityModelCreating(EntityTypeBuilder<City> cities)
        {
            cities.ToTable("City");
            cities.Property(city => city.Id);
            cities.Property(city => city.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(250);
            cities.HasKey(city => city.Id);
            cities.HasIndex(city => city.Name).IsUnique();
        }
    }
}
