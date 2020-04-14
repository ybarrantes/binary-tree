using BinaryTree.API.Entities;
using System.Threading.Tasks;

namespace BinaryTree.API.Repository
{
    public interface IBTreeRepository
    {
        public Task SaveBinaryTreeAsync(BTree binaryTree);

        public Task<BTree> GetBinaryTreeAsync(string uuid);
    }
}
