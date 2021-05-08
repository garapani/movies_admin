using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class MovieEntityTypeConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> movieEntityTypeBuilder)
        {
            movieEntityTypeBuilder.Property(e => e.MovieId).HasColumnName("MovieID");

            movieEntityTypeBuilder.OwnsOne(a => a.Image, i =>
            {
                i.WithOwner();
                i.Property(i => i.ImageUrl).HasColumnName("ImageUrl").IsRequired();
            }).Navigation(p => p.Image).IsRequired();

            movieEntityTypeBuilder.OwnsOne(a => a.Video, i =>
            {
                i.WithOwner();
                i.Property(i => i.VideoUrl).HasColumnName("VideoUrl").IsRequired();
            }).Navigation(p => p.Video);

            movieEntityTypeBuilder.OwnsOne(a => a.Language, i =>
            {
                i.WithOwner();
                i.Property(i => i.Name).HasColumnName("Language").IsRequired();
            }).Navigation(p => p.Language);

            movieEntityTypeBuilder.Property(m =>m.Keywords)
                .HasConversion(
                v => JsonSerializer.Serialize(v, null),
                v => JsonSerializer.Deserialize<List<Keyword>>(v, null),
                new ValueComparer<ICollection<Keyword>>(
                    (c1, c2) => c1.GetHashCode() == c2.GetHashCode(),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => (ICollection<Keyword>)c.ToList()));

            movieEntityTypeBuilder.Property(m => m.Genres)
                .HasConversion(
                v => JsonSerializer.Serialize(v, null),
                v => JsonSerializer.Deserialize<List<Genre>>(v, null),
                new ValueComparer<ICollection<Genre>>(
                    (c1, c2) => c1.GetHashCode() == c2.GetHashCode(),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => (ICollection<Genre>)c.ToList()));
        }
    }
}
