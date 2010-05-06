using System;
using System.Collections.Generic;
using Common.Serialization;
using NUnit.Framework;

namespace Tests
{
    [Serializable]
    public class SerializationTestInnerClass
    {
        public Guid Id { get; set; }

        public bool Equals(SerializationTestInnerClass other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Id.Equals(Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (SerializationTestInnerClass)) return false;
            return Equals((SerializationTestInnerClass) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(SerializationTestInnerClass left, SerializationTestInnerClass right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SerializationTestInnerClass left, SerializationTestInnerClass right)
        {
            return !Equals(left, right);
        }
    }


    [Serializable]
    public class SerializationTestClass
    {
        public int Number { get; set; }
        public string String { get; set; }
        public SerializationTestInnerClass InnerClass { get; set; }

        public bool Equals(SerializationTestClass other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Number == Number && Equals(other.String, String) && Equals(other.InnerClass, InnerClass);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (SerializationTestClass)) return false;
            return Equals((SerializationTestClass) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = Number;
                result = (result*397) ^ (String != null ? String.GetHashCode() : 0);
                result = (result*397) ^ (InnerClass != null ? InnerClass.GetHashCode() : 0);
                return result;
            }
        }

        public static bool operator ==(SerializationTestClass left, SerializationTestClass right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SerializationTestClass left, SerializationTestClass right)
        {
            return !Equals(left, right);
        }
    }

    [TestFixture]
    public class SerializerTest
    {
        #region Setup/Teardown

        [SetUp]
        private void SetUp()
        {
        }

        #endregion

        private DataSerializer serializer;

        private static SerializationTestClass CreateSerializationTestClass()
        {
            return new SerializationTestClass
                       {Number = 1, String = "123", InnerClass = new SerializationTestInnerClass {Id = Guid.NewGuid()}};
        }

        [Test]
        public void TestSimple()
        {
            var dataToSerialize = new SerializationTestClass {Number = 1, String = "123"};
            serializer = new DataSerializer();
            byte[] bytes = serializer.Serialize(dataToSerialize);
            Assert.IsTrue(bytes.Length > 0);
            Assert.AreEqual(dataToSerialize, serializer.Deserialize<SerializationTestClass>(bytes));
        }

        [Test]
        public void TestWithIEnumerable()
        {
            var dataToSerialize = new[] {CreateSerializationTestClass(), CreateSerializationTestClass()};

            serializer = new DataSerializer();
            byte[] bytes = serializer.Serialize(dataToSerialize);
            CollectionAssert.AreEqual(dataToSerialize,
                                      serializer.Deserialize<IEnumerable<SerializationTestClass>>(bytes));
        }

        [Test]
        public void TestWithInnerClass()
        {
            var dataToSerialize = new SerializationTestClass
                                      {
                                          Number = 1,
                                          String = "123",
                                          InnerClass = new SerializationTestInnerClass {Id = Guid.NewGuid()}
                                      };
            serializer = new DataSerializer();
            byte[] bytes = serializer.Serialize(dataToSerialize);
            Assert.AreEqual(dataToSerialize, serializer.Deserialize<SerializationTestClass>(bytes));
        }
    }
}