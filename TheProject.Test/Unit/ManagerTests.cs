using NUnit.Framework;
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
    }
}
