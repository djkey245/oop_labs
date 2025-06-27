namespace OOPLR2;

public partial class MainPage : ContentPage
{
	private Book book1; 
	private Book book2; 

	public MainPage()
	{
		InitializeComponent();
		PageManager.CurrentPage = this;
	}

	private void DefaultConstructorButton_Clicked(object sender, EventArgs e)
	{
		book1 = new Book();
		book1.Info();
	}

	async private void ParameterizedConstructorButton_Clicked(object sender, EventArgs e)
	{
		string title = await DisplayPromptAsync(
            "Input Title",
            "Please enter your text:",
            "OK",
            "Cancel",
            placeholder: "Type here...",
            maxLength: 100,
            keyboard: Keyboard.Text
        );
		string author = await DisplayPromptAsync(
            "Input Author",
            "Please enter your text:",
            "OK",
            "Cancel",
            placeholder: "Type here...",
            maxLength: 100,
            keyboard: Keyboard.Text
        );
		int pages = int.TryParse(await DisplayPromptAsync(
            "Input Pages",
            "Please enter your text:",
            "OK",
            "Cancel",
            placeholder: "Type here...",
            maxLength: 100,
            keyboard: Keyboard.Numeric
        ), out int parsedPages) ? parsedPages : 0;
		book2 = new Book(title, author, pages);
		book2.Info();
	}


	private void ExitButton_Clicked(object sender, EventArgs e)
	{
#if MACCATALYST
			UIKit.UIApplication.SharedApplication.PerformSelector(new ObjCRuntime.Selector("terminateWithSuccess"), null, 0);
#endif
	}
}