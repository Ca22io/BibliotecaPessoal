using BibliotecaPessoal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaPessoal.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<LivroModel> Livros { get; set; }
    public DbSet<GeneroModel> Generos { get; set; }
    public DbSet<EmprestimoModel> Emprestimos { get; set; }
}
