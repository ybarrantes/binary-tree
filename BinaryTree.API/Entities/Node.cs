using System;
using System.Diagnostics.CodeAnalysis;

namespace BinaryTree.API.Entities
{
    public class Node : IDisposable, IEquatable<Node>
    {
        public int Data { get; }
        public Node LeftChildNode { get; set; } = null;
        public Node RightChildNode { get; set; } = null;

        public Node(int data)
        {
            Data = data;
        }

        public void Dispose()
        {
            LeftChildNode = RightChildNode = null;
        }

        public bool Equals([AllowNull] Node other)
        {
            return (other != null && other.Data.Equals(Data));
        }
    }
}
