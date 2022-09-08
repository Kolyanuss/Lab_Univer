using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace Guru99
{
    class Class1
    {
        IWebDriver driver;
        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver("E:\\___Code___\\__Programing__\\Lab_University\\Lab_4k_1sem\\Testing\\lab6\\Guru99");
        }

        [Test]
        public void test()
        {
            driver.Url = "https://uk.wikipedia.org/wiki";

            Assert.AreEqual("Вікіпедія", driver.Title.ToString());

            var element = driver.FindElement(By.Id("n-mainpage-description"));
            Assert.AreEqual("Головна сторінка", element.Text);
            element.Click();

            element = driver.FindElement(By.Id("n-currentevents"));
            Assert.AreEqual("Поточні події", element.Text);                        
        }

        [Test]
        public void test2()
        {
            driver.Url = "https://uk.wikipedia.org/wiki";

            Assert.AreEqual("Вікіпедія", driver.Title.ToString());

            var element = driver.FindElement(By.Id("feat-article"));
            Assert.AreEqual("rgba(250, 250, 250, 1)", element.GetCssValue("background-color"));                     
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}