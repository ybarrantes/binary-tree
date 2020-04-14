using BinaryTree.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BinaryTree.API.Repository
{
    public class BTreeRepository : IBTreeRepository
    {
        private const char NODE_LIST_STR_SEPARATOR = ',';

        private readonly IDistributedCache _redisCache = null;

        public BTreeRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        public async Task<BTree> GetBinaryTreeAsync(string uuid)
        {
            string concatTreeNodeList = await _redisCache.GetStringAsync(uuid);

            if (concatTreeNodeList == null)
                throw new NullReferenceException($"Binary tree with uuid '{uuid}' not found!");

            BTree binaryTree = new BTree(uuid);
            List<int> treeNodeList = new List<int>(Array.ConvertAll(concatTreeNodeList.Split(NODE_LIST_STR_SEPARATOR), int.Parse));

            binaryTree.AddNodesFromList(treeNodeList);

            treeNodeList = null;
            concatTreeNodeList = null;

            return binaryTree;
        }

        public async Task SaveBinaryTreeAsync(BTree binaryTree)
        {
            List<int> treeNodeList = binaryTree.GetTraversalPreOrder();
            string concatTreeNodeList = string.Join(NODE_LIST_STR_SEPARATOR, treeNodeList);

            await _redisCache.SetStringAsync(binaryTree.UUID, concatTreeNodeList);
        }
    }
}
