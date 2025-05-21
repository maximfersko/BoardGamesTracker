using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class GameSessionConfiguration : IEntityTypeConfiguration<GameSession>
{
    public void Configure(EntityTypeBuilder<GameSession> builder)
    {
        builder.HasKey(gs => gs.Id);

        builder.HasOne(gs => gs.Game)
            .WithMany(g => g.GameSessions)
            .HasForeignKey(gs => gs.GameId);

        builder.HasOne(gs => gs.CreatedBy)
            .WithMany(u => u.GameSessions)
            .HasForeignKey(gs => gs.CreatedById);

        builder.HasMany(gs => gs.Results)
            .WithOne(r => r.GameSession)
            .HasForeignKey(r => r.GameSessionId);
    }
}