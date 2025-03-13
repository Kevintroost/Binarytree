class TreeNode
{
    public int Value;
    public TreeNode? Left;
    public TreeNode? Right;

    public TreeNode(int value)
    {
        Value = value;
        Left = Right = null;
    }
}

class BinaryTree
{
    public TreeNode? Root;

    public void Insert(int value)
    {
        Root = InsertRecursive(Root, value);
    }

    private static TreeNode InsertRecursive(TreeNode? node, int value)
    {
        if (node == null)
        {
            return new(value);
        }

        if (value < node.Value)
        {
            node.Left = InsertRecursive(node.Left, value);
        }
        else if (value > node.Value)
        {
            node.Right = InsertRecursive(node.Right, value);
        }

        return node;
    }
    public static void DisplayTree(TreeNode? node, string indent = "", bool isLeft = true)
    {
        if (node != null)
        {
            if (node.Right != null)
            {
                DisplayTree(node.Right, indent + (isLeft ? "│   " : "    "), false);
            }

            Console.WriteLine(indent + (isLeft ? "└── " : "┌── ") + node.Value);

            if (node.Left != null)
            {
                DisplayTree(node.Left, indent + (isLeft ? "    " : "│   "), true);
            }
        }
    }
}

class Program
{
    static void Main()
    {
        BinaryTree tree = new();

        Console.WriteLine("Binary Search Tree Program");
        Console.WriteLine("You can insert numbers into the tree.");
        Console.WriteLine("To exit the program, just enter 'exit'.");

        while (true)
        {
            Console.Write("\nEnter a number to insert into the tree (or type 'exit' to quit): ");
            string? input = Console.ReadLine();

            if (input == null || input.ToLower() == "exit")
            {
                break;
            }

            if (int.TryParse(input, out int value))
            {
                tree.Insert(value);
                Console.WriteLine($"Inserted {value} into the tree.");
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
            }

            Console.WriteLine("\nCurrent Tree Structure:");
            BinaryTree.DisplayTree(tree.Root);
        }

        Console.WriteLine("\nProgram ended.");
    }
}
