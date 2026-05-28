using Microsoft.Playwright;

using Ui.Automation.Project.Models;

namespace Ui.Automation.Project.Pages
{
	public class ProductDetailsPage : BasePage
	{
		public ProductDetailsPage(IPage page) : base(page) { }

		public ILocator ProcessorDropdown => _page.Locator("#product_attribute_16_5_4");
		public ILocator RamDropdown => _page.Locator("#product_attribute_16_6_5");
		public ILocator QuantityInput => _page.Locator("#addtocart_16_EnteredQuantity");
		public ILocator AddToCartButton => _page.Locator("#add-to-cart-button-16");

		public ILocator HddRadioOption(string size) =>
			_page.Locator($".option-list label:has-text('{size}')");

		public async Task SelectProcessorAsync(string text)
		{
			await ProcessorDropdown.SelectOptionAsync(new SelectOptionValue { Label = text });
		}

		public async Task SelectRamAsync(string text)
		{
			await RamDropdown.SelectOptionAsync(new SelectOptionValue { Label = text });
		}

		public async Task SelectHddAsync(string size)
		{
			await HddRadioOption(size).ClickAsync();
		}

		public async Task SetQuantityAsync(string qty)
		{
			await QuantityInput.FillAsync(qty);
		}

		public async Task ClickAddToCartAsync()
		{
			await AddToCartButton.ClickAsync();
		}

		public async Task ConfigureAndAddToCartAsync(ComputerModel computer, string quantity = "1")
		{
			await SelectProcessorAsync(computer.Processor);
			await SelectRamAsync(computer.Ram);
			await SelectHddAsync(computer.Hdd);
			await SetQuantityAsync(quantity);
			await ClickAddToCartAsync();
		}
	}
}
