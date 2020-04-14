using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BinaryTree.API.Models
{
    public class BTreeListRequestDTO
    {
        [Required]
        public List<int> List { get; set; }
    }
}
