using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHS_Code_Challenge
{
    public class programObject
    {
        IWebDriver driver;
        By FirstName = By.ClassName("");
        By LastName = By.ClassName("");
        By Email = By.ClassName("");

        public programObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnterFirstName()
        {
            driver.FindElement(FirstName).SendKeys("Car");
        }

        public void EnterLastName()
        {
            driver.FindElement(LastName).SendKeys("Owner");
        }
        public void EnterEmail()
        {
            driver.FindElement(Email).SendKeys("carowner@yahoo.com");
        }

        /*public static void DropDownSelectByValue(string elName, string value)
        {
            //Search filter selections
            IWebElement stock = driver.FindElement(By.Name(elName));
            SelectElement selectStock = new SelectElement(stock);
            selectStock.SelectByValue(value);
        }*/

    }
}
