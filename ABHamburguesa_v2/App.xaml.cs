using ABHamburguesa_v2.ABData;

namespace ABHamburguesa_v2;

public partial class App : Application
{
	public static ABBurguerDataBase BurguerRepo { get; set; }
	public App(ABBurguerDataBase repo)
	{
		InitializeComponent();

		MainPage = new AppShell();
		BurguerRepo = repo;
	}
}
