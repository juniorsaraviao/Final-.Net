using Belatrix.Models;
using Microsoft.EntityFrameworkCore;

namespace Belatrix.Repository.MySql
{
    public partial class ChinookContext : DbContext
    {
        public ChinookContext()
        {
        }

        public ChinookContext(DbContextOptions<ChinookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceLine> InvoiceLine { get; set; }
        public virtual DbSet<MediaType> MediaType { get; set; }
        public virtual DbSet<Playlist> Playlist { get; set; }
        public virtual DbSet<PlaylistTrack> PlaylistTrack { get; set; }
        public virtual DbSet<Track> Track { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("album", "chinook");

                entity.HasIndex(e => e.ArtistId)
                    .HasName("IFK_AlbumArtistId");

                entity.Property(e => e.AlbumId)
                    .HasColumnName("album_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ArtistId)
                    .HasColumnName("artist_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(160)
                    .IsUnicode(false);

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Album)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_album_artist_id");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("artist", "chinook");

                entity.Property(e => e.ArtistId)
                    .HasColumnName("artist_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(120)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer", "chinook");

                entity.HasIndex(e => e.SupportRepId)
                    .HasName("IFK_CustomerSupportRepId");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Company)
                    .HasColumnName("company")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasColumnName("postal_code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SupportRepId)
                    .HasColumnName("support_rep_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.SupportRep)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.SupportRepId)
                    .HasConstraintName("fk_customer_support_rep_id");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee", "chinook");

                entity.HasIndex(e => e.ReportsTo)
                    .HasName("IFK_EmployeeReportsTo");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("datetime(6)");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HireDate)
                    .HasColumnName("hire_date")
                    .HasColumnType("datetime(6)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasColumnName("postal_code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ReportsTo)
                    .HasColumnName("reports_to")
                    .HasColumnType("int(11)");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.ReportsToNavigation)
                    .WithMany(p => p.InverseReportsToNavigation)
                    .HasForeignKey(d => d.ReportsTo)
                    .HasConstraintName("fk_employee_reports_to");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre", "chinook");

                entity.Property(e => e.GenreId)
                    .HasColumnName("genre_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(120)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("invoice", "chinook");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("IFK_InvoiceCustomerId");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("invoice_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BillingAddress)
                    .HasColumnName("billing_address")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.BillingCity)
                    .HasColumnName("billing_city")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.BillingCountry)
                    .HasColumnName("billing_country")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.BillingPostalCode)
                    .HasColumnName("billing_postal_code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BillingState)
                    .HasColumnName("billing_state")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InvoiceDate)
                    .HasColumnName("invoice_date")
                    .HasColumnType("datetime(6)");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_invoice_customer_id");
            });

            modelBuilder.Entity<InvoiceLine>(entity =>
            {
                entity.ToTable("invoice_line", "chinook");

                entity.HasIndex(e => e.InvoiceId)
                    .HasName("IFK_InvoiceLineInvoiceId");

                entity.HasIndex(e => e.TrackId)
                    .HasName("IFK_InvoiceLineTrackId");

                entity.Property(e => e.InvoiceLineId)
                    .HasColumnName("invoice_line_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("invoice_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TrackId)
                    .HasColumnName("track_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("unit_price")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceLine)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_invoice_line_invoice_id");

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.InvoiceLine)
                    .HasForeignKey(d => d.TrackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_invoice_line_track_id");
            });

            modelBuilder.Entity<MediaType>(entity =>
            {
                entity.ToTable("media_type", "chinook");

                entity.Property(e => e.MediaTypeId)
                    .HasColumnName("media_type_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(120)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.ToTable("playlist", "chinook");

                entity.Property(e => e.PlaylistId)
                    .HasColumnName("playlist_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(120)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PlaylistTrack>(entity =>
            {
                entity.HasKey(e => new { e.PlaylistId, e.TrackId });

                entity.ToTable("playlist_track", "chinook");

                entity.HasIndex(e => e.TrackId)
                    .HasName("IFK_PlaylistTrackTrackId");

                entity.Property(e => e.PlaylistId)
                    .HasColumnName("playlist_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TrackId)
                    .HasColumnName("track_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Playlist)
                    .WithMany(p => p.PlaylistTrack)
                    .HasForeignKey(d => d.PlaylistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_playlist_track_playlist_id");

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.PlaylistTrack)
                    .HasForeignKey(d => d.TrackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_playlist_track_track_id");
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.ToTable("track", "chinook");

                entity.HasIndex(e => e.AlbumId)
                    .HasName("IFK_TrackAlbumId");

                entity.HasIndex(e => e.GenreId)
                    .HasName("IFK_TrackGenreId");

                entity.HasIndex(e => e.MediaTypeId)
                    .HasName("IFK_TrackMediaTypeId");

                entity.Property(e => e.TrackId)
                    .HasColumnName("track_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AlbumId)
                    .HasColumnName("album_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Bytes)
                    .HasColumnName("bytes")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Composer)
                    .HasColumnName("composer")
                    .HasMaxLength(220)
                    .IsUnicode(false);

                entity.Property(e => e.GenreId)
                    .HasColumnName("genre_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MediaTypeId)
                    .HasColumnName("media_type_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Milliseconds)
                    .HasColumnName("milliseconds")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("unit_price")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Track)
                    .HasForeignKey(d => d.AlbumId)
                    .HasConstraintName("fk_track_album_id");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Track)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("fk_track_genre_id");

                entity.HasOne(d => d.MediaType)
                    .WithMany(p => p.Track)
                    .HasForeignKey(d => d.MediaTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_track_media_type_id");
            });
        }
    }
}
