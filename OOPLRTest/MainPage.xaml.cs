namespace OOPLRTest;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnButtonAlphaClicked(object sender, EventArgs e)
	{
		await Navigation.PushModalAsync(new LAB9());
	}

	private async void OnButtonBetaClicked(object sender, EventArgs e)
	{
		await Navigation.PushModalAsync(new LAB10());
	}

	private async void OnButtonGammaClicked(object sender, EventArgs e)
	{
		await Navigation.PushModalAsync(new LAB11());
	}

	private async void OnButtonDeltaClicked(object sender, EventArgs e)
	{
		await Navigation.PushModalAsync(new LAB13Ex());
	}

	private async void OnCloseWindowsClicked(object sender, EventArgs e)
	{
		await DisplayAlert("Button", "Close Windows clicked", "OK");
	}

	private void OnExitAppClicked(object sender, EventArgs e)
	{
#if ANDROID
		Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
#elif WINDOWS
		Application.Current.Quit();
#elif MACCATALYST || IOS
        UIKit.UIApplication.SharedApplication.PerformSelector(new ObjCRuntime.Selector("terminateWithSuccess"), null, 0);
#endif
	}
}

