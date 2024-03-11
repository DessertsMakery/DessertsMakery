using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DessertsMakery.Persistence.Models.Telegram;

internal sealed class TelegramModeratorConfiguration : BaseEntityTypeConfiguration<TelegramModerator>
{
    protected override void Configure(EntityTypeBuilder<TelegramModerator> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Username).HasMaxLength(50).IsRequired();
        builder.HasOne(x => x.TelegramModeratorMenuState).WithOne(x => x.TelegramModerator);
    }
}
