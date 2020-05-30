using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OngekiMusics.Entities;

namespace OngekiMusics.Extensions {
    public static class EntityTypeBuilderExtension {
        /// <summary>
        /// CreatedAtは初回のみ、UpdatedAtは更新時に現在時刻をセットするよう設定します。
        /// </summary>
        public static EntityTypeBuilder<TEntity> UseTimestampedProperty<TEntity>(this EntityTypeBuilder<TEntity> entity) where TEntity : class, ITimestampable {
            entity.Property(d => d.CreatedAt).ValueGeneratedOnAdd();
            entity.Property(d => d.CreatedAt).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
            entity.Property(d => d.CreatedAt).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            entity.Property(d => d.UpdatedAt).ValueGeneratedOnAddOrUpdate();
            entity.Property(d => d.UpdatedAt).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
            entity.Property(d => d.UpdatedAt).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            return entity;
        }
    }
}
