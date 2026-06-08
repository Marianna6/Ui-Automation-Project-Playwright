using Microsoft.Playwright;

namespace Ui.Automation.Project.Pages
{
	public class HomePage : BasePage
	{
		public HomePage(IPage page) : base(page) { }

		public async Task OpenAsync()
		{
			await _page.GotoAsync("https://demowebshop.tricentis.com/");
		}

		//BANNER
		public ILocator PromoBanner => _page.Locator(".nivoSlider a").First;

		//FEATURED PRODUCTS
		public ILocator FeaturedProductsBlock => _page.Locator(".home-page-product-grid");

		public ILocator FeaturedProductLink(string productName) =>
			_page.Locator($".home-page-product-grid .product-title a:has-text('{productName}')");
		public ILocator AddToCartButtonFor(string productName) =>
			_page.Locator($".product-item:has-text('{productName}') .product-box-add-to-cart input");

		//RECENTLY VIEWED
		public ILocator RecentlyViewedBlock => _page.Locator(".block-recently-viewed-products");

		public ILocator RecentlyViewedProductLink(string productName) =>
			_page.Locator($".block-recently-viewed-products a:has-text('{productName}')");

	}
}
