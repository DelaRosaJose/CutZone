namespace CutZone;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		new Helpers.SQLiteConnector();
		new Helpers.SQLiteConnector();

		MainPage = new AppShell();
	}
}
