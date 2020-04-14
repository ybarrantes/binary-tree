using System.ComponentModel.DataAnnotations;

namespace BinaryTree.API.Models
{
    public class BTreeLowestCommonAncestorRequestDTO
    {
        [Required]
        public string UUID { get; set; }

        [Required]
        public int NumberA { get; set; }

        [Required]
        public int NumberB { get; set; }
    }
}
