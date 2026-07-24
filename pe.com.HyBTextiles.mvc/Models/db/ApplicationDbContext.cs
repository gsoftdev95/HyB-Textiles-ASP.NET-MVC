using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace pe.com.HyBTextiles.mvc.Models.db
{
    public class ApplicationDbContext : DbContext
    {
        //llamamos a la cadena conexion
        public ApplicationDbContext() : base("DefaultConnection") { }


        public DbSet<Almacen> almacen { get; set; }
        public DbSet<AsistenciaOperario> asistenciaoperario { get; set; }
        public DbSet<Cliente> cliente { get; set; }
        public DbSet<CobranzaPedido> cobranzapedido { get; set; }
        public DbSet<CompraProveedor> comprasproveedor { get; set; }
        public DbSet<DetalleCompraProveedor> detallecompraproveedor { get; set; }
        public DbSet<DetallePedido> detallepedido { get; set; }
        public DbSet<DocumentoPedido> documentopedido { get; set; }
        public DbSet<Entrega> entrega { get; set; }
        public DbSet<EstadoPedido> estadopedido { get; set; }
        public DbSet<HistorialEstadoPedido> historialestadopedido { get; set; }
        public DbSet<IngresoHilo> ingresohilo { get; set; }
        public DbSet<MantenimientoMaquina> mantenimientomaquina { get; set; }
        public DbSet<Maquina> maquina { get; set; }
        public DbSet<Moneda> moneda { get; set; }
        public DbSet<Operario> operario { get; set; }
        public DbSet<PagoProveedor> pagoproveedor { get; set; }
        public DbSet<Pedido> pedido { get; set; }
        public DbSet<Permiso> permiso { get; set; }
        public DbSet<Produccion> produccion { get; set; }
        public DbSet<Proveedor> proveedor { get; set; }
        public DbSet<Rol> rol { get; set; }
        public DbSet<RolPermiso> rolpermiso { get; set; }
        public DbSet<SalidaHilo> salidahilo { get; set; }
        public DbSet<TipoDocumento> tipodocumento { get; set; }
        public DbSet<TipoHilo> tipohilo { get; set; }
        public DbSet<TipoTejido> tipotejido { get; set; }
        public DbSet<Turno> turno { get; set; }
        public DbSet<UnidadMedida> unidadmedida { get; set; }
        public DbSet<Usuario> usuario { get; set; }


        /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // ============================
            // USUARIO - ROL
            // ============================

            modelBuilder.Entity<Usuario>()
                .HasRequired(u => u.Rol)
                .WithMany()
                .HasForeignKey(u => u.codrol)
                .WillCascadeOnDelete(false);



            // ============================
            // ROLPERMISO
            // ============================

            modelBuilder.Entity<RolPermiso>()
                .HasRequired(rp => rp.Rol)
                .WithMany()
                .HasForeignKey(rp => rp.codrol)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<RolPermiso>()
                .HasRequired(rp => rp.Permiso)
                .WithMany()
                .HasForeignKey(rp => rp.codper)
                .WillCascadeOnDelete(false);



            // ============================
            // PEDIDO
            // ============================

            modelBuilder.Entity<Pedido>()
                .HasRequired(p => p.Cliente)
                .WithMany()
                .HasForeignKey(p => p.codcli)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Pedido>()
                .HasRequired(p => p.EstadoPedido)
                .WithMany()
                .HasForeignKey(p => p.codest)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Pedido>()
                .HasRequired(p => p.Usuario)
                .WithMany()
                .HasForeignKey(p => p.codusu)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Pedido>()
                .HasRequired(p => p.Moneda)
                .WithMany()
                .HasForeignKey(p => p.codmon)
                .WillCascadeOnDelete(false);



            // ============================
            // DETALLE PEDIDO
            // ============================

            modelBuilder.Entity<DetallePedido>()
                .HasRequired(d => d.Pedido)
                .WithMany()
                .HasForeignKey(d => d.codped)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<DetallePedido>()
                .HasRequired(d => d.TipoTejido)
                .WithMany()
                .HasForeignKey(d => d.codtte)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<DetallePedido>()
                .HasRequired(d => d.UnidadMedida)
                .WithMany()
                .HasForeignKey(d => d.codund)
                .WillCascadeOnDelete(false);


            // Evita borrado en cascada múltiple
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
        */
    }
}