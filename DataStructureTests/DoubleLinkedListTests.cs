//using System;
//using System.Collections.Generic;
//using System.Reflection;
//using NUnit.Framework;
//using CommonDLL;

//namespace DataStructureTests
//{
//    [TestFixture]
//    public class DoubleLinkedListTests
//    {
//        private DoubleLinkedList<Person> list;
//        private Person p1, p2, p3, p4, p5;

//        [SetUp]
//        public void SetUp()
//        {
//            list = new DoubleLinkedList<Person>();
//            p1 = new Person("Burak", "Sahin", "m", 17);
//            p2 = new Person("Ben", "Schmidt", "m", 30);
//            p3 = new Person("Clara", "Fischer", "w", 28);
//            p4 = new Person("Anna", "Adler", "w", 28);
//            p5 = new Person("Tom", "Adler", "m", 28);
//        }

//        private Person[] ToArray()
//        {
//            var result = new List<Person>();
//            var current = typeof(DoubleLinkedList<Person>)
//                .GetField("head", BindingFlags.NonPublic | BindingFlags.Instance)
//                .GetValue(list);

//            while (current != null)
//            {
//                var data = current.GetType().GetProperty("Data")!.GetValue(current);
//                result.Add((Person)data!);
//                current = current.GetType().GetProperty("Next")!.GetValue(current);
//            }
//            return result.ToArray();
//        }

//        [Test]
//        public void InsertAfter_EmptyList_InsertsAsFirstElement()
//        {
//            list.InsertAfter(p1, p2); // elementBefore existiert nicht → fügt am Anfang ein
//            Assert.AreEqual(p2, ToArray()[0]);
//        }

//        [Test]
//        public void InsertBefore_EmptyList_InsertsAsFirstElement()
//        {
//            list.InsertBefore(p1, p2);
//            Assert.AreEqual(p2, ToArray()[0]);
//        }

//        [Test]
//        public void InsertAfter_SingleElement_InsertsCorrectly()
//        {
//            list.InsertLast(p1);
//            list.InsertAfter(p1, p2);
//            var arr = ToArray();
//            Assert.AreEqual(p1, arr[0]);
//            Assert.AreEqual(p2, arr[1]);
//        }

//        [Test]
//        public void InsertBefore_SingleElement_InsertsCorrectly()
//        {
//            list.InsertLast(p1);
//            list.InsertBefore(p1, p2);
//            var arr = ToArray();
//            Assert.AreEqual(p2, arr[0]);
//            Assert.AreEqual(p1, arr[1]);
//        }

//        [Test]
//        public void InsertLast_WorksCorrectly()
//        {
//            list.InsertLast(p1);
//            list.InsertLast(p2);
//            list.InsertLast(p3);
//            var arr = ToArray();
//            Assert.AreEqual(3, arr.Length);
//            Assert.AreEqual(p3, arr[2]);
//        }

//        [Test]
//        public void PosOfElement_ReturnsCorrectIndex()
//        {
//            list.InsertLast(p1);
//            list.InsertLast(p2);
//            Assert.AreEqual(0, list.PosOfElement(p1));
//            Assert.AreEqual(1, list.PosOfElement(p2));
//            Assert.AreEqual(-1, list.PosOfElement(p3));
//        }

//        [Test]
//        public void PosOfElement_DuplicateObjects_ReturnsFirstOccurrence()
//        {
//            var duplicate = new Person("Burak", "Sahin", "m", 17);
//            list.InsertLast(p1);
//            list.InsertLast(duplicate);
//            Assert.AreEqual(0, list.PosOfElement(p1));
//        }

//        [Test]
//        public void Sort_EmptyList_DoesNothing()
//        {
//            list.Sort();
//            Assert.AreEqual(0, ToArray().Length);
//        }

//        [Test]
//        public void Sort_SingleElement_Unchanged()
//        {
//            list.InsertLast(p1);
//            list.Sort();
//            Assert.AreEqual(p1, ToArray()[0]);
//        }

//        [Test]
//        public void Sort_SortsByAgeThenLastName()
//        {
//            list.InsertLast(p2); // 30, Schmidt
//            list.InsertLast(p3); // 28, Fischer
//            list.InsertLast(p1); // 17, Sahin
//            list.InsertLast(p4); // 28, Adler
//            list.InsertLast(p5); // 28, Adler (Tom)

//            list.Sort();

//            var sorted = ToArray();
//            Assert.AreEqual(17, sorted[0].Alter); // p1
//            Assert.AreEqual(28, sorted[1].Alter);
//            Assert.AreEqual("Adler", sorted[1].Nachname); // p4 Anna vor p5 Tom
//            Assert.AreEqual("Adler", sorted[2].Nachname);
//            Assert.AreEqual("Fischer", sorted[3].Nachname);
//            Assert.AreEqual("Schmidt", sorted[4].Nachname);
//        }

//        [Test]
//        public void Sort_AlreadySorted_StaysCorrect()
//        {
//            list.InsertLast(p1);
//            list.InsertLast(p4);
//            list.InsertLast(p3);
//            list.Sort();
//            var arr = ToArray();
//            Assert.AreEqual(p1, arr[0]);
//            Assert.AreEqual(p4, arr[1]);
//            Assert.AreEqual(p3, arr[2]);
//        }

//        [Test]
//        public void Sort_ReverseOrder_Works()
//        {
//            list.InsertLast(p2);
//            list.InsertLast(p3);
//            list.InsertLast(p1);
//            list.Sort();
//            var arr = ToArray();
//            Assert.AreEqual(p1, arr[0]);
//            Assert.AreEqual(p3, arr[1]);
//            Assert.AreEqual(p2, arr[2]);
//        }
//    }
//}