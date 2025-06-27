namespace OOPLRTest;

public partial class LAB13Ex : LAB13
{
    public DatePicker BirthdayPicker { get; private set; }
    private const string DefaultFileName = "employee_data.txt";
    public LAB13Ex(): base()
    {
        // Додаємо Label і DatePicker після PatronymicEntry
        BirthdayPicker = new DatePicker { WidthRequest = 300, Date = new DateTime(1998, 2, 3) };
        var label = new Label { Text = "День народження" };

        if (this.Content is ScrollView scroll && scroll.Content is VerticalStackLayout stack)
        {
            // Додаю підпис зверху
            stack.Children.Insert(0, new Label {
                Text = "Laba 13+14",
                FontSize = 22,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center,
                Margin = new Thickness(0, 0, 0, 20)
            });
            int index = stack.Children.IndexOf(PatronymicEntry);
            if (index != -1)
            {
                stack.Children.Insert(index + 1, label);
                stack.Children.Insert(index + 2, BirthdayPicker);
            }
            // Додаємо кнопки таблицею 2x2 перед кнопкою "Завершити роботу"
            var finishButton = stack.Children.OfType<Button>().FirstOrDefault(b => b.Text == "Завершити роботу");
            int finishIndex = finishButton != null ? stack.Children.IndexOf(finishButton) : stack.Children.Count;

            var grid = new Grid
            {
                ColumnDefinitions = { new ColumnDefinition{ Width = GridLength.Star }, new ColumnDefinition{ Width = GridLength.Star } },
                RowDefinitions = { new RowDefinition{ Height = GridLength.Auto }, new RowDefinition{ Height = GridLength.Auto } },
                Margin = new Thickness(0, 10)
            };
            var btn1 = CreateMultilineButton("Записати дані\nу файл по \nзамовчуванню", OnWriteToDefaultFileClicked);
            var btn2 = CreateMultilineButton("Записати дані\nв обраний файл", OnWriteToSelectedFileClicked);
            var btn3 = CreateMultilineButton("Зчитати дані\nз файла по \nзамовчуванню", OnReadFromDefaultFileClicked);
            var btn4 = CreateMultilineButton("Зчитати дані\nз обраного файлу", OnReadFromSelectedFileClicked);
            grid.Add(btn1, 0, 0);
            grid.Add(btn2, 1, 0);
            grid.Add(btn3, 0, 1);
            grid.Add(btn4, 1, 1);
            stack.Children.Insert(finishIndex, grid);
        }

        BirthdayPicker.DateSelected += OnAnyInputChanged;
        LastNameEntry.TextChanged += OnAnyInputChanged;
        FirstNameEntry.TextChanged += OnAnyInputChanged;
        PatronymicEntry.TextChanged += OnAnyInputChanged;

        UpdateEmployeeData();
    }

    private void OnAnyInputChanged(object? sender, EventArgs e)
    {
        UpdateEmployeeData();
    }

    private void UpdateEmployeeData()
    {
        int years = CalculateAge(BirthdayPicker.Date, DateTime.Now);
        EmployeeDataEntry.Text = $"{base.GetFullName()} {years} років".Trim();
    }

    private int CalculateAge(DateTime birthDate, DateTime now)
    {
        int age = now.Year - birthDate.Year;
        if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
            age--;
        return age;
    }

    private View CreateMultilineButton(string text, EventHandler onClick)
    {
        var label = new Label
        {
            Text = text,
            WidthRequest = 200,
            HeightRequest = 80,
            Padding = new Thickness(10, 10),
            Margin = new Thickness(10, 10),
            FontSize = 12,
            BackgroundColor = Colors.LightGray,
            TextColor = Colors.Black,
            HorizontalTextAlignment = TextAlignment.Center,
            VerticalTextAlignment = TextAlignment.Center,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
        };
        var tap = new TapGestureRecognizer();
        tap.Tapped += (s, e) => onClick(s, EventArgs.Empty);
        label.GestureRecognizers.Add(tap);
        return label;
    }

