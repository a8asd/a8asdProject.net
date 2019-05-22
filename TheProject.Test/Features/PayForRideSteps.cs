using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TheProject.Test.Features
{
    [Binding]
    public class PayForRideSteps
    {
        private List<InvoiceItem> invoiceItems = new List<InvoiceItem>();
        private Ride ride = new Ride();

        [Given(@"Pat has traveled (.*) miles with Charlie")]
        public void GivenPatHasTraveledMilesWithCharlie(decimal distance)
        {
            Booking booking = new Booking
                {Customer = new Customer {Name = "Pat"}, Driver = new Driver {Name = "Charlie"}};
            ride.Booking = booking;
            ride.Distance = distance;
        }
        
        [Given(@"the rate is £(.*) per mile")]
        public void GivenTheRateIsPerMile(Decimal rate)
        {
            ride.Rate = rate;
        }
        
        [When(@"Pat pays for the ride")]
        public void WhenPatPaysForTheRide()
        {
            invoiceItems.Add(ride.Pay());
        }
        
        [Then(@"these invoices are in the system")]
        public void ThenTheseInvoicesAreInTheSystem(Table table)
        {
           table.CompareToSet(invoiceItems);
        }
    }

    internal class Ride
    {
        internal decimal Distance;
        internal Booking Booking;
        internal decimal Rate;

        internal InvoiceItem Pay()
        {
            InvoiceItem invoiceItem = new InvoiceItem();
            invoiceItem.Payee = Booking.Customer.Name;
            invoiceItem.Driver = Booking.Driver.Name;
            invoiceItem.Distance = this.Distance;
            invoiceItem.Amount = this.Distance * this.Rate;

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
