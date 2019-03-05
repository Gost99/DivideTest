using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TestForGL.Properties;

namespace TestForGL
{
    [TestFixture]
    public class DivideOperationTest
    {
        [Test, TestCaseSource("TestingData")]
        public void DivideByZero(string test)
        {
            var page = new CalculatorPage();

            if(!string.IsNullOrEmpty(test))
            {
                var buttonsToClick = page.BtnsToClick(test);
                foreach (var btn in buttonsToClick)
                {
                    btn.Click();
                }

                //divide by zero
                page.BtnDivide.Click();
                page.Btn0.Click();
                page.BtnEqual.Click();

                page.CloseDialogWindow.Click();
                var calculationResult = page.DividingResult.Text;
                Assert.That(IsResultExpected(calculationResult));
            }
        }
        public static List<string> TestingData
        {
            get
            {
                string[] stringSeparators = new string[] { "\r\n" };
                string[] fileLines = Resources.TestData.Split(stringSeparators, StringSplitOptions.None);

                return fileLines.ToList();
            }
        }

        private bool IsResultExpected(string input)
        {
            if (input.EndsWith("Error\n"))
                return true;
            else
                return false;
        }
    }
}
