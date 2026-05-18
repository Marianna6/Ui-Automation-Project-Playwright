using Microsoft.Playwright;

namespace Ui.Automation.Project.Pages
{
	public class RegisterPage : BasePage
	{
		public RegisterPage(IPage page) : base(page){}

		public ILocator FirstNameInput => _page.Locator("#FirstName");
		public ILocator LastNameInput => _page.Locator("#LastName");
		public ILocator EmailInput => _page.Locator("#Email");
		public ILocator PasswordInput => _page.Locator("#Password");
		public ILocator ConfirmPasswordInput => _page.Locator("#ConfirmPassword");
		public ILocator RegisterButton => _page.Locator("#register-button");
		public ILocator ErrorMessage => _page.Locator(".message-error");

		public async Task RegisterUserAsync(string firstName, string lastName, string email, string password)
		{
			await FirstNameInput.FillAsync(firstName);
			await LastNameInput.FillAsync(lastName);
			await EmailInput.FillAsync(email);
			await PasswordInput.FillAsync(password);
			await ConfirmPasswordInput.FillAsync(password);
			await RegisterButton.ClickAsync();
		}
	}
}
