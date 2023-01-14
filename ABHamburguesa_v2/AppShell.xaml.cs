using ABHamburguesa_v2.ABViews;

namespace ABHamburguesa_v2;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(BurguerItemPage), typeof(BurguerItemPage));
		Routing.RegisterRoute(nameof(BurguerListPage), typeof(BurguerListPage));
	}
}
