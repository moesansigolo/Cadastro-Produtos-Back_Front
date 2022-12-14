// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Produtos.Persistence;

namespace Produtos.Persistence.Migrations
{
    [DbContext(typeof(ProdutosContext))]
    partial class ProdutosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Produtos.Domain.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("Produtos.Domain.FornecedorProduto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("FornecedorId")
                        .HasColumnType("int");

                    b.HasKey("ProdutoId", "FornecedorId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("FornecedoresProdutos");
                });

            modelBuilder.Entity("Produtos.Domain.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataValidade")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeProduto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Peso")
                        .HasColumnType("float");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.Property<int>("QntUnitaria")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Produtos.Domain.FornecedorProduto", b =>
                {
                    b.HasOne("Produtos.Domain.Fornecedor", "Fornecedor")
                        .WithMany("FornecedoresProdutos")
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Produtos.Domain.Produto", "Produto")
                        .WithMany("FornecedoresProdutos")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fornecedor");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Produtos.Domain.Fornecedor", b =>
                {
                    b.Navigation("FornecedoresProdutos");
                });

            modelBuilder.Entity("Produtos.Domain.Produto", b =>
                {
                    b.Navigation("FornecedoresProdutos");
                });
#pragma warning restore 612, 618
        }
    }
}
