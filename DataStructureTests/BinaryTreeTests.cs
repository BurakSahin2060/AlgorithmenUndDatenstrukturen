using NUnit.Framework;
using System;
using System.Collections.Generic;
using CommonDLL;
using SortingAlgorithms;

[TestFixture]
public class BinaryTreeTests
{
    private BinaryTree<Person> tree;

    [SetUp]
    public void Setup()
    {
        tree = new BinaryTree<Person>();
    }

    [Test]
    public void TestInsertAndCount()
    {
        tree.Insert(new Person("Alice", "Smith", "Female", 30));
        tree.Insert(new Person("Bob", "Johnson", "Male", 25));
        tree.Insert(new Person("Charlie", "Brown", "Male", 35));

        Assert.AreEqual(3, tree.Count());
    }

    [Test]
    public void TestGetInOrder()
    {
        tree.Insert(new Person("Alice", "Smith", "Female", 30));
        tree.Insert(new Person("Bob", "Johnson", "Male", 25));
        tree.Insert(new Person("Charlie", "Brown", "Male", 35));

        // Assuming CompareTo sorts by Age then Nachname
        // Bob (25), Alice (30), Charlie (35)
        Assert.AreEqual(25, tree.Get(0).Alter);
        Assert.AreEqual("Johnson", tree.Get(0).Nachname);
        Assert.AreEqual(30, tree.Get(1).Alter);
        Assert.AreEqual("Smith", tree.Get(1).Nachname);
        Assert.AreEqual(35, tree.Get(2).Alter);
        Assert.AreEqual("Brown", tree.Get(2).Nachname);
    }

    [Test]
    public void TestSwap()
    {
        tree.Insert(new Person("Alice", "Smith", "Female", 30));
        tree.Insert(new Person("Bob", "Johnson", "Male", 25));
        tree.Insert(new Person("Charlie", "Brown", "Male", 35));

        // Before swap: Bob (0), Alice (1), Charlie (2)
        tree.Swap(0, 2);

        // After swap: Charlie (0), Alice (1), Bob (2)
        Assert.AreEqual(35, tree.Get(0).Alter);
        Assert.AreEqual("Brown", tree.Get(0).Nachname);
        Assert.AreEqual(30, tree.Get(1).Alter);
        Assert.AreEqual("Smith", tree.Get(1).Nachname);
        Assert.AreEqual(25, tree.Get(2).Alter);
        Assert.AreEqual("Johnson", tree.Get(2).Nachname);
    }

    [Test]
    public void TestSort()
    {
        // Insert in unsorted order
        tree.Insert(new Person("Charlie", "Brown", "Male", 35));
        tree.Insert(new Person("Alice", "Smith", "Female", 30));
        tree.Insert(new Person("Bob", "Johnson", "Male", 25));

        // Before sort, in-order should already be sorted because it's a BST
        Assert.AreEqual(25, tree.Get(0).Alter);
        Assert.AreEqual(30, tree.Get(1).Alter);
        Assert.AreEqual(35, tree.Get(2).Alter);

        // Now, to test sort, perhaps disrupt the order by swapping, then sort
        tree.Swap(0, 2); // Now: 35, 30, 25

        Assert.AreEqual(35, tree.Get(0).Alter);
        Assert.AreEqual(30, tree.Get(1).Alter);
        Assert.AreEqual(25, tree.Get(2).Alter);

        tree.Sort(); // Should sort back using BubbleSort

        Assert.AreEqual(25, tree.Get(0).Alter);
        Assert.AreEqual(30, tree.Get(1).Alter);
        Assert.AreEqual(35, tree.Get(2).Alter);
    }

    [Test]
    public void TestEmptyTree()
    {
        Assert.AreEqual(0, tree.Count());
        Assert.Throws<ArgumentOutOfRangeException>(() => tree.Get(0));
    }

    [Test]
    public void TestInvalidIndex()
    {
        tree.Insert(new Person("Alice", "Smith", "Female", 30));
        Assert.Throws<ArgumentOutOfRangeException>(() => tree.Get(-1));
        Assert.Throws<ArgumentOutOfRangeException>(() => tree.Get(1));
        Assert.Throws<ArgumentOutOfRangeException>(() => tree.Swap(0, 1));
    }
}