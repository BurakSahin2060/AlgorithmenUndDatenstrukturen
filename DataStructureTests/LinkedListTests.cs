using NUnit.Framework;
using CommonDLL;

namespace DataStructureTests
{
    public class Tests
    {
        private SingleLinkedList<Person> list;

        [SetUp]
        public void Setup()
        {
            list = new SingleLinkedList<Person>();
        }

        [Test]
        public void AddPerson_ShouldAddPersonToList()
        {
            Person person = new Person("Anna", "Schmidt", "Weiblich", 25);
            list.Add(person);
            Assert.IsTrue(list.Contains(person), "Die Person sollte in der Liste enthalten sein.");
        }

        [Test]
        public void ContainsPerson_WhenPersonNotInList_ShouldReturnFalse()
        {
            Person person1 = new Person("Anna", "Schmidt", "Weiblich", 25);
            Person person2 = new Person("Ben", "Müller", "Männlich", 30);
            list.Add(person1);
            Assert.IsFalse(list.Contains(person2), "Die Person sollte nicht in der Liste enthalten sein.");
        }

        [Test]
        public void ContainsPerson_WhenListEmpty_ShouldReturnFalse()
        {
            Person person = new Person("Anna", "Schmidt", "Weiblich", 25);
            Assert.IsFalse(list.Contains(person), "Die leere Liste sollte keine Person enthalten.");
        }

        [Test]
        public void AddMultiplePersons_ShouldContainAll()
        {
            Person person1 = new Person("Anna", "Schmidt", "Weiblich", 25);
            Person person2 = new Person("Ben", "Müller", "Männlich", 30);
            Person person3 = new Person("Clara", "Weber", "Weiblich", 22);
            list.Add(person1);
            list.Add(person2);
            list.Add(person3);
            Assert.IsTrue(list.Contains(person1), "Person1 sollte in der Liste enthalten sein.");
            Assert.IsTrue(list.Contains(person2), "Person2 sollte in der Liste enthalten sein.");
            Assert.IsTrue(list.Contains(person3), "Person3 sollte in der Liste enthalten sein.");
        }

        [Test]
        public void InsertBefore_ExistingElement_ShouldInsertCorrectly()
        {
            Person person1 = new Person("Anna", "Schmidt", "Weiblich", 25);
            Person person2 = new Person("Ben", "Müller", "Männlich", 30);
            Person newPerson = new Person("Clara", "Weber", "Weiblich", 22);
            list.Add(person1);
            list.Add(person2);
            list.InsertBefore(person2, newPerson);
            Assert.IsTrue(list.Contains(newPerson), "Die neue Person sollte in der Liste enthalten sein.");
            Assert.IsTrue(list.Contains(person1), "Person1 sollte in der Liste enthalten sein.");
            Assert.IsTrue(list.Contains(person2), "Person2 sollte in der Liste enthalten sein.");
        }

        [Test]
        public void InsertBefore_HeadElement_ShouldInsertAtHead()
        {
            Person person1 = new Person("Anna", "Schmidt", "Weiblich", 25);
            Person newPerson = new Person("Ben", "Müller", "Männlich", 30);
            list.Add(person1);
            list.InsertBefore(person1, newPerson);
            Assert.IsTrue(list.Contains(newPerson), "Die neue Person sollte in der Liste enthalten sein.");
            Assert.IsTrue(list.Contains(person1), "Person1 sollte in der Liste enthalten sein.");
        }

        [Test]
        public void InsertBefore_NonExistingElement_ShouldNotInsert()
        {
            Person person1 = new Person("Anna", "Schmidt", "Weiblich", 25);
            Person person2 = new Person("Ben", "Müller", "Männlich", 30);
            Person newPerson = new Person("Clara", "Weber", "Weiblich", 22);
            list.Add(person1);
            list.InsertBefore(person2, newPerson);
            Assert.IsFalse(list.Contains(newPerson), "Die neue Person sollte nicht in der Liste enthalten sein.");
            Assert.IsTrue(list.Contains(person1), "Person1 sollte in der Liste enthalten sein.");
        }

        [Test]
        public void InsertAfter_ExistingElement_ShouldInsertCorrectly()
        {
            Person person1 = new Person("Anna", "Schmidt", "Weiblich", 25);
            Person person2 = new Person("Ben", "Müller", "Männlich", 30);
            Person newPerson = new Person("Clara", "Weber", "Weiblich", 22);
            list.Add(person1);
            list.Add(person2);
            list.InsertAfter(person1, newPerson);
            Assert.IsTrue(list.Contains(newPerson), "Die neue Person sollte in der Liste enthalten sein.");
            Assert.IsTrue(list.Contains(person1), "Person1 sollte in der Liste enthalten sein.");
            Assert.IsTrue(list.Contains(person2), "Person2 sollte in der Liste enthalten sein.");
        }

        [Test]
        public void InsertAfter_NonExistingElement_ShouldNotInsert()
        {
            Person person1 = new Person("Anna", "Schmidt", "Weiblich", 25);
            Person person2 = new Person("Ben", "Müller", "Männlich", 30);
            Person newPerson = new Person("Clara", "Weber", "Weiblich", 22);
            list.Add(person1);
            list.InsertAfter(person2, newPerson);
            Assert.IsFalse(list.Contains(newPerson), "Die neue Person sollte nicht in der Liste enthalten sein.");
            Assert.IsTrue(list.Contains(person1), "Person1 sollte in der Liste enthalten sein.");
        }

        [Test]
        public void InsertAfter_HeadElement_ShouldInsertCorrectly()
        {
            Person person1 = new Person("Anna", "Schmidt", "Weiblich", 25);
            Person newPerson = new Person("Ben", "Müller", "Männlich", 30);
            list.Add(person1);
            list.InsertAfter(person1, newPerson);
            Assert.IsTrue(list.Contains(newPerson), "Die neue Person sollte in der Liste enthalten sein.");
            Assert.IsTrue(list.Contains(person1), "Person1 sollte in der Liste enthalten sein.");
        }
    }
}