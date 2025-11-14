using NUnit.Framework;
using CommonDLL;
using SortingAlgorithms;
using System.Reflection;
namespace DataStructureTests
{
    [TestFixture]
    public class BubbleSortTests
    {
        private BubbleSort<Person> sorter;
        private Node<Person> head;
        [SetUp]
        public void SetUp()
        {
            sorter = new BubbleSort<Person>();
        }
        private void BuildList(params Person[] persons)
        {
            head = null;
            Node<Person> tail = null;
            foreach (var p in persons)
            {
                var node = new Node<Person>(p);
                if (head == null)
                {
                    head = tail = node;
                }
                else
                {
                    tail.Next = node;
                    tail = node;
                }
            }
        }
        private Person[] ToArray(Node<Person> head)
        {
            var list = new List<Person>();
            var current = head;
            while (current != null)
            {
                list.Add(current.Data);
                current = current.Next;
            }
            return list.ToArray();
        }
        //[Test]
        //public void Sort_NullHead_DoesNothing()
        //{
        //    sorter.Sort(null);
        //    Assert.Pass();
        //}
        [Test]
        public void Sort_SingleNode_Unchanged()
        {
            BuildList(new Person("A", "B", "m", 20));
            sorter.Sort(head);
            Assert.AreEqual(20, head.Data.Alter);
        }
        [Test]
        public void Sort_TwoElements_OutOfOrder_Swaps()
        {
            var p1 = new Person("Young", "X", "m", 10);
            var p2 = new Person("Old", "Y", "m", 50);
            BuildList(p2, p1);
            sorter.Sort(head);
            var arr = ToArray(head);
            Assert.AreEqual(p1, arr[0]);
            Assert.AreEqual(p2, arr[1]);
        }
        [Test]
        public void Sort_MultipleElements_CorrectOrder_ByAgeThenLastName()
        {
            var persons = new[]
            {
                new Person("Ben", "Schmidt", "m", 30),
                new Person("Clara", "Fischer", "w", 28),
                new Person("Burak", "Sahin", "m", 17),
                new Person("Anna", "Adler", "w", 28),
                new Person("Tom", "Adler", "m", 28),
                new Person("Zoe", "Adler", "w", 28)
            };
            BuildList(persons[0], persons[1], persons[2], persons[3], persons[4], persons[5]);
            sorter.Sort(head);
            var sorted = ToArray(head);
            Assert.AreEqual(17, sorted[0].Alter);
            Assert.AreEqual("Adler", sorted[1].Nachname);
            Assert.AreEqual("Anna", sorted[1].Vorname);
            Assert.AreEqual("Adler", sorted[2].Nachname);
            Assert.AreEqual("Tom", sorted[2].Vorname);
            Assert.AreEqual("Adler", sorted[3].Nachname);
            Assert.AreEqual("Zoe", sorted[3].Vorname);
            Assert.AreEqual("Fischer", sorted[4].Nachname);
            Assert.AreEqual("Schmidt", sorted[5].Nachname);
        }
        [Test]
        public void Sort_AlreadySorted_NoUnnecessarySwaps()
        {
            var p1 = new Person("A", "X", "m", 10);
            var p2 = new Person("B", "Y", "m", 20);
            BuildList(p1, p2);
            sorter.Sort(head);
            Assert.AreEqual(p1, head.Data);
            Assert.AreEqual(p2, head.Next.Data);
        }
        [Test]
        public void Sort_DuplicateAges_UsesLastName()
        {
            var p1 = new Person("Tom", "Zimmer", "m", 25);
            var p2 = new Person("Anna", "Adler", "w", 25);
            BuildList(p1, p2);
            sorter.Sort(head);
            var arr = ToArray(head);
            Assert.AreEqual("Adler", arr[0].Nachname);
            Assert.AreEqual("Zimmer", arr[1].Nachname);
        }
        [Test]
        public void Sort_EqualPersons_StaysStable()
        {
            var p1 = new Person("Max", "Mustermann", "m", 18);
            var p2 = new Person("Max", "Mustermann", "m", 18);
            BuildList(p1, p2);
            sorter.Sort(head);
            Assert.AreSame(p1, head.Data);
            Assert.AreSame(p2, head.Next.Data);
        }
    }

