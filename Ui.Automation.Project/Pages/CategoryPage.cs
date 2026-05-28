using Microsoft.Playwright;

namespace Ui.Automation.Project.Pages
{
	public class CategoryPage : BasePage
	{
		public CategoryPage(IPage page) : base(page) { }

		public ILocator CategoryTitle => _page.Locator(".page-title h1");

		public ILocator SubcategoryLink(string subcategoryName) =>
			_page.Locator($".sub-category-item .title a:has-text('{subcategoryName}')");

		public ILocator ProductLink(string productName) =>
			_page.Locator($".product-grid .product-title a:has-text('{productName}')");

		public ILocator AddToCartButton(string productName) =>
			_page.Locator($".product-item:has-text('{productName}') .product-box-add-to-cart-button");
	}
}
