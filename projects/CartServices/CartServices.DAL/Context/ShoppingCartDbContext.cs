using CartServices.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CartServices.DAL.Context
{
    public class ShoppingCartDbContext : DbContext
    {
        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options) : base(options) { }

        public DbSet<ShoppingCartSession> ShoppingCartSession => Set<ShoppingCartSession>();
        public DbSet<ShoppingCartSessionDetails> ShoppingCartSessionDetails => Set<ShoppingCartSessionDetails>();

    }
}
