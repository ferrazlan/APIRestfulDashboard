using ApiDashboard.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDashboard.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        DateTime dt_preview = DateTime.Now;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Card> TB_Card { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuider)
        {
            modelBuider.Entity<Card>().HasData(
                new Card
                {
                    Id = 1,
                    Title = "Criar Migration",
                    Description = "Usar a branch master, fazer pull e iniciar a migração.",
                    Date_Preview = "18/11/2022 00:00:00"
                },
                new Card
                {
                    Id = 2,
                    Title = "Listagem Clientes",
                    Description = "Colunas utilizadas: Código, Nome e Descrição do cliente.",
                    Date_Preview = dt_preview.ToString()
                }
            );
        }
    }
}
