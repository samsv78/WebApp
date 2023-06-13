using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models.Entities;

namespace WebApplication1.Models.EntityConfigs;

public class UserConfig:IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(p => p.FirstName).IsRequired();
        builder.Property(p => p.LastName).IsRequired();
        builder.Property(p => p.Username).IsRequired();
        builder.Property(p => p.Password).IsRequired();
        builder.Property(p => p.RegisterDate).IsRequired();
        builder.Property(p => p.UpdateDate).IsRequired();
    }
}