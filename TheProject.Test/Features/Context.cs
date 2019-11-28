using System.Collections.Generic;
using TheProject.Models;

namespace TheProject.Test.Features
{
    public class Context : IContext
    {
        private readonly Manager Manager = new Manager();
        public IEnumerable<Request> Requests => Manager.Requests;
        public IEnumerable<Operator> Operators => Manager.Operators;
        public IEnumerable<Client> Clients => Manager.Clients;
        public void AddRequest(string clientName, string operatorName)
        {
            Manager.AddRequest(clientName,operatorName);
        }

        public void AddClient(Client client)
        {
            Manager.AddClient(client);
        }

        public void AddOperator(Operator op)
        {
            Manager.AddOperator(op);
        }

        public void Quit()
        {
        }
    }
}
