using API.Interfaces;
using Microsoft.Playwright;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace API.Services;

public class WebScrapeService : IWebScrapeService
{
    public async Task<string> GetHtmlStringAsync(string url)
    {
        // return await GetHtmlStringAsyncSelenium(url);
        return await GetHtmlStringAsyncPlayWright(url);
    }

    private async Task<string> GetHtmlStringAsyncPlayWright(string url)
    {
        var result = "";
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new()
        {
            Headless = true, // set to "false" while developing
        });
        var page = await browser.NewPageAsync();
        await page.GotoAsync(url);
        result = await page.ContentAsync();

        return result;
    }

    private async Task<string> GetHtmlStringAsyncSelenium(string url)
    {
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArgument("--incognito");
        chromeOptions.AddArgument("--headless");
        IWebDriver driver = new ChromeDriver(chromeOptions);
        await driver.Navigate().GoToUrlAsync(url);
        var htmlString = driver.PageSource;
        // List<string[]> items = new List<string[]>();
        // IReadOnlyCollection<IWebElement> productElements = driver.FindElements(By.ClassName("shelf-item"));
        // foreach (IWebElement productElement in productElements)
        // {
        //     string name = productElement.FindElement(By.ClassName("shelf-item__title")).Text;
        //     string price = productElement.FindElement(By.ClassName("val")).Text;
        //     items.Add(new string[] { name, price });
        //     string csvFilePath = "\\webscraping\\items.csv";
        //     using (StreamWriter writer = new StreamWriter(csvFilePath))
        //     {
        //         writer.WriteLine("Name,Price");
        //         foreach (string[] item in items)
        //         {
        //             writer.WriteLine(string.Join(",", item));
        //         }
        //     }
        // }
        driver.Quit();

        return htmlString;
    }
}
