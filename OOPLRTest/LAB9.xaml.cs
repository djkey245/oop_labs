namespace OOPLRTest;
using System.Collections.Generic;

public partial class LAB9 : ContentPage
{
	private const string InfoText = "C# — це потужна об'єктно-орієнтована мова програмування, і ООП (об'єктно-орієнтоване програмування) є її фундаментальною основою. Використання ООП у C# дозволяє розробникам створювати модульний, гнучкий та легко підтримуваний код, що є критично важливим для великих і складних програм.";

	public LAB9()
	{
		InitializeComponent();
	}

	private void OnProcess1Clicked(object sender, EventArgs e)
	{
		string input = InputEntry1.Text ?? string.Empty;
		string result = string.Empty;
		for (int i = 0; i < input.Length; i++)
		{
			result += input[i] + "?";
		}
		ResultEntry1.Text = result;
	}

	private void OnProcess2Clicked(object sender, EventArgs e)
	{
		string input = InputEntry2.Text ?? string.Empty;
		string result = string.Empty;
		for (int i = 0; i < input.Length; i++)
		{
			if (i + 1 < input.Length && input[i] == 'н' && input[i + 1] == 'е')
			{
				i++; // пропускаємо 'н' і 'е'
				continue;
			}
			result += input[i];
		}
		ResultEntry2.Text = result;
	}

	private void OnProcess3Clicked(object sender, EventArgs e)
	{
		string word = (InputEntry3.Text ?? string.Empty).ToLower();
		string text = InfoText;
		int count = 0;
		var words = SplitWords(text);
		foreach (var w in words)
		{
			if (w.ToLower() == word && word.Length > 0)
			{
				count++;
			}
		}
		ResultEntry3.Text = count.ToString();
	}

	private async void OnFinishClicked(object sender, EventArgs e)
	{
		await Navigation.PopModalAsync();
	}

	private List<string> SplitWords(string text)
	{
		var words = new List<string>();
		if (string.IsNullOrEmpty(text)) return words;
		var sb = new System.Text.StringBuilder();
		foreach (char c in text)
		{
			if (char.IsLetterOrDigit(c) || c == '#')
			{
				sb.Append(c);
			}
			else
			{
				if (sb.Length > 0)
				{
					words.Add(sb.ToString());
					sb.Clear();
				}
			}
		}
		if (sb.Length > 0)
			words.Add(sb.ToString());
		return words;
	}
} 