using BinaryTree.API.Models;
using System.Threading.Tasks;

namespace BinaryTree.API.Services
{
    public interface IBTreeService
    {
        public Task<BTreeListResponseDTO> CreateBinaryTreeFromList(BTreeListRequestDTO listDTO);

        public Task<BTreeLowestCommonAncestorResponseDTO> GetLowestCommonAncestor(BTreeLowestCommonAncestorRequestDTO lowestAncestorDTO);
    }
}
