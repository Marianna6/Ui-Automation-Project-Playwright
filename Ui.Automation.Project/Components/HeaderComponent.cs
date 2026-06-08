using Microsoft.Playwright;

namespace Ui.Automation.Project.Components
{
	public class HeaderComponent
	{
		private readonly IPage _page;

		public HeaderComponent(IPage page)
		{
			_page = page;
		}

		public ILocator HeaderBlock => _page.Locator(".header");
		public ILocator HeaderLogo => _page.Locator(".header-logo a");

		public ILocator SearchInput => _page.Locator("#small-searchterms");
		public ILocator SearchButton => _page.Locator(".search-box-button");

		public ILocator LoginLink => _page.Locator(".ico-login");

		public async Task GoToLoginPageAsync()
		{
			await LoginLink.ClickAsync();
		}

		public ILocator RegisterLink => _page.Locator(".ico-register");
		public ILocator CartLink => _page.Locator("#topcartlink .ico-cart");

		public async Task GoToCartPageAsync()
		{
			await CartLink.ClickAsync();
		}

		public ILocator LogoutLink => _page.Locator(".ico-logout");
		public ILocator AccountLink => _page.Locator(".header-links .account");

		public async Task SearchForAsync(string searchText)
		{
			await SearchInput.FillAsync(searchText);
			await SearchButton.ClickAsync();
		}

		public async Task LogoutAsync()
		{
			await LogoutLink.ClickAsync();
		}
	}
}
