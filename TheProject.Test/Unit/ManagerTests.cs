using NUnit.Framework;
using TheProject.Exceptions;
using TheProject.Models;

namespace TheProject.Test.Unit
{
    public class ManagerTests
    {
        [Test]
        public void SenseCheck()
        {
            //Assert.Fail();
        }
        [Test]
        public void AddRequestThrowsExceptionOnMissingClient()
        {
            Manager manager = new Manager();
            string client = "fred";
            string oper = "mytaxi";
            //manager.AddClient(new Client{Name = client});
            Assert.Throws<MissingClientException>(() => manager.AddRequest(client, oper));
        }

        [Test]
        public void AddRequestThrowsExceptionOnMissingOperator()
        {
            Operator oper = new Operator();
            oper.Name = "paul";
            Manager manager = new Manager();
            string client = "fred";
            manager.AddClient(new Client{Name = client});
            Assert.Throws<MissingOperatorException>( () =>  manager.AddRequest(client, oper.Name) );
        }
    }
}
