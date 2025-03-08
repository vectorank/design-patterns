# Composite Design Pattern in C#

This repository demonstrates the **Composite Design Pattern** using a **Binary Tree** structure. The Composite pattern allows treating individual objects and compositions of objects uniformly.

## Overview

In this example, we implement a binary tree where each node can be a **Node** or a **ReverseNode**, both implementing the **INode** interface. The `INode` interface acts as the **composite interface**, allowing uniform operations on both regular and reversed nodes.

## Composite Interface: `INode`

The `INode` interface defines the structure of tree nodes. It allows for adding and removing child nodes and accessing the parent node. 

```csharp
public interface INode
{
    INode? Left { get; set; }
    INode? Right { get; set; }
    INode? Parent { get; set; }
    int? Value { get; }
    void Add(INode node);
    void Remove();
    void SetValue(int value);
}
```

## Node Implementations

### `Node` Class
This is a standard binary tree node implementation that follows the `INode` interface.

```csharp
public class Node : INode, IDisposable
{
    private int? value;
    private INode? left, right, parent;
    
    public INode? Left { get => left; set => left = value; }
    public INode? Right { get => right; set => right = value; }
    public INode? Parent { get => parent; set => parent = value; }
    public int? Value { get => value; }
    
    public Node(int value)
    {
        this.value = value;
    }
    
    public void Add(INode node) { /* Add logic */ }
    public void Remove() { /* Remove logic */ }
    public void SetValue(int value) { this.value = value; }
    public void Dispose() { /* Dispose logic */ }
}
```

### `ReverseNode` Class
This class modifies the given value by making it negative, demonstrating how different node types can coexist under the same composite structure.

```csharp
public class ReverseNode : Node
{
    public ReverseNode(int value) : base(-value) { }
}
```

## Example Usage

```csharp
class Program
{
    static void Main(string[] args)
    {
        INode root = new Node(10);
        root.Add(new Node(5));
        root.Add(new ReverseNode(20));
    }
}
```

## Summary
- **INode** is the **Composite Interface** allowing both `Node` and `ReverseNode` to be treated uniformly.
- **Node** follows standard behavior, while **ReverseNode** modifies the stored value.
- The **Composite Pattern** enables handling tree structures where different node types can be managed under the same interface.

This implementation effectively showcases how the Composite Design Pattern can be used in a binary tree context.

