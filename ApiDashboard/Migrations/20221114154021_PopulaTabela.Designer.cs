// <auto-generated />
using ApiDashboard.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiDashboard.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221114154021_PopulaTabela")]
    partial class PopulaTabela
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApiDashboard.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Date_Preview")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.ToTable("TB_Card");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date_Preview = "2022-11-18 00:00:00",
                            Description = "Usar a branch master, fazer pull e iniciar a migração.",
                            Title = "Criar Migration"
                        },
                        new
                        {
                            Id = 2,
                            Date_Preview = "14/11/2022 12:40:19",
                            Description = "Colunas utilizadas: Código, Nome e Descrição do cliente.",
                            Title = "Listagem Clientes"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
