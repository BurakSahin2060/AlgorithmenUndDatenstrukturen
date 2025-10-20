using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using CommonDLL;

namespace DataStructureTests
{
    [TestFixture]
    public class DoubleLinkedListTests
    {
        private DoubleLinkedList<Person> list;
        private Person person1;
        private Person person2;
        private Person person3;

        [SetUp]
        public void SetUp()
        {
            list = new DoubleLinkedList<Person>();
            person1 = new Person("Burak", "Sahin", "m", 17);
            person2 = new Person("Ben", "Schmidt", "m", 30);
            person3 = new Person("Clara", "Fischer", "w", 28);
        }

        private Person[] ToArray(DoubleLinkedList<Person> dll)
        {
            var result = new List<Person>();
            var current = typeof(DoubleLinkedList<Person>).GetField("head", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(list);
            while (current != null)
            {
                result.Add((Person)current.GetType().GetProperty("Data").GetValue(current));
                current = current.GetType().GetProperty("Next").GetValue(current);
            }
            return result.ToArray();
        }

        [Test]
        public void InsertAfter_EmptyList_InsertsFirstElement()
        {
            list.InsertAfter(person1, person2);
            Assert.IsNotNull(list);
        }

        [Test]
        public void InsertBefore_EmptyList_InsertsFirstElement()
        {
            list.InsertBefore(person1, person2);
            Assert.IsNotNull(list);
        }

        [Test]
        public void InsertAfter_SingleElement_InsertsAfter()
        {
            list.InsertAfter(person1, person1);
            list.InsertAfter(person1, person2);
            int pos1 = list.PosOfElement(person1);
            int pos2 = list.PosOfElement(person2);
            Assert.AreEqual(0, pos1);
            Assert.AreEqual(1, pos2);
        }

        [Test]
        public void InsertBefore_SingleElement_InsertsBefore()
        {
            list.InsertAfter(person1, person1);
            list.InsertBefore(person1, person2);
            int pos2 = list.PosOfElement(person2);
            int pos1 = list.PosOfElement(person1);
            Assert.AreEqual(0, pos2);
            Assert.AreEqual(1, pos1);
        }

        [Test]
        public void InsertAfter_MultipleElements_InsertsCorrectly()
        {
            list.InsertAfter(person1, person1);
            list.InsertAfter(person1, person2);
            list.InsertAfter(person2, person3);
            Assert.AreEqual(0, list.PosOfElement(person1));
            Assert.AreEqual(1, list.PosOfElement(person2));
            Assert.AreEqual(2, list.PosOfElement(person3));
        }

        [Test]
        public void InsertBefore_MultipleElements_InsertsCorrectly()
        {
            list.InsertAfter(person1, person1);
            list.InsertAfter(person1, person2);
            list.InsertBefore(person2, person3);
            Assert.AreEqual(0, list.PosOfElement(person1));
            Assert.AreEqual(1, list.PosOfElement(person3));
            Assert.AreEqual(2, list.PosOfElement(person2));
        }

        [Test]
        public void InsertAfter_ElementNotFound_DoesNothing()
        {
            list.InsertAfter(person1, person1);
            list.InsertAfter(person2, person3);
            Assert.AreEqual(0, list.PosOfElement(person1));
            Assert.AreEqual(-1, list.PosOfElement(person2));
            Assert.AreEqual(-1, list.PosOfElement(person3));
        }

        [Test]
        public void InsertBefore_ElementNotFound_DoesNothing()
        {
            list.InsertAfter(person1, person1);
            list.InsertBefore(person2, person3);
            Assert.AreEqual(0, list.PosOfElement(person1));
            Assert.AreEqual(-1, list.PosOfElement(person2));
            Assert.AreEqual(-1, list.PosOfElement(person3));
        }

        [Test]
        public void PosOfElement_EmptyList_ReturnsMinusOne()
        {
            int position = list.PosOfElement(person1);
            Assert.AreEqual(-1, position);
        }

        [Test]
        public void PosOfElement_FoundElement_ReturnsCorrectPosition()
        {
            list.InsertAfter(person1, person1);
            list.InsertAfter(person1, person2);
            list.InsertAfter(person2, person3);
            Assert.AreEqual(0, list.PosOfElement(person1));
            Assert.AreEqual(1, list.PosOfElement(person2));
            Assert.AreEqual(2, list.PosOfElement(person3));
        }

        [Test]
        public void PosOfElement_ElementNotFound_ReturnsMinusOne()
        {
            list.InsertAfter(person1, person1);
            int position = list.PosOfElement(person2);
            Assert.AreEqual(-1, position);
        }

        [Test]
        public void PosOfElement_MultipleSameElements_ReturnsFirstPosition()
        {
            Person samePerson = new Person("Burak", "Sahin", "m", 17);
            list.InsertAfter(person1, person1);
            list.InsertAfter(person1, person2);
            list.InsertAfter(person2, samePerson);
            int position = list.PosOfElement(person1);
            Assert.AreEqual(0, position);
        }

        [Test]
        public void InsertLast_EmptyList_InsertsFirstElement()
        {
            list.InsertLast(person1);
            Assert.AreEqual(0, list.PosOfElement(person1));
        }

        [Test]
        public void InsertLast_MultipleElements_InsertsAtEnd()
        {
            list.InsertLast(person1);
            list.InsertLast(person2);
            list.InsertLast(person3);
            Assert.AreEqual(0, list.PosOfElement(person1));
            Assert.AreEqual(1, list.PosOfElement(person2));
            Assert.AreEqual(2, list.PosOfElement(person3));
        }

        [Test]
        public void InsertLast_WithExistingElements_AppendsToEnd()
        {
            list.InsertAfter(person1, person1);
            list.InsertAfter(person1, person2);
            list.InsertLast(person3);
            Assert.AreEqual(0, list.PosOfElement(person1));
            Assert.AreEqual(1, list.PosOfElement(person2));
            Assert.AreEqual(2, list.PosOfElement(person3));
        }

        [Test]
        public void InsertAfter_InsertsAfterTail_ActsLikeAppend()
        {
            list.InsertLast(person1);
            list.InsertLast(person2);
            list.InsertAfter(person2, person3);
            Assert.AreEqual(0, list.PosOfElement(person1));
            Assert.AreEqual(1, list.PosOfElement(person2));
            Assert.AreEqual(2, list.PosOfElement(person3));
        }

        [Test]
        public void BubbleSort_EmptyList_DoesNothing()
        {
            list.BubbleSort();
            Assert.AreEqual(0, ToArray(list).Length);
        }

        [Test]
        public void BubbleSort_SingleElement_RemainsUnchanged()
        {
            list.InsertLast(person1);
            list.BubbleSort();
            var result = ToArray(list);
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(person1, result[0]);
        }

        [Test]
        public void BubbleSort_MultipleElements_SortsByAgeThenLastName()
        {
            list.InsertLast(person2);
            list.InsertLast(person3);
            list.InsertLast(person1);
            list.BubbleSort();
            var result = ToArray(list);
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(person1, result[0]);
            Assert.AreEqual(person3, result[1]);
            Assert.AreEqual(person2, result[2]);
        }

        [Test]
        public void BubbleSort_AlreadySortedList_RemainsSorted()
        {
            list.InsertLast(person1);
            list.InsertLast(person3);
            list.InsertLast(person2);
            list.BubbleSort();
            var result = ToArray(list);
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(person1, result[0]);
            Assert.AreEqual(person3, result[1]);
            Assert.AreEqual(person2, result[2]);
        }

        [Test]
        public void BubbleSort_ReverseOrderList_SortsCorrectly()
        {
            list.InsertLast(person2);
            list.InsertLast(person3);
            list.InsertLast(person1);
            list.BubbleSort();
            var result = ToArray(list);
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(person1, result[0]);
            Assert.AreEqual(person3, result[1]);
            Assert.AreEqual(person2, result[2]);
        }

        [Test]
        public void BubbleSort_DuplicateAges_SortsByLastName()
        {
            var person4 = new Person("Anna", "Adler", "w", 28);
            list.InsertLast(person2);
            list.InsertLast(person3);
            list.InsertLast(person4);
            list.InsertLast(person1);
            list.BubbleSort();
            var result = ToArray(list);
            Assert.AreEqual(4, result.Length);
            Assert.AreEqual(person1, result[0]);
            Assert.AreEqual(person4, result[1]);
            Assert.AreEqual(person3, result[2]);
            Assert.AreEqual(person2, result[3]);
        }
    }
}