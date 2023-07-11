using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using apiChamaAi.Entities;

namespace chamaAi.Context
{
    public class ApiChamaAiContext : DbContext
    {
        public ApiChamaAiContext(DbContextOptions<ApiChamaAiContext> options)
            : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Motoboy> Motoboys { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Sede> Sedes { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Administrador> Administradores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>().OwnsOne(p => p.LocalizacaoClienteOrigem);

            modelBuilder.Entity<Pedido>().OwnsOne(p => p.LocalizacaoClienteDestino);

            modelBuilder.Entity<Sede>().OwnsOne(p => p.LocalizacaoSede);

            modelBuilder.Entity<Pedido>().OwnsOne(p => p.QualServico);

            // outras configurações

            base.OnModelCreating(modelBuilder);
        }
    }
}
