using NUnit.Framework;
using Faker.TestObjects;
using Faker;
using System;

namespace FakerTestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Faker.Faker faker = new Faker.Faker();
        }

        [Test]
        public void Test1()
        {
            Faker.Faker faker = new Faker.Faker();
            Assert.IsTrue(faker.Create<int>().GetType() == typeof(int));
        }

        [Test]
        public void Test2()
        {
            Faker.Faker faker = new Faker.Faker();
            Assert.IsTrue(faker.Create<string>().GetType() == typeof(System.String));
        }

        [Test]
        public void Test3()
        {
            Faker.Faker faker = new Faker.Faker();
            Assert.IsTrue(faker.Create<Food>().GetType() == typeof(Food));
        }

        [Test]
        public void Test4()
        {
            Faker.Faker faker = new Faker.Faker();
            Assert.IsTrue(faker.loadPlugin("C:/Users/Анастасия/source/repos/Faker/BoolGeneratorPlugin/bin/Debug/net5.0/BoolGeneratorPlugin.dll", typeof(bool)).GetType() == typeof(BoolGenerator));
        }

        [Test]
        public void Test5()
        {
            Faker.Faker faker = new Faker.Faker();
            Assert.IsTrue(faker.loadPlugin("C:/Users/Анастасия/source/repos/Faker/DateTimeGeneratorPlugin/bin/Debug/net5.0/DateTimeGeneratorPlugin.dll", typeof(DateTime)).GetType() == typeof(DateTimeGenerator));
        }
    }
}