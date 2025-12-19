using NUnit.Framework;
using CommonDLL;
using System;

[TestFixture]
public class QueueTests
{
    [Test]
    public void Enqueue_Dequeue_SingleElement()
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(42);
        Assert.AreEqual(1, queue.Count());
        Assert.AreEqual(42, queue.Dequeue());
        Assert.AreEqual(0, queue.Count());
    }

    [Test]
    public void Enqueue_Dequeue_MultipleElements()
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        Assert.AreEqual(3, queue.Count());
        Assert.AreEqual(1, queue.Dequeue());
        Assert.AreEqual(2, queue.Dequeue());
        Assert.AreEqual(3, queue.Dequeue());
        Assert.AreEqual(0, queue.Count());
    }

    [Test]
    public void Peek_DoesNotRemoveElement()
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(42);
        Assert.AreEqual(42, queue.Peek());
        Assert.AreEqual(1, queue.Count());
        Assert.AreEqual(42, queue.Dequeue());
    }

    [Test]
    public void IsEmpty_EmptyQueue_ReturnsTrue()
    {
        Queue<int> queue = new Queue<int>();
        Assert.IsTrue(queue.IsEmpty());
    }

    [Test]
    public void IsEmpty_NonEmptyQueue_ReturnsFalse()
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(42);
        Assert.IsFalse(queue.IsEmpty());
    }

    [Test]
    public void Dequeue_EmptyQueue_ThrowsException()
    {
        Queue<int> queue = new Queue<int>();
        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }

    [Test]
    public void Peek_EmptyQueue_ThrowsException()
    {
        Queue<int> queue = new Queue<int>();
        Assert.Throws<InvalidOperationException>(() => queue.Peek());
    }

    [Test]
    public void Get_ValidIndex_ReturnsElement()
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        Assert.AreEqual(1, queue.Get(0));
        Assert.AreEqual(2, queue.Get(1));
        Assert.AreEqual(3, queue.Get(2));
    }

    [Test]
    public void Get_InvalidIndex_ThrowsException()
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(1);
        Assert.Throws<ArgumentOutOfRangeException>(() => queue.Get(-1));
        Assert.Throws<ArgumentOutOfRangeException>(() => queue.Get(1));
    }

    [Test]
    public void Swap_ValidIndices_SwapsElements()
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Swap(0, 2);
        Assert.AreEqual(3, queue.Get(0));
        Assert.AreEqual(2, queue.Get(1));
        Assert.AreEqual(1, queue.Get(2));
    }

    [Test]
    public void Swap_SameIndices_DoesNothing()
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Swap(0, 0);
        Assert.AreEqual(1, queue.Get(0));
        Assert.AreEqual(2, queue.Get(1));
    }

    [Test]
    public void Swap_InvalidIndices_ThrowsException()
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        Assert.Throws<ArgumentOutOfRangeException>(() => queue.Swap(0, 2));
        Assert.Throws<ArgumentOutOfRangeException>(() => queue.Swap(-1, 1));
    }

    [Test]
    public void Sort_WithIntegers_SortsCorrectly()
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(3);
        queue.Enqueue(1);
        queue.Enqueue(4);
        queue.Enqueue(1);
        queue.Enqueue(5);
        queue.Sort();
        Assert.AreEqual(1, queue.Dequeue());
        Assert.AreEqual(1, queue.Dequeue());
        Assert.AreEqual(3, queue.Dequeue());
        Assert.AreEqual(4, queue.Dequeue());
        Assert.AreEqual(5, queue.Dequeue());
    }

    [Test]
    public void Sort_WithPersons_SortsByAgeThenName()
    {
        Queue<Person> queue = new Queue<Person>();
        queue.Enqueue(new Person("Alice", "Smith", "F", 30));
        queue.Enqueue(new Person("Bob", "Johnson", "M", 25));
        queue.Enqueue(new Person("Charlie", "Brown", "M", 30));
        queue.Enqueue(new Person("David", "Lee", "M", 25));
        queue.Sort();

        Person p1 = queue.Dequeue();
        Assert.AreEqual("Bob", p1.Vorname);
        Assert.AreEqual("Johnson", p1.Nachname);
        Assert.AreEqual(25, p1.Alter);

        Person p2 = queue.Dequeue();
        Assert.AreEqual("David", p2.Vorname);
        Assert.AreEqual("Lee", p2.Nachname);
        Assert.AreEqual(25, p2.Alter);

        Person p3 = queue.Dequeue();
        Assert.AreEqual("Charlie", p3.Vorname);
        Assert.AreEqual("Brown", p3.Nachname);
        Assert.AreEqual(30, p3.Alter);

        Person p4 = queue.Dequeue();
        Assert.AreEqual("Alice", p4.Vorname);
        Assert.AreEqual("Smith", p4.Nachname);
        Assert.AreEqual(30, p4.Alter);
    }

    [Test]
    public void Sort_EmptyQueue_DoesNothing()
    {
        Queue<int> queue = new Queue<int>();
        queue.Sort();
        Assert.AreEqual(0, queue.Count());
    }

    [Test]
    public void Sort_SingleElement_DoesNothing()
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(42);
        queue.Sort();
        Assert.AreEqual(42, queue.Dequeue());
    }
}