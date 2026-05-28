using Microsoft.Playwright;

namespace Ui.Automation.Project.Components
{
	public class FooterComponent
	{
		private readonly IPage _page;

		public FooterComponent(IPage page)
		{
			_page = page;
		}

		public ILocator FooterBlock => _page.Locator(".footer");
		public ILocator FooterSectionTitle(string name) => _page.Locator($".footer strong:has-text('{name}')");
		public ILocator FooterLink(string name) => _page.Locator($".footer a:has-text('{name}')");
	}
}
