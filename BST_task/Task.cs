namespace BST_task
{
    public class Node
    {
        public int Val;
        public Node Left;
        public Node Right;

        public Node(int value)
        {
            Val = value;
            Left = null;
            Right = null;
        }
    }

    public class BinaryTree
    {
        public Node Root;

        public BinaryTree() => Root = null;

        public void Insert(int val) => Root = InsertRecursion(Root, val);

        private Node InsertRecursion(Node currNode, int val)
        {
            if (currNode == null)
            {
                return new Node(val);
            }

            if (val < currNode.Val)
            {
                currNode.Left = InsertRecursion(currNode.Left, val);
            }
            else if (val > currNode.Val)
            {
                currNode.Right = InsertRecursion(currNode.Right, val);
            }

            return currNode;
        }
    }

    public static class Task
    {
        public static void Main(string[] args)
        {
            Console.Title = "Task";
            BinaryTree tree1 = new BinaryTree();
            tree1.Insert(120);
            tree1.Insert(90);
            tree1.Insert(110);
            tree1.Insert(115);
            tree1.Insert(105);
            tree1.Insert(125);
            tree1.Insert(135);
            tree1.Insert(150);
            Console.WriteLine("Tree 1: ");
            Print(tree1.Root);

            BinaryTree tree2 = new BinaryTree();
            tree2.Insert(130);
            tree2.Insert(140);
            tree2.Insert(120);
            tree2.Insert(125);
            tree2.Insert(150);
            tree2.Insert(170);
            Console.WriteLine("\nTree 2: ");
            Print(tree2.Root);

            BinaryTree tree = MergeTree(tree1, tree2);

            Console.Title = "Result";
            Console.WriteLine("\nMerged tree: ");
            Print(tree.Root);
        }

        public static BinaryTree MergeTree(BinaryTree tree1, BinaryTree tree2)
        {
            List<int> list = new List<int>();

            TreeTraversalOrdered(tree1.Root, list);
            TreeTraversalOrdered(tree2.Root, list);

            list.Sort();

            BinaryTree tree = new BinaryTree();
            foreach (int val in list)
            {
                tree.Insert(val);
            }

            return tree;
        }

        public static void TreeTraversalOrdered(Node currNode, List<int> list)
        {
            if (currNode != null)
            {
                TreeTraversalOrdered(currNode.Left, list);

                if (!list.Contains(currNode.Val))
                {
                    list.Add(currNode.Val);
                }

                TreeTraversalOrdered(currNode.Right, list);
            }
        }

        public static void TreeTraversalUnordered(Node currNode)
        {
            if (currNode != null)
            {
                TreeTraversalUnordered(currNode.Left);
                Console.WriteLine(currNode.Val);
                TreeTraversalUnordered(currNode.Right);
            }
        }

        public static void Print(Node node)
        {
            if (node == null)
            {
                return;
            }

            Print(node.Left);
            Console.Write(node.Val + " ");
            Print(node.Right);
        }
    }
}
