using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TreeappChinmay.Models
{
    public class TreeNode
    {
        [Key]
        public int NodeId { get; set; }

        [Required]
        public string? NodeName  { get; set; }   

        public int? ParentNodeId { get; set; }

        public bool IsActive { get; set; } 

        public DateTime StartDate { get; set; }

        [ForeignKey("ParentNodeId")]
        public TreeNode? ParentNode { get; set; }
        public ICollection<TreeNode>? ChildNodes { get; set; } 
    }
}
