namespace OOPLR1;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private void onShowHistory1(object sender, EventArgs e){
		DisplayAlert("", "Розпочинаємо вивчення основ ООП", "OK");
	}
	private void onShowHistory2(object sender, EventArgs e){
		DisplayAlert("Історія 2", "Початок виконання лабораторних робіт", "OK");
	}
	private void onShowHistory3(object sender, EventArgs e){
		DisplayAlert("Історія 3", "Я виконую ці лабораторні роботи за допомогою мови C#.", "OK", "Like C#");
	}
	private void onShowHistory4(object sender, EventArgs e){
		DisplayAlert("Історія 4", "Але краще б я це робив на більш рідному для мене - PHP", "OK", "HE OK");
	}
	private void onShowHistory5(object sender, EventArgs e){
		DisplayAlert("Історія 5", "Обидві мови активно використовують підхід ООП.", "OK");
	}
	private void OnExitButtonClicked(object sender, EventArgs e)
	{
    	CloseApplication();
	}
	private void CloseApplication()
	{
		#if MACCATALYST
			UIKit.UIApplication.SharedApplication.PerformSelector(new ObjCRuntime.Selector("terminateWithSuccess"), null, 0);
		#endif
	}

}

