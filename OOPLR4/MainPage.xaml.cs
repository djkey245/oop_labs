namespace OOPLR4;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    async private void CompareQuantities_Click(object sender, EventArgs e)
    {
        string text = await DisplayPromptAsync(
            "Input Text",
            "Please enter your text:",
            "OK",
            "Cancel",
            placeholder: "Type here...",
            maxLength: 250,
            keyboard: Keyboard.Text
        );

        if (string.IsNullOrEmpty(text))
        {
            await DisplayAlert("Error", "You didn't enter any text.", "OK");
            return;
        }

        int count = 0;
        foreach (char c in text)
        {
            if (char.ToLower(c) == 'м')
            {
                count++;
            }
        }

        string message = $"Букв 'м' в тексті: {count}";
        await DisplayAlert("Info", message, "OK");
    }

    async private void ReplaceQuotes_Click(object sender, EventArgs e)
    {
        string text = await DisplayPromptAsync(
            "Input Text",
            "Please enter your text:",
            "OK",
            "Cancel",
            placeholder: "Type here...",
            maxLength: 500,
            keyboard: Keyboard.Text
        );

        if (string.IsNullOrEmpty(text))
        {
            await DisplayAlert("Error", "You didn't enter any text.", "OK");
            return;
        }

        string updatedText = text.Replace("\"", ",,");

        string message = $"Змінений текст: {updatedText}\nОригінальний текст: {text}";
        await DisplayAlert("Info", message, "OK");
    }

    private void ExitButton_Clicked(object sender, EventArgs e)
    {
#if MACCATALYST
        UIKit.UIApplication.SharedApplication.PerformSelector(new ObjCRuntime.Selector("terminateWithSuccess"), null, 0);
#endif
    }
}
