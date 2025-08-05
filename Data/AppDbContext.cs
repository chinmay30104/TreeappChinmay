using Microsoft.EntityFrameworkCore;    
using TreeappChinmay.Models;    

namespace TreeappChinmay.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<TreeappChinmay.Models.TreeNode> TreeNode { get; set; } = default!;
        
    }
}
