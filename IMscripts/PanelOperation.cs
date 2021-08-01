using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using OpenQA.Selenium.Support.UI;
namespace IMscripts
{
    class PanelOperation
    {
        public static void PanelNameCheck(IWebDriver driver, string panelNames)
        {
            Thread.Sleep(2000);
            IWebElement fx = driver.FindElement(By.CssSelector("div.ellipsis-line-xQR>span"));
            try
            {
                Assert.That(fx.Text, Is.EqualTo(panelNames));

            }
            catch (AssertionException)
            {
          
                Assert.Fail("Название в панели  не соответствует ожидаемому результату");
            }
    
        }


        public static void ClosePanel(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            By prop = By.XPath("(//*[starts-with(@class,'generic-icon')])[1]");
            wait.Until(d => d.FindElement(prop));
            driver.FindElement(prop).Click();
        }

    }

}
