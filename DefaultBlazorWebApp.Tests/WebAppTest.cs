using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System.Text.RegularExpressions;

namespace DefaultBlazorWebApp.Tests;

[Parallelizable(ParallelScope.Self)]
public class Tests : PageTest
{
    [Test]
    public async Task Clicking_ContactButton_Goes_To_ContactForm()
    {
        await Page.GotoAsync("https://localhost:7293/");
        ILocator formButton = Page.Locator("text=Counter");
        await formButton.ClickAsync();
        await Expect(Page).ToHaveURLAsync(new Regex(".*/counter"));
    }
}