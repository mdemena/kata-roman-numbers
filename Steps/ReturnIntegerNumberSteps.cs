using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace kata_roman_numbers.Steps
{
    [Binding]
    public class ReturnIntegerNumberSteps
    {
        private Entities.Number _numbre;

        [Given(@"I have a Roman number ""(.*)""")]
        public void GivenIHaveARomanNumber(string p0)
        {
            _numbre = new Entities.Number(p0);
        }
        
        [When(@"I send a conversion to Integer")]
        public void WhenISendAConversionToInteger()
        {
            _numbre.ConvertToInteger();
        }
        
        [Then(@"I obtain an Integer number (.*) that represents a Roman number")]
        public void ThenIObtainAnIntegerNumberThatRepresentsARomanNumber(int p0)
        {
            Assert.AreEqual(_numbre.intValue,p0);
        }
    }
}
