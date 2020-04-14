using System;
using System.Collections.Generic;

namespace BinaryTree.API.Entities
{
    public class BTree
    {
        #region Properties

        public Node RootNode { get; internal set; } = null;

        public string UUID { get; internal set; } = null;

        #endregion

        #region Constructors

        public BTree()
        {
            UUID = Guid.NewGuid().ToString();
        }

        public BTree(string uuid)
        {
            UUID = uuid;
        }

        #endregion

        #region Add nodes methods

        public void AddNodesFromList(List<int> list)
        {
            foreach (int value in list)
            {
                AddNode(value);
            }
        }

        public Node AddNode(int data)
        {
            Node node = AddNodeRecursively(RootNode, data);

            if (RootNode == null)
                RootNode = node;

            return node;
        }

        private Node AddNodeRecursively(Node node, int data)
        {
            if (node == null)
                node = new Node(data);
            else if (data < node.Data)
                node.LeftChildNode = AddNodeRecursively(node.LeftChildNode, data);
            else if (data > node.Data)
                node.RightChildNode = AddNodeRecursively(node.RightChildNode, data);   
            else
                System.Diagnostics.Debug.WriteLine($"node with value {data} already exists, value will be ignored!");

            return node;
        }

        #endregion

        #region Get traversals by order

        public List<int> GetTraversalPreOrder() => GetTraversalRecursively(RootNode, BinaryTreeOrderType.PreOrder);
        public List<int> GetTraversalPostOrder() => GetTraversalRecursively(RootNode, BinaryTreeOrderType.PostOrder);
        public List<int> GetTraversalInOrder() => GetTraversalRecursively(RootNode, BinaryTreeOrderType.InOrder);

        private List<int> GetTraversalRecursively(Node node, BinaryTreeOrderType orderType, List<int> traversalList = null)
        {
            if (traversalList == null)
                traversalList = new List<int> { };

            if (node != null)
            {
                if (orderType == BinaryTreeOrderType.PreOrder)
                    traversalList.Add(node.Data);

                GetTraversalRecursively(node.LeftChildNode, orderType, traversalList);

                if (orderType == BinaryTreeOrderType.InOrder)
                    traversalList.Add(node.Data);

                GetTraversalRecursively(node.RightChildNode, orderType, traversalList);

                if (orderType == BinaryTreeOrderType.PostOrder)
                    traversalList.Add(node.Data);
            }

            return traversalList;
        }

        #endregion

        #region Get node

        public Node GetNode(int value)
        {
            List<Node> nodeList = GetNodePathRecursively(RootNode, value);

            Node node = GetNodeOrAbortWhenNodeValueNotFound(nodeList, value);

            return node;
        }

        private Node GetNodeOrAbortWhenNodeValueNotFound(List<Node> nodeList, int value)
        {
            if (nodeList == null || nodeList.Count == 0 || nodeList[nodeList.Count - 1].Data != value)
                throw new NullReferenceException($"Binary tree node with value {value} not found!");

            return nodeList[nodeList.Count - 1];
        }

        public List<Node> GetNodePath(int value)
        {
            List<Node> nodeList = GetNodePathRecursively(RootNode, value);

            GetNodeOrAbortWhenNodeValueNotFound(nodeList, value);

            return nodeList;
        }

        private List<Node> GetNodePathRecursively(Node node, int value, List<Node> nodeList = null)
        {
            if (nodeList == null)
                nodeList = new List<Node> { };

            if(node != null)
            {
                nodeList.Add(node);

                if (value < node.Data)
                    GetNodePathRecursively(node.LeftChildNode, value, nodeList);
                else if(value > node.Data)
                    GetNodePathRecursively(node.RightChildNode, value, nodeList);
            }

            return nodeList;
        }

        #endregion

        private enum BinaryTreeOrderType
        {
            PreOrder,
            InOrder,
            PostOrder
        }
    }
}
