namespace OOPLR3;

public partial class MainPage : ContentPage
{
    private Book book;
    private PaperBook paperBook1;
    private PaperBook paperBook2;
    private EBook eBook1;
    private EBook eBook2;

    public MainPage()
    {
        InitializeComponent();
        PageManager.CurrentPage = this;
    }

    async private void DefaultBookButton_Clicked(object sender, EventArgs e)
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

        book = new Book(title, author, pages);
    }

    private void DefaultPaperBookButton_Clicked(object sender, EventArgs e)
    {
        paperBook1 = new PaperBook();
    }
    private void DefaultEBookButton_Clicked(object sender, EventArgs e)
    {
        eBook1 = new EBook();
    }

    async private void ParameterizedPaperBookButton_Clicked(object sender, EventArgs e)
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

        string coverType = await DisplayPromptAsync(
            "Input Cover Type",
            "Please enter your text:",
            "OK",
            "Cancel",
            placeholder: "Type here...",
            maxLength: 100,
            keyboard: Keyboard.Text
        );
        string publishingHouse = await DisplayPromptAsync(
            "Input Publishing House",
            "Please enter your text:",
            "OK",
            "Cancel",
            placeholder: "Type here...",
            maxLength: 100,
            keyboard: Keyboard.Text
        );

        paperBook2 = new PaperBook(title, author, pages, coverType, publishingHouse);
    }

    async private void ParameterizedEBookButton_Clicked(object sender, EventArgs e)
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

        double.TryParse(await DisplayPromptAsync(
            "Input File Size",
            "Please enter your text:",
            "OK",
            "Cancel",
            placeholder: "Type here...",
            maxLength: 100,
            keyboard: Keyboard.Text
        ), out double fileSize);

        string format = await DisplayPromptAsync(
            "Input Format",
            "Please enter your text:",
            "OK",
            "Cancel",
            placeholder: "Type here...",
            maxLength: 100,
            keyboard: Keyboard.Text
        );

        eBook2 = new EBook(title, author, pages, fileSize:fileSize, format:format);
    }

    private void ShowObjectCountButton_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Object Count", $"Total Books Created: {Book.Count}", "OK");
    }


    private void ExitButton_Clicked(object sender, EventArgs e)
    {
#if MACCATALYST
        UIKit.UIApplication.SharedApplication.PerformSelector(new ObjCRuntime.Selector("terminateWithSuccess"), null, 0);
#endif
    }
}