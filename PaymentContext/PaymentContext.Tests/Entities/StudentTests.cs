using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Address _address;
        private readonly Document _document;
        private readonly Student _student;
        private readonly Subscription _subscription;
        private readonly Email _email;

        public StudentTests()
        {
            _name = new Name("Bruce", "Wayne");
            _document = new Document("10825319870", EDocumentType.CPF);
            _email = new Email("batman@dc.com");
            _address = new Address("Rua 1", "1234", "Bairro Legal", "Gotham", "SP", "BR", "13400123");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);  
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var payment = new PayPalPayment("12345678",DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document, _address, _email);

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSucessAddSubscription()
        {
            var payment = new PayPalPayment("12345678",DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document, _address, _email);

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }
    }
}
