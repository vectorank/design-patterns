using System.Diagnostics;
namespace DesignPatterns.Composite
{
    public class Test
    {
        /// <summary>
        /// Runs a performance test comparing a list-based search vs. a binary tree search.
        /// </summary>
        /// <returns>The root node of the generated binary tree.</returns>
        public INode RunTest()
        {
            var random = new Random();
            var list = new List<int>();

            // Generate a random value and use it as the root node of the binary tree
            list.Add(random.Next(1, 999999));
            INode root = new Node(list[0]);

            // Populate the binary tree with 9,999,999 additional random numbers
            for (int i = 0; i < 9999999; i++)
            {
                var value = random.Next(1, 999999);
                list.Add(value);
                root.Add(new Node(value));
            }

            Stopwatch sw = new Stopwatch();

            // Select a search value from the middle of the list
            var searchValue = list[list.Count / 2];

            // Measure time taken to search for the value in a List<T>
            sw.Start();
            var val = list.Find(x => x == searchValue);
            sw.Stop();
            Console.WriteLine("List search time: " + sw.ElapsedMilliseconds + " ms, value found: " + val);

            sw.Reset();

            // Measure time taken to search for the value in the binary tree
            sw.Start();
            var val2 = Search(root, searchValue);
            sw.Stop();
            Console.WriteLine("Binary tree search time: " + sw.ElapsedMilliseconds + " ms, depth=" + val2.depth + ", value=" + val2.node?.Value);

            return root; // Return the root node of the binary tree
        }

        /// <summary>
        /// Searches for a value in a binary search tree and returns the node along with its depth.
        /// </summary>
        /// <param name="root">The root node of the binary tree.</param>
        /// <param name="value">The value to search for.</param>
        /// <returns>A tuple containing the found node and its depth in the tree. If not found, returns (null, depth).</returns>
        public (INode node, int depth) Search(INode? root, int value)
        {
            int depth = 0;
            INode? current = root;

            // Traverse the binary tree iteratively
            while (current != null)
            {
                depth++;

                // Check if the current node holds the search value
                if (current.Value == value)
                    return (current, depth);

                // Navigate to the left or right subtree based on the value
                else if (current.Value < value)
                    current = current.Left;
                else
                    current = current.Right;
            }

            // Return null if the value is not found in the tree
            return (null, depth);
        }
    }
}
