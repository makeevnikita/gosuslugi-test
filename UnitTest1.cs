using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;

namespace gosuslugi_test;


public class Tests
{
    public static IWebDriver WebDriver;
    public static WebDriverWait wait;

    [SetUp]
    public void Setup()
    {
        WebDriver = new ChromeDriver();
        wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10));
    }

    [Test]
    public void Test1()
    {
        WebDriver.Navigate().GoToUrl("https://gosuslugi.ru");

        wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("login-button")));
        WebDriver.FindElement(By.ClassName("login-button")).Click();

        wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div[class='mt-40 text-center']")));
        WebDriver.FindElement(By.CssSelector("div[class='mt-40 text-center']"))
                 .FindElement(By.ClassName("plain-button-inline")).Click();
        
        wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div[class='modal modal_open']")));
        WebDriver.FindElement(By.CssSelector("div[class='modal modal_open']"))
                 .FindElement(By.ClassName("plain-button-inline")).Click();
        
        wait.Until(ExpectedConditions.ElementExists(By.CssSelector("form[class='ng-untouched ng-pristine ng-invalid']")));

        bool formIsDisplayed = WebDriver.FindElement(By.CssSelector("form[class='ng-untouched ng-pristine ng-invalid']")).Displayed;

        Assert.That(formIsDisplayed, Is.True);
    }
}