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
    public class DocumntsConstants
         {
        public const string DocumentsInBank = "Документы в Банк";
        public const string LetterToBank = "Письмо в Банк";
        public const string AccountAplication = "Заявление на открытие счета";
        public const string HelpRequest = "Запрос справки";
        public const string CostomerProfile = "Анкета клиента";
        //public const string
        //public const string
        //..........................................................
         }
    class MenuCreateDocuments
    {
        
        public static void OpenCreateMenu(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            By prop = By.XPath("//span[text()='Создать']");
            wait.Until(d => d.FindElement(prop));
            driver.FindElement(prop).Click();
            Thread.Sleep(1000);
        }
        public static void CloseCreateMenu(IWebDriver driver)
        {
            driver.FindElement(By.XPath("(//*[starts-with(@class,'generic-icon')])[1]")).Click();
            Thread.Sleep(1000);
        }
        public static void OpenImportMenu(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            By prop = By.XPath("//span[text()='Импорт']");
            wait.Until(d => d.FindElement(prop));
            driver.FindElement(prop).Click();
            Thread.Sleep(1000);
        }

        public static void CreateDocumentFromMenu(IWebDriver driver, string  DocName) 
        {
            driver.FindElement(By.XPath(String.Format("//span[starts-with(@class,'btn__content')]//*[text() = '{0}']", DocName))).Click();
            Thread.Sleep(1000);
        }
        public static void CheckFirstPlaceMenu(IWebDriver driver, string firstplace)
        {
           
            IWebElement FirstPlace = driver.FindElement(By.XPath("(//span[starts-with(@class,'btn__content')])[1]"));
            try
            {
                Assert.That(FirstPlace.Text, Is.EqualTo(firstplace));
                Console.WriteLine("На первом месте нужный документ");
            }
            catch (AssertionException)
            {
                Console.WriteLine("Не на первом месте в кнопке создать");
            }
        }
    }
}
