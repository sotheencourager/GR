using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static programObject.IHS_Code_Challenge.programObject;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using System.Linq;

namespace IHS_Code_Challenge
{
    [TestClass]
    public class Test2
    {
        //Chrome browser
        IWebDriver driver = new ChromeDriver(@"C:\Users\Owner\Documents\C#\G_Rate_Assessment\IHS_Code_Challenge\driver");
        //FirefoxDriver driver = new FirefoxDriver(@"C:\Users\Owner\Documents\C#\G_Rate_Assessment\IHS_Code_Challenge\driver");

        [TestMethod]
        public void Test()
        {
            //URL to test
            driver.Navigate().GoToUrl("https://cars.com");

            //Maximize browser window
            /*driver.Manage().Window.Maximize();
            programObject Car = new programObject(driver);
            programObject.DropDownSelectByValue("stockType", "28880");*/

            //Search filter selections - Task #1
            IWebElement stock = driver.FindElement(By.Name("stockType"));
            SelectElement selectStock = new SelectElement(stock);
            selectStock.SelectByValue("28880");

            //driver.FindElement(By.Name("stockType")).FindElement(By.XPath(".//option[contains(text(),'Used Cars')]")).Click();
            driver.FindElement(By.Name("makeId")).FindElement(By.XPath(".//option[contains(text(),'Honda')]")).Click();
            driver.FindElement(By.Name("modelId")).FindElement(By.XPath(".//option[contains(text(),'Pilot')]")).Click();
            driver.FindElement(By.Name("priceMax")).FindElement(By.XPath(".//option[contains(text(),'$50,000')]")).Click();
            driver.FindElement(By.Name("radius")).FindElement(By.XPath(".//option[contains(text(),'100 Miles from')]")).Click();
            
            IWebElement package = driver.FindElement(By.Name("zip"));
            package.SendKeys("60008");

            //Search button
            driver.FindElement(By.ClassName("NZE2g")).Click();


            //Some weird Chrome issue that requires some refactor to get around. I cannot of how to for now
            driver.Navigate().GoToUrl("https://www.cars.com/for-sale/searchresults.action/?mdId=21729&mkId=20017&prMx=50000&rd=100&searchSource=QUICK_FORM&stkTypId=28880&zc=37013");


            System.Threading.Thread.Sleep(5000);
            driver.Navigate().Refresh();

            //Task #2 - Task #1 validation using assert
            string PriceValue = driver.FindElement(By.XPath("//ul[@class='breadcrumbs']//li[1]")).Text;
            Assert.IsTrue(PriceValue.Contains("Maximum Price: $50,000"));

            string MakeValue = driver.FindElement(By.XPath("//ul[@class='breadcrumbs']//li[2]")).Text;
            Assert.IsTrue(MakeValue.Contains("Honda"));

            string ModelValue = driver.FindElement(By.XPath("//ul[@class='breadcrumbs']//li[3]")).Text;
            Assert.IsTrue(ModelValue.Contains("Pilot"));

            string NewUsedValue = driver.FindElement(By.XPath("//ul[@class='breadcrumbs']//li[4]")).Text;
            Assert.IsTrue(NewUsedValue.Contains("Used"));

            //Task #3 ---------Finish up with element type and value
            IWebElement NewRadioButton = driver.FindElement(By.Id("stkTypId-28880"));
            //IWebElement NewRadioButton = driver.FindElement(By.XPath("//*[@id='stkTypId']/ul/li[2]/label"));
            NewRadioButton.Click();

            System.Threading.Thread.Sleep(2000);

            //Task #4 - validate task #3 
            string NewUsedValue2 = driver.FindElement(By.XPath("//ul[@class='breadcrumbs']//li[4]")).Text;
            Assert.IsTrue(NewUsedValue2.Contains("New"));

            //Task #5 - selecting checkbox using xpath
            driver.FindElement(By.XPath("/html/body/div[1]/div[4]/cars-filters/div[2]/div[1]/div/form/ul/li[8]/ul/li[7]/label")).Click();

            //Task #6 - validate task #5
            string TrimValue = driver.FindElement(By.XPath("//ul[@class='breadcrumbs']//li[4]")).Text;
            Assert.IsTrue(TrimValue.Contains("New"));

            //Task #7 - select the second car from the filtered result using css selector
            driver.FindElement(By.XPath("#srp-listing-rows-container > div:nth-child(7)")).Click();

            System.Threading.Thread.Sleep(2000);

            //Task #8 - check title (I assumed page title)
            string ExpectedTitle = "Honda Pilot 8-Passenger For Sale";
            string Title = driver.Title;
            Assert.AreEqual(true, Title.Contains(ExpectedTitle));

            //#8b verify using assert that Check Availability button is displayed
            Assert.IsTrue(driver.FindElement(By.Name("submit")).Displayed);

            //task #9 Filling out the contact form without submitting it
            IWebElement FirstName = driver.FindElement(By.Name("fname"));
            FirstName.SendKeys("Car");

            IWebElement LastName = driver.FindElement(By.Name("lname"));
            LastName.SendKeys("Owner");

            IWebElement Email = driver.FindElement(By.Name("email"));
            LastName.SendKeys("carowner@yahoo.com");


            //task #10 scrolling using action and class as element
            var element = driver.FindElement(By.ClassName("calculator-title"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();


        }
        [TestCleanup]
        public void TearDown()
        {
            //Quit browser
            driver.Quit();
        }
    }
}