namespace DesignPatterns.Composite
{
    /// <summary>
    /// Represents a node in a binary tree structure. Implements IDisposable to allow resource cleanup.
    /// </summary>
    public class Node : INode, IDisposable
    {
        // Private fields for storing node data and references to parent/child nodes
        private int? value = null;
        private INode? left = null, right = null, parent = null;

        /// <summary>
        /// Gets or sets the left child node.
        /// </summary>
        public INode? Left { get => left; set => left = value; }

        /// <summary>
        /// Gets or sets the right child node.
        /// </summary>
        public INode? Right { get => right; set => right = value; }

        /// <summary>
        /// Gets or sets the parent node.
        /// </summary>
        public INode? Parent { get => parent; set => parent = value; }

        /// <summary>
        /// Gets the value stored in the node.
        /// </summary>
        public int? Value { get => value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class with a specified value.
        /// </summary>
        /// <param name="value">The integer value to store in the node.</param>
        public Node(int value)
        {
            this.value = value;
        }

        /// <summary>
        /// Adds a node to the binary tree according to binary search tree rules.
        /// </summary>
        /// <param name="node">The node to be added.</param>
        public void Add(INode node)
        {
            if (node.Value > this.value)
            {
                // Add to left subtree if left is null; otherwise, recurse down
                if (this.left == null)
                {
                    this.left = node;
                    node.Parent = this;
                }
                else
                {
                    this.left.Add(node);
                }
            }
            else
            {
                // Add to right subtree if right is null; otherwise, recurse down
                if (this.right == null)
                {
                    this.right = node;
                    node.Parent = this;
                }
                else
                {
                    this.right.Add(node);
                }
            }
        }

        /// <summary>
        /// Removes this node from the tree by disconnecting it from its parent.
        /// Also removes all its child nodes recursively and disposes of resources.
        /// </summary>
        public void Remove()
        {
            if (parent != null)
            {
                if (parent.Left == this)
                    parent.Left = null;
                else
                    parent.Right = null;
            }

            // Recursively remove child nodes
            if (this.right != null) this.right.Remove();
            if (this.left != null) this.left.Remove();

            // Dispose of this node
            this.Dispose();
        }

        /// <summary>
        /// Updates the value of the node.
        /// </summary>
        /// <param name="value">The new value to set.</param>
        public void SetValue(int value)
        {
            this.value = value;
        }

        /// <summary>
        /// Disposes of the node by clearing references to its children, parent, and value.
        /// Suppresses finalization to optimize garbage collection.
        /// </summary>
        public void Dispose()
        {
            left = null;
            right = null;
            parent = null;
            value = null;

            // Suppress finalization to improve performance, as manual cleanup is done
            GC.SuppressFinalize(this);
        }
    }
}
