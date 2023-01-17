namespace App1Burger;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(Views.BurgerItemPage), typeof(Views.BurgerItemPage));
        Routing.RegisterRoute(nameof(Views.BurgerListPage), typeof(Views.BurgerListPage));
    }
}
