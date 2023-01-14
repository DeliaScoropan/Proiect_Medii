using Proiect_Medii.Database;

namespace Proiect_Medii;

public partial class App : Application
{
	static ItemsList database;
	public static ItemsList Database
	{
		get
		{
			if (database == null)
			{
				database = new ItemsList(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ShoppingList.db3"));
			}
			return database;
		}
	}


	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
