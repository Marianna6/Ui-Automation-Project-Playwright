using Microsoft.Playwright;

using Ui.Automation.Project.Models;

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

		public async Task RegisterUserAsync(UserModel user)
		{
			await FirstNameInput.FillAsync(user.FirstName);
			await LastNameInput.FillAsync(user.LastName);
			await EmailInput.FillAsync(user.Email);
			await PasswordInput.FillAsync(user.Password);
			await ConfirmPasswordInput.FillAsync(user.Password);
			await RegisterButton.ClickAsync();
		}
	}
}
