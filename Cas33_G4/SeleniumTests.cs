using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Cas33_G4
{
    class SeleniumTests
    {
        // Declare a variable to hold our webdriver reference
        IWebDriver driver;

        [SetUp]
        // This method is called automatically every time a test is run
        public void SetUp()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void TestTableLondonOfficeAge()
        {
            GoToURL("https://www.seleniumeasy.com/test/table-sort-search-demo.html", 1000, 3000);
            FindElement(By.XPath("//input[@type='search']")).SendKeys("London");
            Wait(5000);
            IList<IWebElement> rows = FindElement(By.Id("example")).FindElement(By.TagName("tbody")).FindElements(By.TagName("tr"));
            string[] ages = { "47", "41", "43", "30", "66", "53", "19" };
            int counter = 0;
            int failed = 0;
            foreach(IWebElement row in rows)
            {
                IList<IWebElement> columns = row.FindElements(By.TagName("td"));
                IWebElement age = columns[3];
                if (age.Text != ages[counter])
                {
                    failed++;
                }
                counter++;
            }

            if (failed > 0)
            {
                Assert.Fail("There is a discrepancy in ages retrieved.");
            } else
            {
                Assert.Pass("OK");
            }
        }

        [TearDown]
        // This method is called automatically every time a test has finished its run
        public void TearDown()
        {
            // Close our webdriver and release memory
            driver.Close();
        }

        static private void Wait(int ms)
        {
            System.Threading.Thread.Sleep(ms);
        }

        private void GoToURL(string url, int msBefore = 1000, int msAfter = 2000)
        {
            Wait(msBefore);
            driver.Navigate().GoToUrl(url);
            Wait(msAfter);
        }

        public IWebElement FindElement(By selector)
        {
            // Declare a variable to hold our found element
            IWebElement elReturn = null;

            try
            {
                elReturn = driver.FindElement(selector);
            } catch (NoSuchElementException)
            {
                string File = "C:\\Kurs\\Cas33_G4.log";
                string Message = $"Element \"{selector.ToString()}\" is not found.";
                FileClass.Log(File, Message);

            } catch (Exception e)
            {
                throw e;
            }

            return elReturn;
        }
    }
}
