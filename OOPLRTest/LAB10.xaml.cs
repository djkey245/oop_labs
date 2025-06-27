namespace OOPLRTest;

public partial class LAB10 : ContentPage
{
	private string _lastX = "1.5";
	private string _lastY = "0.1";
	private bool _suppressTextChanged = false;

	public LAB10()
	{
		InitializeComponent();
		InputX.TextChanged += OnNumberEntryTextChanged;
		InputY.TextChanged += OnNumberEntryTextChanged;
		InputX.Completed += OnNumberEntryCompleted;
		InputY.Completed += OnNumberEntryCompleted;
		InputX.Text = "1.5";
		InputY.Text = "0.1";
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		CalculateAndShow();
	}

	private void OnNumberEntryTextChanged(object? sender, TextChangedEventArgs e)
	{
		if (_suppressTextChanged) return;
		if (sender is Entry entry)
		{
			string prev = entry == InputX ? _lastX : _lastY;
			if (entry.Text == "")
			{
				_suppressTextChanged = true;
				entry.Text = "0";
				if (entry == InputX) _lastX = "0"; else _lastY = "0";
				_suppressTextChanged = false;
				return;
			}
			if (!double.TryParse(entry.Text, out _))
			{
				_suppressTextChanged = true;
				entry.Text = prev;
				_suppressTextChanged = false;
				return;
			}
			if (entry == InputX) _lastX = entry.Text; else _lastY = entry.Text;
		}
	}

	private void OnNumberEntryCompleted(object? sender, EventArgs e)
	{
		if (sender is Entry entry)
		{
			string text = entry.Text ?? "";
			string filtered = FilterNumberInput(text);
			if (filtered != text)
			{
				_suppressTextChanged = true;
				entry.Text = filtered;
				_suppressTextChanged = false;
			}
		}
	}

	private string FilterNumberInput(string input)
	{
		var result = new System.Text.StringBuilder();
		bool hasDecimal = false;
		bool hasMinus = false;
		for (int i = 0; i < input.Length; i++)
		{
			char c = input[i];
			if (char.IsDigit(c))
			{
				result.Append(c);
			}
			else if ((c == '.' || c == ',') && !hasDecimal)
			{
				result.Append('.');
				hasDecimal = true;
			}
			else if (c == '-' && i == 0 && !hasMinus)
			{
				result.Append('-');
				hasMinus = true;
			}
		}
		return result.ToString();
	}

	private void OnCalcNoFuncClicked(object? sender, EventArgs e)
	{
		CalculateAndShow(false);
	}

	private void OnCalcFuncClicked(object? sender, EventArgs e)
	{
		CalculateAndShow(true);
	}

	private void CalculateAndShow(bool useFuncs = false)
	{
		if (TryGetInputs(out double x, out double y))
		{
			double S;
			if (useFuncs)
			{
				S = CubeRoot(2 + Cos2(x)) / 84
					+ (5.87 * x) / FourthRoot(3 + Cos2(y))
					+ CubeRoot(2 + Cos2(x * y)) / 9;
			}
			else
			{
				S = Math.Pow(2 + Math.Pow(Math.Cos(x), 2), 1.0 / 3) / 84
					+ (5.87 * x) / Math.Pow(3 + Math.Pow(Math.Cos(y), 2), 1.0 / 4)
					+ Math.Pow(2 + Math.Pow(Math.Cos(x * y), 2), 1.0 / 3) / 9;
			}
			ResultEntry.Text = S.ToString();
		}
		else
		{
			ResultEntry.Text = "Некоректні дані";
		}
	}

	private double Cos2(double val)
	{
		return Math.Pow(Math.Cos(val), 2);
	}

	private double CubeRoot(double val)
	{
		return Math.Pow(val, 1.0 / 3);
	}

	private double FourthRoot(double val)
	{
		return Math.Pow(val, 1.0 / 4);
	}

	private bool TryGetInputs(out double x, out double y)
	{
		x = y = 0;
		return double.TryParse(InputX.Text, out x)
			&& double.TryParse(InputY.Text, out y);
	}

	private async void OnFinishClicked(object? sender, EventArgs e)
	{
		await Navigation.PopModalAsync();
	}
} 