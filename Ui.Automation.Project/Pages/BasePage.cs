using Microsoft.Playwright;
using Ui.Automation.Project.Components;

namespace Ui.Automation.Project.Pages
{
	public abstract class BasePage
	{
		protected readonly IPage _page;

		public HeaderComponent Header { get; }
		public FooterComponent Footer { get; }

		public BasePage(IPage page)
		{
			_page = page;

			Header = new HeaderComponent(page);
			Footer = new FooterComponent(page);
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

	}
}
