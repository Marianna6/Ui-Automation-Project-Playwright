using Microsoft.Playwright;

namespace Ui.Automation.Project.Pages
{
	public abstract class BasePage
	{
		protected readonly IPage _page;

		public BasePage(IPage page)
		{
			_page = page;
		}

		//HEADER
		public ILocator HeaderBlock => _page.Locator(".header");
		public ILocator HeaderLogo => _page.Locator(".header-logo a");

		public ILocator SearchInput => _page.Locator("#small-searchterms");
		public ILocator SearchButton => _page.Locator(".search-box-button");

		public ILocator LoginLink => _page.Locator(".ico-login");
		public ILocator RegisterLink => _page.Locator(".ico-register");
		public ILocator CartLink => _page.Locator(".ico-cart");
		//public ILocator WishlistLink => _page.Locator(".ico-wishlist");
		// public ILocator FlyoutCart => _page.Locator("#flyout-cart");

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

		//TOP MENU & SIDE MENU
		public ILocator TopMenuBlock => _page.Locator(".top-menu");
		public ILocator SideMenuBlock => _page.Locator(".block-category-navigation");
		public ILocator SideMenuTitle => _page.Locator(".block-category-navigation .title");

		public ILocator TopMenuLink(string name) => _page.Locator($".top-menu a:has-text('{name}')");
		public ILocator SideMenuLink(string name) => _page.Locator($".block-category-navigation a:has-text('{name}')");

		//MANUFACTURERS
		public ILocator ManufacturersTitle => _page.Locator(".block-manufacturer .title");
		public ILocator ManufacturerLink => _page.Locator(".block-manufacturer a:has-text('Tricentis')");

		//NEWSLETTER
		public ILocator NewsletterBlock => _page.Locator("#newsletter-subscribe-block");
		public ILocator NewsletterEmailInput => _page.Locator("#newsletter-email");
		public ILocator NewsletterSubscribeButton => _page.Locator("#newsletter-subscribe-button");

		//FOOTER
		public ILocator FooterBlock => _page.Locator(".footer");
		public ILocator FooterSectionTitle(string name) => _page.Locator($".footer strong:has-text('{name}')");
		public ILocator FooterLink(string name) => _page.Locator($".footer a:has-text('{name}')");
	}
}
