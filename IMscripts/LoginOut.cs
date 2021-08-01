using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System.IO;



namespace IMscripts
{
    class LogInOut
    {

        public static void ClientLogin(IWebDriver driver) 
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            driver.Url = "http://fe-root-client-iteration.main-page.k8s-dev-ts.vtb-dbo.local/login";
            By prop = By.XPath("//*[contains(text(), 'Вход по логину')]");
            wait.Until(d => d.FindElement(prop));
            driver.FindElement(prop).Click();
            driver.FindElement(By.Name("login")).SendKeys("88606533");
            driver.FindElement(By.Name("password")).SendKeys("Gafa5" + Keys.Enter);
            Thread.Sleep(5000);
            Console.WriteLine("Вход выполнен успешно");

        }
        public static void ClientLogout(IWebDriver driver)
        {

            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 4));
           
            By logout = By.XPath("(//*[starts-with(@class,'userInfoBar__logout')])[1]");
            wait.Until(d => d.FindElement(logout));
            driver.FindElement(logout).Click();

            By prop1 = By.XPath("//span[text()='Выйти']");
            wait.Until(d => d.FindElement(prop1));
            driver.FindElement(prop1).Click();

            Console.WriteLine("Выход выполнен успешно");
        }
        public static void MainPageCheck(IWebDriver driver)
        {
            try
            {
                Assert.IsTrue(driver.FindElement(By.ClassName("layout-content__content-2BC")).Displayed);
                Console.WriteLine("Главная страница открыта");
            }
            catch
            {
                Assert.Fail("Главная страница не открыта ");
            }
        }
    }
}
