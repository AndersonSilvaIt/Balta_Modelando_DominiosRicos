using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class DocumentTests
    {
        // Red, Green, Refactor // metodologia boa para testes
        // primeiro faz gerar erros
        // depois faz todos os testes passarem
        // por ultimo realiza o refactor

        // deve retornar um erro quando o cnpj for inválido
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }

        // deve retornar um erro quando o cnpj for válido
        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJIsInvalid()
        {
            var doc = new Document("34110468000150", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }        

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }

        // deve retornar um erro quando o cnpj for válido
        [TestMethod]
        public void ShouldReturnSuccessWhenCPFIsInvalid()
        {
            var doc = new Document("34225545806", EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }                
    }
}
