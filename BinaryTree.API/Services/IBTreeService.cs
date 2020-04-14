using BinaryTree.API.Models;
using System.Threading.Tasks;

namespace BinaryTree.API.Services
{
    public interface IBTreeService
    {
        public Task<BTreeListResponseDTO> CreateBTreeFromListAsync(BTreeListRequestDTO listDTO);

        public Task<BTreeLowestCommonAncestorResponseDTO> GetBTreeLowestCommonAncestorAsync(BTreeLowestCommonAncestorRequestDTO lowestAncestorDTO);
    }
}
