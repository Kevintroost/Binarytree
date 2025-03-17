using FluentAssertions;

public class BinaryTreeTests
{
    [Test]
    public void Insert_ShouldAddRootNode_WhenTreeIsEmpty()
    {
        var tree = new BinaryTree();
        tree.Insert(10);
        tree.Root.Should().NotBeNull();
        tree.Root!.Value.Should().Be(10);
    }

    [Test]
    public void Insert_ShouldAddNodeToLeft_WhenValueIsLessThanRoot()
    {
        var tree = new BinaryTree();
        tree.Insert(10);
        tree.Insert(5);
        tree.Root!.Left.Should().NotBeNull();
        tree.Root.Left!.Value.Should().Be(5);
    }

    [Test]
    public void Insert_ShouldAddNodeToRight_WhenValueIsGreaterThanRoot()
    {
        var tree = new BinaryTree();
        tree.Insert(10);
        tree.Insert(15);
        tree.Root!.Right.Should().NotBeNull();
        tree.Root.Right!.Value.Should().Be(15);
    }

    [Test]
    public void Insert_ShouldMaintainBinarySearchTreeProperty()
    {
        var tree = new BinaryTree();
        tree.Insert(10);
        tree.Insert(5);
        tree.Insert(15);
        tree.Insert(3);
        tree.Insert(7);
        tree.Insert(12);
        tree.Insert(18);

        tree.Root!.Left!.Left!.Value.Should().Be(3);
        tree.Root.Left.Right!.Value.Should().Be(7);
        tree.Root.Right!.Left!.Value.Should().Be(12);
        tree.Root.Right.Right!.Value.Should().Be(18);
    }

    [Test]
    public void DisplayTree_ShouldNotThrowException_WhenCalled()
    {
        var tree = new BinaryTree();
        tree.Insert(10);
        tree.Insert(5);
        tree.Insert(15);

        FluentActions.Invoking(() => BinaryTree.DisplayTree(tree.Root)).Should().NotThrow();
    }
}