    private void OnWriteToDefaultFileClicked(object? sender, EventArgs e)
    {
        writeFile();
    }

    private async void OnWriteToSelectedFileClicked(object? sender, EventArgs e)
    {
        string result = await Application.Current.MainPage.DisplayPromptAsync(
            "Введіть ім'я файлу",
            "Тільки латиниця, цифри, підкреслення, тире. Без розширення .txt",
            initialValue: "employee_data",
            maxLength: 32,
            keyboard: Keyboard.Text
        );
        if (string.IsNullOrWhiteSpace(result))
            return;
        // Валідація: тільки латиниця, цифри, підкреслення, тире
        if (!System.Text.RegularExpressions.Regex.IsMatch(result, "^[a-zA-Z0-9_-]+$"))
        {
            await Application.Current.MainPage.DisplayAlert("Помилка", "Некоректне ім'я файлу!", "OK");
            return;
        }
        await writeFile(result + ".txt");
    }

    private async void OnReadFromDefaultFileClicked(object? sender, EventArgs e)
    {
        await ReadFileAndFillFields(DefaultFileName);
    }

    private async void OnReadFromSelectedFileClicked(object? sender, EventArgs e)
    {
        string result = await Application.Current.MainPage.DisplayPromptAsync(
            "Введіть ім'я файлу",
            "Тільки латиниця, цифри, підкреслення, тире. Без розширення .txt",
            initialValue: "employee_data",
            maxLength: 32,
            keyboard: Keyboard.Text
        );
        if (string.IsNullOrWhiteSpace(result))
            return;
        if (!System.Text.RegularExpressions.Regex.IsMatch(result, "^[a-zA-Z0-9_-]+$"))
        {
            await Application.Current.MainPage.DisplayAlert("Помилка", "Некоректне ім'я файлу!", "OK");
            return;
        }
        await ReadFileAndFillFields(result + ".txt");
    }

    private async Task ReadFileAndFillFields(string fileName)
    {
        try
        {
            string filePath = Path.Combine(FileSystem.Current.AppDataDirectory, fileName);
            if (!File.Exists(filePath))
            {
                await Application.Current.MainPage.DisplayAlert("Помилка", $"Файл {fileName} не знайдено!", "OK");
                return;
            }
            string[] lines = await File.ReadAllLinesAsync(filePath);
            if (lines.Length < 4)
            {
                await Application.Current.MainPage.DisplayAlert("Помилка", "Файл має некоректний формат!", "OK");
                return;
            }
            LastNameEntry.Text = lines[0];
            FirstNameEntry.Text = lines[1];
            PatronymicEntry.Text = lines[2];
            if (DateTime.TryParseExact(lines[3], "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out var date))
                BirthdayPicker.Date = date;
            else
                BirthdayPicker.Date = DateTime.Now;
            await Application.Current.MainPage.DisplayAlert("Успіх", $"Дані з файлу {fileName} завантажено!", "OK");
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Помилка", $"Не вдалося зчитати файл: {ex.Message}", "OK");
        }
    }

    // Запис у файл за замовчуванням
    private async void writeFile()
    {
        await writeFile(DefaultFileName);
    }

    // Запис у файл з вказаною назвою
    private async Task writeFile(string fileName)
    {
        try
        {
            string[] lines = new string[]
            {
                LastNameEntry.Text,
                FirstNameEntry.Text,
                PatronymicEntry.Text,
                BirthdayPicker.Date.ToString("dd.MM.yyyy")
            };
            string filePath = Path.Combine(FileSystem.Current.AppDataDirectory, fileName);
            await File.WriteAllLinesAsync(filePath, lines);
            await Application.Current.MainPage.DisplayAlert("Успіх", $"Дані записано у файл {filePath}", "OK");
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Помилка", $"Не вдалося записати у файл: {ex.Message}", "OK");
        }
    }
} 