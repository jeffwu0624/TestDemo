using System.Security.Cryptography.X509Certificates;
using FluentAssertions;
using Moq;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace TestDemo
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()
        {
            var mock = new Mock<IMockDemo>();

            mock.Setup(x => x.CreateNumber()).Returns(6);
            
            //var mock = Substitute.For<IMockDemo>();

            //mock.CreateNumber().Returns(6);

            var sutDemo = new SutDemo(mock.Object);

            Assert.AreEqual(12, sutDemo.CalNumber());

            sutDemo.CalNumber().Should().Be(12);
        }
    }

    public interface IMockDemo
    {
        int CreateNumber();
    }

    public class SutDemo
    {
        private readonly IMockDemo _mock;

        public SutDemo(IMockDemo mock)
        {
            _mock = mock;
        }

        public int CalNumber()
        {
            return _mock.CreateNumber() * 2;
        }
    }
}