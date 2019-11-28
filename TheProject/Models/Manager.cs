using System;
using System.Collections.Generic;
using System.Linq;
using TheProject.Test.Unit;

namespace TheProject.Models
{
    public class Manager 
    {
        public IEnumerable<Request> Requests => requests;
        public IEnumerable<Operator> Operators =>operators;
        public IEnumerable<Client> Clients =>clients;

        private readonly List<Client> clients = new List<Client>();
        private readonly List<Request> requests = new List<Request>();
        private readonly List<Operator> operators = new List<Operator>();

        public void AddRequest(string clientName, string operatorName)
        {
            var client = GetClient(clientName);
            var @operator = GetOperator(operatorName);
            requests.Add(new Request {Client= client,Operator= @operator});
        }

        private Operator GetOperator(string operatorName)
        {
            return operators.First(x=> x.Name.Equals(operatorName));
        }

        private Client GetClient(string clientName)
        {
            var client = clients.FirstOrDefault(x => x.Name.Equals(clientName));
            if (ClientIsMissing(client))
                throw new MissingClientException();
            return client;
        }

        private static bool ClientIsMissing(Object client)
        {
            return client == null;
        }

        public void AddClient(Client client)
        {
            clients.Add(client);
        }

        public void AddOperator(Operator op)
        {
            operators.Add(op);
        }
    }
}