    [TestFixture]
    public class InsertionSortTests
    {
        private InsertionSort<Person> sorter;
        private Node<Person> head;
        [SetUp]
        public void SetUp()
        {
            sorter = new InsertionSort<Person>();
        }
        private void BuildList(params Person[] persons)
        {
            head = null;
            Node<Person> tail = null;
            foreach (var p in persons)
            {
                var node = new Node<Person>(p);
                if (head == null)
                {
                    head = tail = node;
                }
                else
                {
                    tail.Next = node;
                    tail = node;
                }
            }
        }
        private Person[] ToArray(Node<Person> head)
        {
            var list = new List<Person>();
            var current = head;
            while (current != null)
            {
                list.Add(current.Data);
                current = current.Next;
            }
            return list.ToArray();
        }
        [Test]
        public void Sort_NullHead_DoesNothing()
        {
            sorter.Sort(null);
            Assert.Pass();
        }
        [Test]
        public void Sort_SingleNode_Unchanged()
        {
            BuildList(new Person("A", "B", "m", 20));
            sorter.Sort(head);
            Assert.AreEqual(20, head.Data.Alter);
        }
        [Test]
        public void Sort_TwoElements_OutOfOrder_Swaps()
        {
            var p1 = new Person("Young", "X", "m", 10);
            var p2 = new Person("Old", "Y", "m", 50);
            BuildList(p2, p1);
            sorter.Sort(head);
            var arr = ToArray(head);
            Assert.AreEqual(p1, arr[0]);
            Assert.AreEqual(p2, arr[1]);
        }
        [Test]
        public void Sort_MultipleElements_CorrectOrder_ByAgeThenLastName()
        {
            var persons = new[]
            {
                new Person("Ben", "Schmidt", "m", 30),
                new Person("Clara", "Fischer", "w", 28),
                new Person("Burak", "Sahin", "m", 17),
                new Person("Anna", "Adler", "w", 28),
                new Person("Tom", "Adler", "m", 28),
                new Person("Zoe", "Adler", "w", 28)
            };
            BuildList(persons[0], persons[1], persons[2], persons[3], persons[4], persons[5]);
            sorter.Sort(head);
            var sorted = ToArray(head);
            Assert.AreEqual(17, sorted[0].Alter);
            Assert.AreEqual("Adler", sorted[1].Nachname);
            Assert.AreEqual("Anna", sorted[1].Vorname);
            Assert.AreEqual("Adler", sorted[2].Nachname);
            Assert.AreEqual("Tom", sorted[2].Vorname);
            Assert.AreEqual("Adler", sorted[3].Nachname);
            Assert.AreEqual("Zoe", sorted[3].Vorname);
            Assert.AreEqual("Fischer", sorted[4].Nachname);
            Assert.AreEqual("Schmidt", sorted[5].Nachname);
        }
        [Test]
        public void Sort_AlreadySorted_NoUnnecessarySwaps()
        {
            var p1 = new Person("A", "X", "m", 10);
            var p2 = new Person("B", "Y", "m", 20);
            BuildList(p1, p2);
            sorter.Sort(head);
            Assert.AreEqual(p1, head.Data);
            Assert.AreEqual(p2, head.Next.Data);
        }
        [Test]
        public void Sort_DuplicateAges_UsesLastName()
        {
            var p1 = new Person("Tom", "Zimmer", "m", 25);
            var p2 = new Person("Anna", "Adler", "w", 25);
            BuildList(p1, p2);
            sorter.Sort(head);
            var arr = ToArray(head);
            Assert.AreEqual("Adler", arr[0].Nachname);
            Assert.AreEqual("Zimmer", arr[1].Nachname);
        }
        [Test]
        public void Sort_EqualPersons_StaysStable()
        {
            var p1 = new Person("Max", "Mustermann", "m", 18);
            var p2 = new Person("Max", "Mustermann", "m", 18);
            BuildList(p1, p2);
            sorter.Sort(head);
            Assert.AreSame(p1, head.Data);
            Assert.AreSame(p2, head.Next.Data);
        }
    }
}