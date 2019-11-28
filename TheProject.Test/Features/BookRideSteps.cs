using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TheProject.Models;

namespace TheProject.Test.Features
{
    [Binding]
    public class BookRideSteps
    {
        private readonly IContext context;

        public BookRideSteps(IContext context)
        {
            this.context = context;
        }

        [Given(@"these operators")]
        public void GivenTheseOperators(Table table)
        {
            var operators = table.CreateSet<Operator>();
            foreach (var op in operators)
            {
                context.AddOperator(op);
            }
        }

        [Given(@"these clients")]
        public void TheseClients(Table table)
        {
            var clients = table.CreateSet<Client>();
            foreach (var client in clients)
            {
                context.AddClient(client);
            }
        }
        
        [When(@"(.*) Sends a request to (.*)")]
        public void WhenFredSendsARequestToMyTaxi(string clientName, string operatorName)
        {
            context.AddRequest(clientName, operatorName);
        }

        [Then(@"these requests exist")]
        public void ThenTheseRequestsExist(Table table)
        {
            var requestModels = new List<RequestModel>();
            foreach (var request in context.Requests)
            {
                requestModels.Add(new RequestModel{Client = request.Client.Name, Operator=request.Operator.Name});
            }
            table.CompareToSet(requestModels);
        }
    }

    public class RequestModel
    {
        public string Client { get; set; }
        public string Operator { get; set; }
    }
}
