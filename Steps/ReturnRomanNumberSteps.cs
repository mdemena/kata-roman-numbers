using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace kata_roman_numbers.Steps
{
    [Binding]
    public class ReturnRomanNumberSteps
    {
        private Entities.Number _number;

        [Given(@"I have entered an integer number (.*)")]
        public void GivenIHaveEnteredAnIntegerNumber(string p0)
        {
            _number = new Entities.Number(int.Parse(p0));
        }

        [When(@"I send a conversion"), Scope(Tag = "ReturnRomanNumber")]
        public void WhenISendAConversion()
        {
            _number.ConvertToRoman();
        }

        [Then(@"I obtain an Roman number (.*) which represents Integer number")]
        public void ThenIObtainAnRomanNumberWhichRepresentsIntegerNumber(string p0)
        {
            Assert.AreEqual(_number.romanValue, p0);
        }
    }
}
