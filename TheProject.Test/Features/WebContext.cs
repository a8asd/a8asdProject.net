

using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TheProject.Models;

namespace TheProject.Test.Features
{
    public class WebContext:IContext
    {
        private readonly IWebDriver driver = new ChromeDriver();
        private string home = "https://www.google.co.uk/";
        public string PageTitle => driver.Title.Substring(14);        
        
        public IEnumerable<Request> Requests { get; } = new List<Request>();
        public IEnumerable<Operator> Operators { get; } = new List<Operator>();
        public IEnumerable<Client> Clients { get; } = new List<Client>();

        public void AddRequest(string clientName, string operatorName)
        {
            driver.Navigate().GoToUrl(home);
            var element = driver.FindElement(By.Name("q"));
            element.SendKeys($"add request {clientName} {operatorName}");
        }

        public void AddClient(Client client)
        {
            driver.Navigate().GoToUrl(home);
            var element = driver.FindElement(By.Name("q"));
            element.SendKeys($"add client {client.Name} ");
        }

        public void AddOperator(Operator op)
        {
            driver.Navigate().GoToUrl(home);
            var element = driver.FindElement(By.Name("q"));
            element.SendKeys($"add operator {op.Name}");
        }

        public void Quit()
        {
            driver.Quit();
        }
    }
}
