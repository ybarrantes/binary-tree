using BinaryTree.API.Entities;
using System.Threading.Tasks;

namespace BinaryTree.API.Repository
{
    public interface IBTreeRepository
    {
        public Task SaveBTreeAsync(BTree binaryTree);

        public Task<BTree> GetBTreeAsync(string uuid);
    }
}
