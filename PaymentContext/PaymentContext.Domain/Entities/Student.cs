using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Student
    {
        private IList<Subscription> _subscriptions;
        public Student(string firstName, string lastName, string document, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; } // Endereço de Entrega

        // não consigo adicionar nada nessa propriedade, para isso, utilizo uma propriedade privada _subscriptions para realizar as alterações necessárias
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); }}

        public void AddSubscription(Subscription subscription)
        {
            // se já tiver uma assinatura ativa, cancela

            // Cancela todas as outras assinaturas, e coloca esta
            // como principal

            foreach(var sub in Subscriptions)
                sub.Inactivate();
            
            _subscriptions.Add(subscription);
        }
    }
}