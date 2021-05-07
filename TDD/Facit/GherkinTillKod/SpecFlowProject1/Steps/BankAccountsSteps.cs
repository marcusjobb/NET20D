using FluentAssertions;
using GherkinTillKod;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public class BankAccountsSteps
    {
        private BankAccount Bank;

        private BankAccount Card;

        [Given(@"account is (.*) SEK")]
        public void GivenAccountIsSEK(double amount)
        {
            Bank = new BankAccount() { Name = "Lönekonto", Number = "111222333", Cash = amount };
        }

        [Given(@"card has less than (.*)")]
        public void GivenCardHasLessThan(double amount)
        {
            Card = new BankAccount() { Name = "Kortkonto", Number = "4444555666", Cash = amount / 2 };
        }

        [Given(@"the bank account has (.*) SEK")]
        public void GivenTheBankAccountHasSEK(double amount)
        {
            Bank = new BankAccount() { Name = "Lönekonto", Number = "111222333", Cash = amount };
        }

        [Given(@"the card account contains less than (.*)")]
        public void GivenTheCardAccountContainsLessThan(double amount)
        {
            Card = new BankAccount() { Name = "Kortkonto", Number = "4444555666", Cash = amount / 2 };
        }

        [Then(@"card has (.*) SEK")]
        public void ThenCardHasSEK(double amount)
        {
            var missing = 120 - Card.Cash;
            Bank.Cash -= missing;
            Card.Cash += missing;
            Card.Cash.Should().Be(amount);
        }

        [Then(@"the card account should have (.*) SEK")]
        public void ThenTheCardAccountShouldHaveSEK(double amount)
        {
            Card.Cash.Should().Be(amount);
        }

        [When(@"transfering the amount missing on the card account")]
        public void WhenTransferingTheAmountMissingOnTheCardAccount()
        {
            var missing = 120 - Card.Cash;
            Bank.Cash -= missing;
            Card.Cash += missing;
        }
    }
}