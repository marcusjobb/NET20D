using System;
using FluentAssertions;
using GherkinTillKod;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public class DaysTillChristmasSteps
    {
        private int days;

        private DateTime Today;

        [Given(@"the date is (.*)")]
        public void GivenTheDateIs(string today)
        {
            Today = DateTime.Parse($"{today},{DateTime.Now.Year}");

            //Today = DateTime.Parse("june 20,2021");
        }

        [Given(@"the date is not after Christmas")]
        public void GivenTheDateIsNotAfterChristmas()
        {
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int p0)
        {
            days.Should().Be(p0);
        }

        [Then(@"the result should more than (.*)")]
        public void ThenTheResultShouldMoreThan(int p0)
        {
            days.Should().BeGreaterThan(p0);
        }

        [When(@"asking for the amount of days")]
        public void WhenAskingForTheAmountOfDays()
        {
            days = ChristmasCounter.DaysTillChristmas(Today);
        }
    }
}