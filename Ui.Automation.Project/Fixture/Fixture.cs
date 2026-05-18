using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;

namespace Ui.Automation.Project.Fixture
{
	public class Fixture : IAsyncLifetime
	{
		public IPlaywright Playwright { get; private set; } = null!;
		public IBrowser Browser { get; private set; } = null!;
		public IPage Page { get; private set; } = null!;

		public async Task InitializeAsync()
		{
			var config = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();

			var baseUrl = config["BaseUrl"];

			Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

			Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
			{
				Headless = false,
				SlowMo = 1000
			});

			Page = await Browser.NewPageAsync();

			if (!string.IsNullOrEmpty(baseUrl))
			{
				await Page.GotoAsync(baseUrl);
			}
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
