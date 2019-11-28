using System.Collections.Generic;
using TheProject.Models;

namespace TheProject.Test.Features
{
    public interface IContext
    {
        IEnumerable<Request> Requests { get; }
        IEnumerable<Operator> Operators { get; }
        IEnumerable<Client> Clients { get; }
        void AddRequest(string clientName, string operatorName);
        void AddClient(Client client);
        void AddOperator(Operator op);
    }
}