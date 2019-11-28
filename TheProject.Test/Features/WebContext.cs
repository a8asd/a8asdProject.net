

using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TheProject.Models;

namespace TheProject.Test.Features
{
    public class WebContext:IContext
    {
        private readonly Manager Manager = new Manager();

        private readonly IWebDriver driver = new ChromeDriver();
        private string home = "https://www.google.co.uk/";
        public string PageTitle => driver.Title.Substring(14);        
        
        public IEnumerable<Request> Requests =>Manager.Requests;
        public IEnumerable<Operator> Operators =>Manager.Operators;
        public IEnumerable<Client> Clients =>Manager.Clients;

        public void AddRequest(string clientName, string operatorName)
        {
            driver.Navigate().GoToUrl(home);
            var element = driver.FindElement(By.Name("q"));
            element.SendKeys($"add request {clientName} {operatorName}");
            Manager.AddRequest(clientName,operatorName);
        }

        public void AddClient(Client client)
        {
            driver.Navigate().GoToUrl(home);
            var element = driver.FindElement(By.Name("q"));
            element.SendKeys($"add client {client.Name} ");
            Manager.AddClient(client);
        }

        public void AddOperator(Operator op)
        {
            driver.Navigate().GoToUrl(home);
            var element = driver.FindElement(By.Name("q"));
            element.SendKeys($"add operator {op.Name}");
            Manager.AddOperator(op);
        }

        public void Quit()
        {
            driver.Quit();
        }
    }
}
