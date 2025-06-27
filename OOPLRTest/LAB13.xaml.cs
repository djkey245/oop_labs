namespace OOPLRTest;

public partial class LAB13 : ContentPage
{
    public LAB13()
    {
        InitializeComponent();
        LastNameEntry.Text = "Ковальчук";
        FirstNameEntry.Text = "Дмитро";
        PatronymicEntry.Text = "Олексійович";
        LastNameEntry.TextChanged += OnInputChanged;
        FirstNameEntry.TextChanged += OnInputChanged;
        PatronymicEntry.TextChanged += OnInputChanged;
        UpdateEmployeeData();
    }

    protected virtual void UpdateEmployeeData()
    {
        EmployeeDataEntry.Text = $"{LastNameEntry.Text} {FirstNameEntry.Text} {PatronymicEntry.Text}".Trim();
    }

    private void OnInputChanged(object? sender, TextChangedEventArgs e)
    {
        UpdateEmployeeData();
    }

    public string EmployeeDataEntryText 
    {
        get => EmployeeDataEntry.Text;
        set => EmployeeDataEntry.Text = value;
    }

    private async void OnFinishClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    protected string GetFullName()
    {
        return $"{LastNameEntry.Text} {FirstNameEntry.Text} {PatronymicEntry.Text}".Trim();
    }
} 