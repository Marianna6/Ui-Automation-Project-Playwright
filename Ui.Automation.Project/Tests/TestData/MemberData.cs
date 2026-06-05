using Ui.Automation.Project.Models;

namespace Ui.Automation.Project.Tests.TestData
{
	public static class MemberData
	{
		public static IEnumerable<object[]> OrderData =>
			new List<object[]>
			{
				new object[]
				{
					new UserModel
					{
						FirstName = "M",
						LastName = "S",
						Email = "testmarisha@gmail.com",
						Password = "123456"
					},
					new ComputerModel
	                {
		                Processor = "2.5 GHz Intel Pentium Dual-Core E2200\r\n     [+15.00]",
		                Ram = "2 GB ",
		                Hdd = "320 GB "
	                },
					"Computers",
					"Desktops",
					"Build your own computer"
				}
			};

		public static IEnumerable<object[]> NegativeLoginData => new List<object[]>
		{
			new object[] {"testmarisha@gmail.com", "wrong_password_999", "The credentials provided are incorrect"},
			new object[] {"fake_marisha_999@gmail.com", "123456", "No customer account found"},
			new object[] {"testmarisha@gmail.com", "",  "The credentials provided are incorrect"}
		};
	}
}
