namespace MauiList;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
		Task.Run(async () => await ((MainPageViewModel)BindingContext).InitializaAsync());
	}

}

