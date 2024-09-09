using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System.Text.RegularExpressions;

namespace DefaultBlazorWebApp.Tests;

[Parallelizable(ParallelScope.Self)]
public class Tests : PageTest
{
    private static string _webAppUrl;

    [OneTimeSetUp]
    public void Init()
    {
        _webAppUrl = TestContext.Parameters["WebAppUrl"]
            ?? throw new Exception("WebAppUrl is not configured as a parameter.");
    }

    [Test]
    public async Task Clicking_CounterButton_Goes_To_CounterPage()
    {
        //Given
        await Page.GotoAsync(_webAppUrl);
        ILocator formButton = Page.Locator("text=Counter");

        //When
        await formButton.ClickAsync();
        
        //Then
        await Expect(Page).ToHaveURLAsync(new Regex(".*/counter"));
    }
}