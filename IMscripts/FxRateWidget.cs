using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;
using System.IO;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;

namespace IMscripts
{
    class FxRateWidget
    {

        public static void OpenFxRateWidget(IWebDriver driver)
        {
            driver.FindElement(By.ClassName("main-page-container__header-widgets--rates-2w5")).Click();

        }

       
        

        public static void CountFxRates(IWebDriver driver,List<string> listofFxRatesNames)
        {
            IList<IWebElement> Fxlist = driver.FindElements(By.ClassName("exchange-rates-list__rate--name-rbW"));

            //Сравнение количества параметров курсов с ожидаемым результатом
            try
            {
                Assert.AreEqual(Fxlist.Count(), listofFxRatesNames.Count);


            }
            catch (AssertionException)
            {
                Console.WriteLine("В панели присутствуют не все заявленные курсы");
            }
        }

        public static void NameFxRates(IWebDriver driver, List<string> listofFxRatesNames)
        {
            //Сравнение наименования курсов
            IList<IWebElement> Fxlist = driver.FindElements(By.ClassName("exchange-rates-list__rate--name-rbW"));
            try
            { int n = listofFxRatesNames.Count();
                for (int i = 0; i<n; i++)
                {
                    Assert.That(Fxlist.ToList().Any(d => d.Text.Contains(listofFxRatesNames[i])));
                }
}
            catch (AssertionException)
            {
                Console.WriteLine("В панели присутствуют не все заявленные курсы");
            }
        }

        public static void RatesFxRates(IWebDriver driver, List<string> listofFxRatesNames)
        {

            IList<IWebElement> FxRates = driver.FindElements(By.ClassName("exchange-rates-list__rate--value-18g"));
            try
            {
                int n = listofFxRatesNames.Count();
                for (int i = 0; i < n; i++)
                {
                    Assert.That(FxRates.ToList().Equals(listofFxRatesNames[i]));
                }


            }
            catch (AssertionException)
            {
                Console.WriteLine(" курсы не соответствуют значениям из бд");
            }
        }

        public static List<string> FxrateNamesReader(List<string> listofFxRatesNames)
        {

            const string Pathname = "C:\\fxrates.txt";
            using (StreamReader reader = new StreamReader(Pathname))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    listofFxRatesNames.Add(line);
                }
                reader.Close();
                return listofFxRatesNames;
            }
            
        }
        public static List<string> FxrateRatesReader( List<string> listofFxRates)
        {

            const string PathRate = "C:\\fxrates2.txt";
           
            using (StreamReader reader = new StreamReader(PathRate))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    listofFxRates.Add(line);
                }
                reader.Close();
                return listofFxRates;
            }


        }
    }
}
