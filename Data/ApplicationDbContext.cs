using Microsoft.EntityFrameworkCore;
using ProyectoRJ.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Auditoria> Auditorias { get; set; }
    public DbSet<DetalleSolicitud> DetallesSolicitudes { get; set; }
    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<InformeMecanico> InformesMecanicos { get; set; }
    public DbSet<Inventario> Inventarios { get; set; }
    public DbSet<Mantenimiento> Mantenimientos { get; set; }
    public DbSet<RelacionIngenierosEmpresas> RelacionesIngenierosEmpresas { get; set; }
    public DbSet<Reporte> Reportes { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<SalidaInventario> SalidasInventario { get; set; }
    public DbSet<Sector> Sectores { get; set; }
    public DbSet<Solicitud> Solicitudes { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuración de claves primarias
        modelBuilder.Entity<Auditoria>()
            .HasKey(a => a.IdAuditoria);

        modelBuilder.Entity<DetalleSolicitud>()
            .HasKey(d => d.IdDetalle);

        modelBuilder.Entity<Empresa>()
            .HasKey(e => e.IdEmpresa);

        modelBuilder.Entity<InformeMecanico>()
            .HasKey(i => i.IdInforme);

        modelBuilder.Entity<Inventario>()
            .HasKey(i => i.IdArticulo);

        modelBuilder.Entity<Mantenimiento>()
            .HasKey(m => m.IdMantenimiento);

        modelBuilder.Entity<RelacionIngenierosEmpresas>()
            .HasKey(r => r.IdRelacion);

        modelBuilder.Entity<Reporte>()
            .HasKey(r => r.IdReporte);

        modelBuilder.Entity<Rol>()
            .HasKey(r => r.IdRol);

        modelBuilder.Entity<SalidaInventario>()
            .HasKey(s => s.IdSalida);

        modelBuilder.Entity<Sector>()
            .HasKey(s => s.IdSector);

        modelBuilder.Entity<Solicitud>()
            .HasKey(s => s.IdSolicitud);

        modelBuilder.Entity<Usuario>()
            .HasKey(u => u.IdUsuario);

        // Configuración de precisión y escala para la propiedad Peso en Inventario
        modelBuilder.Entity<Inventario>()
            .Property(i => i.Peso)
            .HasColumnType("decimal(18,2)");

        // Configuración de relaciones y restricciones adicionales
        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.Sector)
            .WithMany(s => s.Usuarios)
            .HasForeignKey(u => u.IdSector)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Inventario>()
            .HasOne(i => i.Usuario)
            .WithMany(u => u.Inventarios)
            .HasForeignKey(i => i.IdUsuario)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<SalidaInventario>()
            .HasOne(s => s.Articulo)
            .WithMany(i => i.SalidasInventario)
            .HasForeignKey(s => s.IdArticulo)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<SalidaInventario>()
            .HasOne(s => s.Usuario)
            .WithMany(u => u.SalidasInventario)
            .HasForeignKey(s => s.IdUsuario)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Solicitud>()
            .HasOne(s => s.Empresa)
            .WithMany(e => e.Solicitudes)
            .HasForeignKey(s => s.IdEmpresa)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Solicitud>()
            .HasOne(s => s.Usuario)
            .WithMany(u => u.Solicitudes)
            .HasForeignKey(s => s.IdUsuario)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<DetalleSolicitud>()
            .HasOne(d => d.Solicitud)
            .WithMany(s => s.DetallesSolicitudes)
            .HasForeignKey(d => d.IdSolicitud)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<DetalleSolicitud>()
            .HasOne(d => d.Articulo)
            .WithMany(i => i.DetallesSolicitudes)
            .HasForeignKey(d => d.IdArticulo)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<RelacionIngenierosEmpresas>()
            .HasOne(r => r.Usuario)
            .WithMany(u => u.RelacionesIngenierosEmpresas)
            .HasForeignKey(r => r.IdUsuario)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<RelacionIngenierosEmpresas>()
            .HasOne(r => r.Empresa)
            .WithMany(e => e.RelacionesIngenierosEmpresas)
            .HasForeignKey(r => r.IdEmpresa)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<InformeMecanico>()
            .HasOne(i => i.Usuario)
            .WithMany(u => u.InformesMecanicos)
            .HasForeignKey(i => i.IdUsuario)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Mantenimiento>()
            .HasOne(m => m.Usuario)
            .WithMany(u => u.Mantenimientos)
            .HasForeignKey(m => m.IdUsuario)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Auditoria>()
            .HasOne(a => a.Usuario)
            .WithMany(u => u.Auditorias)
            .HasForeignKey(a => a.IdUsuario)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Reporte>()
            .HasOne(r => r.Usuario)
            .WithMany(u => u.Reportes)
            .HasForeignKey(r => r.IdUsuario)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Rol>()
            .HasMany(r => r.Usuarios)
            .WithOne(u => u.Rol)
            .HasForeignKey(u => u.IdRol)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
