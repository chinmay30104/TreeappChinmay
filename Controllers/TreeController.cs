using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TreeappChinmay.Data;
using TreeappChinmay.Models;
using System.Linq;
using System.Threading.Tasks;

namespace TreeappChinmay.Controllers
{
    public class TreeController : Controller
    {
        private readonly AppDbContext _context;

        public TreeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Tree/ViewTree
        public async Task<IActionResult> ViewTree()
        {
            // Load only active nodes
            var allNodes = await _context.TreeNode
                .Where(n => n.IsActive)
                .ToListAsync();

            // Send full list to ViewBag for recursion
            ViewBag.AllNodes = allNodes;

            // Return only root nodes to view
            var rootNodes = allNodes.Where(n => n.ParentNodeId == null).ToList();

            return View(rootNodes);
        }
    }
}
