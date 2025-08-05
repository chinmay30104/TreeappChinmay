using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TreeappChinmay.Data;
using TreeappChinmay.Models;

namespace TreeappChinmay.Controllers
{
    public class TreeNodesController : Controller
    {
        private readonly AppDbContext _context;

        public TreeNodesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TreeNodes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.TreeNode.Include(t => t.ParentNode);
            return View(await appDbContext.ToListAsync());
        }

        // GET: TreeNodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treeNode = await _context.TreeNode
                .Include(t => t.ParentNode)
                .FirstOrDefaultAsync(m => m.NodeId == id);
            if (treeNode == null)
            {
                return NotFound();
            }

            return View(treeNode);
        }

        // GET: TreeNodes/Create
        public IActionResult Create()
        {
            ViewData["ParentNodeId"] = new SelectList(_context.TreeNode, "NodeId", "NodeName");
            return View();
        }

        // POST: TreeNodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NodeId,NodeName,ParentNodeId,IsActive,StartDate")] TreeNode treeNode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(treeNode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentNodeId"] = new SelectList(_context.TreeNode, "NodeId", "NodeName", treeNode.ParentNodeId);
            return View(treeNode);
        }

        // GET: TreeNodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treeNode = await _context.TreeNode.FindAsync(id);
            if (treeNode == null)
            {
                return NotFound();
            }
            ViewData["ParentNodeId"] = new SelectList(_context.TreeNode, "NodeId", "NodeName", treeNode.ParentNodeId);
            return View(treeNode);
        }

        // POST: TreeNodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NodeId,NodeName,ParentNodeId,IsActive,StartDate")] TreeNode treeNode)
        {
            if (id != treeNode.NodeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(treeNode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreeNodeExists(treeNode.NodeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentNodeId"] = new SelectList(_context.TreeNode, "NodeId", "NodeName", treeNode.ParentNodeId);
            return View(treeNode);
        }

        // GET: TreeNodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treeNode = await _context.TreeNode
                .Include(t => t.ParentNode)
                .FirstOrDefaultAsync(m => m.NodeId == id);
            if (treeNode == null)
            {
                return NotFound();
            }

            return View(treeNode);
        }

        // POST: TreeNodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var treeNode = await _context.TreeNode.FindAsync(id);
            if (treeNode != null)
            {
                _context.TreeNode.Remove(treeNode);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreeNodeExists(int id)
        {
            return _context.TreeNode.Any(e => e.NodeId == id);
        }
    }
}
