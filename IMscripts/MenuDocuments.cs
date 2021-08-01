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


namespace IMscripts
{
    class MenuDocuments
    {
        public static void MainPage(IWebDriver driver)
        {

            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            By cb = By.XPath(".//a[text()='Главная']");
            wait.Until(d => d.FindElement(cb));
            driver.FindElement(cb).Click();
            Thread.Sleep(500);
        }
        public static void DocumintsInBank(IWebDriver driver)
        {

            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            By cb = By.XPath(".//a[text()='Документы в Банк']");
            wait.Until(d => d.FindElement(cb));
            driver.FindElement(cb).Click();
            Thread.Sleep(1000);

        }

        public static void LettersToBank(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            By prop1 = By.XPath("//span[text()='Письма из Банка / в Банк']");
            wait.Until(d => d.FindElement(prop1));
            driver.FindElement(prop1).Click();
            Thread.Sleep(500);

            By z = By.XPath("//a[text()='Письма в Банк']");
            wait.Until(d => d.FindElement(z));
            driver.FindElement(z).Click();


        }
        public static void LettersFromBank(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            By prop1 = By.XPath("//span[text()='Письма из Банка / в Банк']");
            wait.Until(d => d.FindElement(prop1));
            driver.FindElement(prop1).Click();
            Thread.Sleep(500);

            By z = By.XPath("//a[text()='Письма из Банка']");
            wait.Until(d => d.FindElement(z));
            driver.FindElement(z).Click();
            Thread.Sleep(1000);
        }

        public static void AccountManageAccounts(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            By prop1 = By.XPath("//span[text()='Управление счетами']");
            wait.Until(d => d.FindElement(prop1));
            driver.FindElement(prop1).Click();
            Thread.Sleep(500);

            By z = By.XPath("//a[text()='Счета']");
            wait.Until(d => d.FindElement(z));
            driver.FindElement(z).Click();

        }
        public static void AccountApplications(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            By prop1 = By.XPath("//span[text()='Управление счетами']");
            wait.Until(d => d.FindElement(prop1));
            driver.FindElement(prop1).Click();
            Thread.Sleep(500);

            By z = By.XPath("//a[text()='Заявления на открытие счетов']");
            wait.Until(d => d.FindElement(z));
            driver.FindElement(z).Click();

        }
        public static void SalaryProjectEmployees(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            By prop1 = By.XPath("//span[text()='Управление счетами']");
            wait.Until(d => d.FindElement(prop1));
            driver.FindElement(prop1).Click();
            Thread.Sleep(500);

            By z = By.XPath("//a[text()='Заявления на открытие счетов']");
            wait.Until(d => d.FindElement(z));
            driver.FindElement(z).Click();

        }
    }
}
