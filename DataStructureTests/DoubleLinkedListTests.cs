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

        //[Test]
        //public void InsertAfter_DuplicateElements_MaintainsOrder()
        //{
        //    Person duplicate = new Person("Anna", "Müller", "w", 25);
        //    list.InsertAfter(person1, person1);
        //    list.InsertAfter(person1, person2);
        //    list.InsertAfter(person1, duplicate);
        //    Assert.AreEqual(0, list.PosOfElement(person1));
        //    Assert.AreEqual(1, list.PosOfElement(person2));
        //    Assert.AreEqual(2, list.PosOfElement(duplicate));
        //}

        [Test]
        public void InsertBefore_DoubleLinkedListIntegrity_Maintained()
        {
            list.InsertAfter(person1, person1);
            list.InsertAfter(person1, person2);
            list.InsertBefore(person1, person3);
            list.InsertBefore(person2, new Person("Burak", "Sahin", "m", 17));
            Assert.AreEqual(0, list.PosOfElement(person3));
            Assert.AreEqual(1, list.PosOfElement(person1));
            Assert.AreEqual(2, list.PosOfElement(new Person("Burak", "Sahin", "m", 17)));
            Assert.AreEqual(3, list.PosOfElement(person2));
        }
    }
}

