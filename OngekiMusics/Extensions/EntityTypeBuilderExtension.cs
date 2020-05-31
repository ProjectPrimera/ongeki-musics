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
            var createdAt = entity.Property(d => d.CreatedAt);
            createdAt.ValueGeneratedOnAdd();
            createdAt.Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
            createdAt.Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            var updatedAt = entity.Property(d => d.UpdatedAt);
            updatedAt.ValueGeneratedOnAddOrUpdate();
            updatedAt.Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
            updatedAt.Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            return entity;
        }
    }
}
