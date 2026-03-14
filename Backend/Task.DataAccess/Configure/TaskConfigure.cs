using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task.DataAccess.Entities;

namespace Task.DataAccess.Configure
{
	public class TaskConfigure : IEntityTypeConfiguration<TaskEntity>
    {
		public TaskConfigure() 
		{
		}

        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title)
                .IsRequired();
            builder.Property(x => x.Description)
                .IsRequired();
            builder.Property(x => x.Date)
                .IsRequired();
        }
    }
}

