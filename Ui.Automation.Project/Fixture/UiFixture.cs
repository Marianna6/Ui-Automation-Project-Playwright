using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;

namespace Ui.Automation.Project.Fixture
{
	public class UiFixture : IAsyncLifetime
	{
		public IPlaywright Playwright { get; private set; } = null!;
		public IBrowser Browser { get; private set; } = null!;
		public IPage Page { get; private set; } = null!;

		public async Task InitializeAsync()
		{
			var config = new ConfigurationBuilder()
			.SetBasePath(AppContext.BaseDirectory)
			.AddJsonFile("appsettings.json", optional: false)
			.Build();

			var baseUrl = config.GetSection("BaseUrl").Value;

			Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

			Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
			{
				Headless = false,
				SlowMo = 1000
			});

			var context = await Browser.NewContextAsync(new BrowserNewContextOptions
			{
				BaseURL = baseUrl
			});

			Page = await context.NewPageAsync();

			await Page.GotoAsync("/");
		}

		public async Task DisposeAsync()
		{
			if (Browser != null)
			{
				await Browser.CloseAsync();
			}

			Playwright?.Dispose();
		}

	}
}
