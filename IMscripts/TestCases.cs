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

namespace IMscripts
{
    class TestCases
    {

        IWebDriver driver;
        //public IJavaScriptExecutor js =   driver  as IJavaScriptExecutor;
        //public string key = "SAUID";
        //public string value = "";

        [SetUp]
        public void StartBrowser()
        {

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //js.ExecuteScript("window.localStorage.setItem('SAUID', 'VTB22559977');");
            //js.ExecuteScript(String.Format("window.localStorage.setItem('%s','%s')", key, value));
        }
        [Test]
        public void logOutFromMainPage_Test()
        {
            LogInOut.ClientLogin(driver);
            //LogInOut.ClientLogout(driver);
        }
        [Test]
        public void logOutFromScroller_Test()
        {
            LogInOut.ClientLogin(driver);
            MenuDocuments.LettersToBank(driver);
            LogInOut.ClientLogout(driver);
        }
        /// /////////////////////////////////////////// /// /////////////////////////////////////////// /// /////////////////////////////////////////// /// /////////////////////////////////////////// /// /////////////////////////////////////////// /// /////////////////////////////////////////// /// ///////////////////////////////////////////
        ///  /// /////////////////////////////////////////// /// /////////////////////////////////////////// /// /////////////////////////////////////////// /// /////////////////////////////////////////// /// /////////////////////////////////////////// /// /////////////////////////////////////////// /// ///////////////////////////////////////////
        ///   /// /////////////////////////////////////////// /// /////////////////////////////////////////// /// /////////////////////////////////////////// /// ///////////////////////////////////////////
        ///   
        [Test]
        public void CentralBankFxRate_Test()
        {
            List<string> listofFxRatesNames = new List<string>();
            List<string> listofFxRates = new List<string>();
            //Заполнение списков из файла
            FxRateWidget.FxrateNamesReader(listofFxRatesNames);
            FxRateWidget.FxrateRatesReader(listofFxRates);
            // вход в систему
            LogInOut.ClientLogin(driver);

            //Открытие виджета Курсов ЦБ
            FxRateWidget.OpenFxRateWidget(driver);

            //Проверка наименования виджета
            PanelOperation.PanelNameCheck(driver,PanelNames.PanelFxName);

            //Сравнение количества параметров курсов с ожидаемым результатом
            FxRateWidget.CountFxRates(driver, listofFxRatesNames);

            //Сравнение наименования курсов
            FxRateWidget.NameFxRates(driver, listofFxRatesNames);

            //Сравнение значений курсов
            FxRateWidget.RatesFxRates(driver, listofFxRates);
            //Закрыть панель курсов
            PanelOperation.ClosePanel(driver);
            //выход на страницу логина 
            LogInOut.ClientLogout(driver);

            Console.WriteLine("Выполнение теста закончено");

        }
        ///////////////////////////////////////////////// /// /////////////////////////////////////////// /// /////////////////////////////////////////// /// ///////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////// /// /////////////////////////////////////////// /// /////////////////////////////////////////// /// /////////////////////////////////////////// /// ///////////////////////////////////////////
        [Test]
        public void CreatebuttonFirstDocumentType_Test()
        {

            //Вход в систему
            LogInOut.ClientLogin(driver);
            //переход в скроллер
            MenuDocuments.DocumintsInBank(driver);
            //Открыть меню создания документа 
            MenuCreateDocuments.OpenCreateMenu(driver);

            //IWebElement FirstPlace = driver.FindElement(By.XPath("(//span[@class='btn__content-ePe'])[1]"));

            //Проверка находится ли нужный документ на первом месте 
            MenuCreateDocuments.CheckFirstPlaceMenu(driver, DocumntsConstants.DocumentsInBank);

            //Закрыть меню создания документа 
            MenuCreateDocuments.CloseCreateMenu(driver);

            //Открыть Скроллер Писем в Банк 
            MenuDocuments.LettersToBank(driver);

            //Открыть меню создания
            MenuCreateDocuments.OpenCreateMenu(driver);
            //Проверка находится ли нужный документ на первом месте 
            MenuCreateDocuments.CheckFirstPlaceMenu(driver, DocumntsConstants.LetterToBank);
            //Закрыть меню создания 
            MenuCreateDocuments.CloseCreateMenu(driver);
            //Выйти из системы
            // LogInOut.ClientLogout(driver);
        }
        ///////////////////////////////////////////////// /// /////////////////////////////////////////// /// /////////////////////////////////////////// /// ///////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////// /// //////////////////////////////
        [Test]
        public void CreateDocument_Test()
        {
            //Вход в систему
            LogInOut.ClientLogin(driver);
            //Открыть меню создания документа 
            MenuCreateDocuments.OpenCreateMenu(driver);



            //Создать документ "Письмо в банк"
            MenuCreateDocuments.CreateDocumentFromMenu(driver, DocumntsConstants.LetterToBank);
            //Проверка, что открылась форма создания 
            try
            {
                //Проверка открыта ли полная форма создания документа
                Assert.IsTrue(driver.FindElement(By.XPath(("//span[text() = 'Основные реквизиты']"))).Displayed);
                Assert.IsTrue(driver.FindElement(By.XPath(String.Format("//span[contains(text(),'{0}')]", DocumntsConstants.LetterToBank))).Displayed);
                Console.WriteLine("Форма создания открыта");
            }
            catch
            {
                Assert.Fail("Форма создания документа-{0} не открыта", DocumntsConstants.LetterToBank);
            }

        }
        [Test] //переходы из различных скроллеров на главную страницу
        public void SwitchToMainPage_Test()
        {
            // Вход в систему
            LogInOut.ClientLogin(driver);
            //переход в скроллер 
            MenuDocuments.LettersFromBank(driver);
            // Переход на Главную страницу из продуктового меню
            MenuDocuments.MainPage(driver);
            //Проверка открыта ли главная страница
            LogInOut.MainPageCheck(driver);

            //проверка перехода на главную из любого скроллера по нажатию на Логотип Банка 
            MenuDocuments.DocumintsInBank(driver);
            //Нажать на логотип
            driver.FindElement(By.ClassName("logo-1UL")).Click();
            Thread.Sleep(1000);
            LogInOut.MainPageCheck(driver);
        }
        [Test] //Проверка функционала кнопок топлайна (структуры)
        public void TopLineButtons_Test()
        {
            // Вход в систему
            LogInOut.ClientLogin(driver);
            LogInOut.MainPageCheck(driver);
            //Нажать на фоновые процессы 
            driver.FindElement(By.XPath("(//*[starts-with(@class,'alert__item-2B5')])[1]")).Click();
            
            //Проверка наименования
            PanelOperation.PanelNameCheck(driver, PanelNames.PanelProcess);
            //Закрыть  панель
            PanelOperation.ClosePanel(driver);
            //Открыть панель уведомлений
            driver.FindElement(By.XPath("(//*[starts-with(@class,'alert__item-2B5')])[2]")).Click();
            Thread.Sleep(2000);
            IWebElement fx = driver.FindElement(By.XPath("(//*[starts-with(@class,'header__title')])"));
            try
            {
                Assert.That(fx.Text, Is.EqualTo(PanelNames.PanelNotification));

            }
            catch (AssertionException)
            {

                Assert.Fail("Название в панели  Уведомлений не соответствует ожидаемому результату");
            }
            //Закрыть панель
            PanelOperation.ClosePanel(driver);


            //try
            //{
            //    Assert.That(driver.FindElement(By.XPath("(//*[starts-with(@class,'alert__item-2B5')])[3]")).Displayed);
            //    Console.WriteLine("В топлайне отсутствует значок ДТВ");
            //}
            //catch 
            //{
            //    Assert.Fail("В топлайне отображается три элемента");
            //}

            //Проверить панель дтв из скроллера
            MenuDocuments.LettersFromBank(driver);
            driver.FindElement(By.XPath("(//*[starts-with(@class,'alert__item-2B5')])[2]")).Click();
            PanelOperation.PanelNameCheck(driver, PanelNames.PanelDRA);
            PanelOperation.ClosePanel(driver);

            //Проверить кнопку создать
            MenuCreateDocuments.OpenCreateMenu(driver);
            PanelOperation.PanelNameCheck(driver, PanelNames.PanelCreate);
            PanelOperation.ClosePanel(driver);
            
            //Проверить кнопку импорт 
            MenuCreateDocuments.OpenImportMenu(driver);
            PanelOperation.PanelNameCheck(driver, PanelNames.PanelImport);
            PanelOperation.ClosePanel(driver);
            

        }


        [TearDown]
        public void Close()
        {
            //Закрыть браузер
            //driver.Close();
            Console.WriteLine("Браузер Закрыт");
        }
    


            
}
}
