﻿namespace MHFramework.Server;
public class BaseSettingsEntityConfiguration<TEntity> : BaseEntityConfiguration<TEntity>, IEntityTypeConfiguration<TEntity>
    where TEntity : BaseSettingsEntity
{
    public new virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);

        builder.HasIndex(e => e.Name).IsUnique();
        builder.Property(e => e.Name).IsRequired().HasMaxLength(500); ;
    }
}