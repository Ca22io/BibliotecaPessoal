using BibliotecaPessoal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaPessoal.Data;

public class ApplicationDbContext : IdentityDbContext<UsuarioModel, IdentityRole<int>, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<LivroModel> Livros { get; set; }
    public DbSet<GeneroModel> Generos { get; set; }
    public DbSet<EmprestimoModel> Emprestimos { get; set; }
}
