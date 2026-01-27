//using NUnit.Framework;
//using CommonDLL;

//namespace DataStructureTests
//{
//    public class SingleLinkedListTests
//    {
//        private SingleLinkedList<Person> list;

//        [SetUp]
//        public void Setup()
//        {
//            list = new SingleLinkedList<Person>();
//        }

//        [Test]
//        public void AddPerson_ShouldAddPersonToList()
//        {
//            Person person = new Person("Anna", "Schmidt", "Weiblich", 25);
//            list.Add(person);
//            Assert.IsTrue(list.Contains(person), "Die Person sollte in der Liste enthalten sein.");
//        }

//        [Test]
//        public void ContainsPerson_WhenPersonNotInList_ShouldReturnFalse()
//        {
//            Person person1 = new Person("Anna", "Schmidt", "Weiblich", 25);
//            Person person2 = new Person("Ben", "Müller", "Männlich", 30);
//            list.Add(person1);
//            Assert.IsFalse(list.Contains(person2), "Die Person sollte nicht in der Liste enthalten sein.");
//        }

//        [Test]
//        public void ContainsPerson_WhenListEmpty_ShouldReturnFalse()
//        {
//            Person person = new Person("Anna", "Schmidt", "Weiblich", 25);
//            Assert.IsFalse(list.Contains(person), "Die leere Liste sollte keine Person enthalten.");
//        }

//        [Test]
//        public void AddMultiplePersons_ShouldContainAll()
//        {
//            Person person1 = new Person("Anna", "Schmidt", "Weiblich", 25);
//            Person person2 = new Person("Ben", "Müller", "Männlich", 30);
//            Person person3 = new Person("Clara", "Weber", "Weiblich", 22);

//            list.Add(person1);
//            list.Add(person2);
//            list.Add(person3);

//            Assert.IsTrue(list.Contains(person1), "Person1 sollte in der Liste enthalten sein.");
//            Assert.IsTrue(list.Contains(person2), "Person2 sollte in der Liste enthalten sein.");
//            Assert.IsTrue(list.Contains(person3), "Person3 sollte in der Liste enthalten sein.");
//        }

//        [Test]
//        public void InsertAfter_ShouldNotChangePositionOfElementBefore()
//        {
//            Person person1 = new Person("Anna", "Schmidt", "Weiblich", 25);
//            Person person2 = new Person("Ben", "Müller", "Männlich", 30);
//            Person person3 = new Person("Clara", "Weber", "Weiblich", 22);

//            list.Add(person1);
//            list.Add(person2);

//            int positionBefore = list.PosOfElement(person1);
//            list.InsertAfter(person1, person3);
//            int positionAfter = list.PosOfElement(person1);

//            Assert.AreEqual(positionBefore, positionAfter, "Die Position von person1 sollte sich nicht ändern.");
//            Assert.AreEqual(positionBefore + 1, list.PosOfElement(person3), "person3 sollte nach person1 eingefügt werden.");
//        }

//        [Test]
//        public void InsertAfter_ShouldInsertCorrectly()
//        {
//            Person person1 = new Person("Anna", "Schmidt", "Weiblich", 25);
//            Person person2 = new Person("Ben", "Müller", "Männlich", 30);
//            Person person3 = new Person("Clara", "Weber", "Weiblich", 22);

//            list.Add(person1);
//            list.Add(person2);
//            list.InsertAfter(person1, person3);

//            Assert.AreEqual(0, list.PosOfElement(person1), "person1 sollte an Position 0 sein.");
//            Assert.AreEqual(1, list.PosOfElement(person3), "person3 sollte an Position 1 sein.");
//            Assert.AreEqual(2, list.PosOfElement(person2), "person2 sollte an Position 2 sein.");
//        }

//        [Test]
//        public void InsertAfter_EmptyList_ShouldInsertElement()
//        {
//            Person person = new Person("Anna", "Schmidt", "Weiblich", 25);
//            list.InsertAfter(person, person);
//            Assert.AreEqual(0, list.PosOfElement(person), "Das Element sollte an Position 0 eingefügt werden.");
//        }

//        [Test]
//        public void PosOfElement_WhenElementExists_ShouldReturnCorrectPosition()
//        {
//            Person person1 = new Person("Anna", "Schmidt", "Weiblich", 25);
//            Person person2 = new Person("Ben", "Müller", "Männlich", 30);
//            Person person3 = new Person("Clara", "Weber", "Weiblich", 22);

//            list.Add(person1);
//            list.Add(person2);
//            list.Add(person3);

//            Assert.AreEqual(0, list.PosOfElement(person1), "person1 sollte an Position 0 sein.");
//            Assert.AreEqual(1, list.PosOfElement(person2), "person2 sollte an Position 1 sein.");
//            Assert.AreEqual(2, list.PosOfElement(person3), "person3 sollte an Position 2 sein.");
//        }

//        [Test]
//        public void PosOfElement_WhenElementNotInList_ShouldReturnMinusOne()
//        {
//            Person person1 = new Person("Anna", "Schmidt", "Weiblich", 25);
//            Person person2 = new Person("Ben", "Müller", "Männlich", 30);

//            list.Add(person1);

//            Assert.AreEqual(-1, list.PosOfElement(person2), "Nicht vorhandene Elemente sollten -1 zurückgeben.");
//        }
//    }
//}
