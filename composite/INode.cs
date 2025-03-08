namespace DesignPatterns.Composite
{
    /// <summary>
    /// Represents a node in a binary tree structure, forming part of a Composite Design Pattern.
    /// </summary>
    public interface INode
    {
        /// <summary>
        /// Gets or sets the left child node of the current node.
        /// </summary>
        INode? Left { get; set; }

        /// <summary>
        /// Gets or sets the right child node of the current node.
        /// </summary>
        INode? Right { get; set; }

        /// <summary>
        /// Gets or sets the parent node of the current node.
        /// </summary>
        INode? Parent { get; set; }

        /// <summary>
        /// Gets the value stored in the node.
        /// This value is read-only and must be set through the SetValue method.
        /// </summary>
        int? Value { get; }

        /// <summary>
        /// Adds a child node to the binary tree while maintaining its structure.
        /// The implementation determines whether the node is placed in the left or right subtree.
        /// </summary>
        /// <param name="node">The node to be added as a child.</param>
        void Add(INode node);

        /// <summary>
        /// Removes the current node from the tree, detaching it from its parent and children.
        /// The implementation should handle reconnection of child nodes if necessary.
        /// </summary>
        void Remove();

        /// <summary>
        /// Updates the value of the node.
        /// </summary>
        /// <param name="value">The new integer value to be assigned.</param>
        void SetValue(int value);
    }

}
