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

        public DbSet<Rol> Roles { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<TipoTejido> TiposTejido { get; set; }
        public DbSet<TipoHilo> TiposHilo { get; set; }
        public DbSet<Maquina> Maquinas { get; set; }
        public DbSet<Operario> Operarios { get; set; }
        public DbSet<EstadoPedido> EstadosPedido { get; set; }
        public DbSet<UnidadMedida> UnidadesMedida { get; set; }
        public DbSet<Moneda> Monedas { get; set; }
        public DbSet<TipoDocumento> TiposDocumento { get; set; }
        public DbSet<Almacen> Almacenes { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<RolPermiso> RolPermisos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallePedido> DetallesPedido { get; set; }
        public DbSet<CompraProveedor> ComprasProveedor { get; set; }
        public DbSet<DetalleCompraProveedor> DetallesCompraProveedor { get; set; }
        public DbSet<IngresoHilo> IngresosHilo { get; set; }
        public DbSet<Produccion> Producciones { get; set; }
        public DbSet<SalidaHilo> SalidasHilo { get; set; }
        public DbSet<Entrega> Entregas { get; set; }
        public DbSet<DocumentoPedido> DocumentosPedido { get; set; }
        public DbSet<HistorialEstadoPedido> HistorialEstadosPedido { get; set; }
        public DbSet<PagoProveedor> PagosProveedor { get; set; }
        public DbSet<CobranzaPedido> CobranzasPedido { get; set; }
        public DbSet<MantenimientoMaquina> MantenimientosMaquina { get; set; }
        public DbSet<AsistenciaOperario> AsistenciasOperario { get; set; }


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