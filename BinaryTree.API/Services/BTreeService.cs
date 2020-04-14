using BinaryTree.API.Entities;
using BinaryTree.API.Models;
using BinaryTree.API.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BinaryTree.API.Services
{
    public class BTreeService : IBTreeService
    {
        private readonly IBTreeRepository _binaryTreeRepository = null;

        public BTreeService(IBTreeRepository binaryTreeRepository)
        {
            _binaryTreeRepository = binaryTreeRepository;
        }

        public async Task<BTreeListResponseDTO> CreateBTreeFromListAsync(BTreeListRequestDTO listDTO)
        {
            if (listDTO.List.Count == 0)
                throw new ArgumentNullException("Numbers must be a list of integers");

            BTree binaryTree = new BTree();

            binaryTree.AddNodesFromList(listDTO.List);

            await _binaryTreeRepository.SaveBTreeAsync(binaryTree);

            BTreeListResponseDTO response = new BTreeListResponseDTO();
            response.UUID = binaryTree.UUID;

            return response;
        }

        public async Task<BTreeLowestCommonAncestorResponseDTO> GetBTreeLowestCommonAncestorAsync(BTreeLowestCommonAncestorRequestDTO lowestAncestorDTO)
        {
            BTree binaryTree = await _binaryTreeRepository.GetBTreeAsync(lowestAncestorDTO.UUID);

            List<Node> nodePathNumberA = binaryTree.GetNodePath(lowestAncestorDTO.NumberA);
            List<Node> nodePathNumberB = binaryTree.GetNodePath(lowestAncestorDTO.NumberB);

            int minNodesBetweenTwoNodePaths = Math.Min(nodePathNumberA.Count, nodePathNumberB.Count);

            Node lowestCommonAncestor = null;

            for(int i = 0; i < minNodesBetweenTwoNodePaths - 1; i++)
            {
                if (nodePathNumberA[i].Equals(nodePathNumberB[i]))
                {
                    lowestCommonAncestor = nodePathNumberA[i];
                }
            }

            if(lowestCommonAncestor == null)
                throw new NullReferenceException($"Lowest common ancestor between {lowestAncestorDTO.NumberA} and {lowestAncestorDTO.NumberB} was not found!");

            BTreeLowestCommonAncestorResponseDTO response = new BTreeLowestCommonAncestorResponseDTO();
            response.LowestCommonAncestor = lowestCommonAncestor.Data;

            return response;
        }
    }
}
