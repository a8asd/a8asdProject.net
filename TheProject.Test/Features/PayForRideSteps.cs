using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TheProject.Test.Features
{
    [Binding]
    public class PayForRideSteps
    {
        private List<InvoiceItem> invoiceItems = new List<InvoiceItem>();
        private List<Ride> rides = new List<Ride>();
        private List<Rate> rates = new List<Rate>();

        //[Given(@"Pat has traveled (.*) miles with Charlie")]
        //public void GivenPatHasTraveledMilesWithCharlie(decimal distance)
        //{
        //    Booking booking = new Booking
        //        {Customer = new Customer {Name = "Pat"}, Driver = new Driver {Name = "Charlie"}};
        //    ride.Booking = booking;
        //    ride.Distance = distance;
        //}

        [Given(@"These rides have occurred")]
        public void GivenTheseRidesHaveOccurred(Table table)
        {
            
            for (int i = 0; i<table.RowCount; i++)
            {
                var customer = table.Rows[i]["Customer"];
                var driver = table.Rows[i]["Driver"];
                var distance = table.Rows[i]["Distance"];

                Ride ride = new Ride();
                ride.Booking = new Booking() {Customer = new Customer() {Name = customer}, Driver = new Driver() { Name = driver}};
                ride.Distance = Decimal.Parse(distance);

                rides.Add(ride);
            }
        }


        [Given(@"theses rates exist")]
        public void GivenThesesRatesExist(Table table)
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                var distance = table.Rows[i]["Distance"];
                var amount = table.Rows[i]["Rate"];

                Rate rate = new Rate();
                rate.Distance = Decimal.Parse(distance);
                rate.Amount = Decimal.Parse(amount);

                rates.Add(rate);
            }
        }

        //[Given(@"the rate is £(.*) per mile")]
        //public void GivenTheRateIsPerMile(Decimal rate)
        //{
        //    ride.Rate = rate;
        //}


        [When(@"(.*) pays for the ride with (.*)")]
        public void WhenPatPaysForARideWithCharlie(string customer, string driver)
        {
            // find ride
            var ride = rides.FirstOrDefault(x => x.Booking.Customer.Name == customer && x.Booking.Driver.Name == driver);

            // find rate
            var rate = rates.Where(x => x.Distance < ride.Distance).OrderByDescending(x => x.Distance).FirstOrDefault();
            invoiceItems.Add(ride.Pay(rate));
        }
        
        [Then(@"these invoices are in the system")]
        public void ThenTheseInvoicesAreInTheSystem(Table table)
        {
           table.CompareToSet(invoiceItems);
        }




    }

    internal class Rate
    {
        public decimal Distance { get; set; }
        public decimal Amount { get; set; }
    }

    internal class Ride
    {
        internal decimal Distance;
        internal Booking Booking;

        internal InvoiceItem Pay(Rate rate)
        {
            InvoiceItem invoiceItem = new InvoiceItem();
            invoiceItem.Payee = Booking.Customer.Name;
            invoiceItem.Driver = Booking.Driver.Name;
            invoiceItem.Distance = this.Distance;


            invoiceItem.Amount = this.Distance * rate.Amount;

            return invoiceItem;
        }
    }
    
    internal class InvoiceItem
    {
        public string Payee { get; set; }
        public string Driver { get; set; }

        public decimal Distance { get; set; }

        public decimal Amount { get; set; }
    }
}
