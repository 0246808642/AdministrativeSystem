using AdministrativeSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdministrativeSystem.Infrastructure.Data.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100); // limite de 100 caracteres

        builder.Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(150);
        
        builder.Property(c=> c.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        builder.Property<DateTime>("CreatedAt");
    }
}