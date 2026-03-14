using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task.Core.Models;
using Task.Core.Shared.Entities;

namespace Task.DataAccess.Configure
{
    public class TaskConfigure : IEntityTypeConfiguration<Tasks>
    {
        public TaskConfigure()
        {
        }

        public void Configure(EntityTypeBuilder<Tasks> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title)
                .IsRequired();
            builder.Property(x => x.Description)
                .IsRequired();
            builder.Property(x => x.Date)
                .IsRequired();

            builder.Ignore(x => x.DomainEvents);

        }
    }
}

