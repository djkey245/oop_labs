namespace OOPLRTest;

public partial class LAB11 : ContentPage
{
	private double _memory = 0;
	private double _current = 0;
	private double _operand = 0;
	private string _operator = "";
	private bool _isNewEntry = true;
	private bool _hasDecimal = false;

	public LAB11()
	{
		InitializeComponent();
		UpdateDisplay();
	}

	private void UpdateDisplay()
	{
		ResultEntry.Text = _current.ToString();
		MemoryLabel.Text = _memory != 0 ? $"M: {_memory}" : "M:";
	}

	private void OnDigitClicked(object? sender, EventArgs e)
	{
		if (sender is Button btn)
		{
			string digit = btn.Text;
			if (_isNewEntry)
			{
				ResultEntry.Text = digit == "," ? "0," : digit;
				_isNewEntry = false;
				_hasDecimal = digit == ",";
			}
			else
			{
				if (digit == ",")
				{
					if (!_hasDecimal)
					{
						ResultEntry.Text += ",";
						_hasDecimal = true;
					}
				}
				else
				{
					ResultEntry.Text += digit;
				}
			}
			_current = ParseEntry(ResultEntry.Text);
		}
	}

	private void OnOperatorClicked(object? sender, EventArgs e)
	{
		if (sender is Button btn)
		{
			CalculatePending();
			_operator = btn.Text;
			_operand = _current;
			_isNewEntry = true;
			_hasDecimal = false;
		}
	}

	private void OnEqualsClicked(object? sender, EventArgs e)
	{
		CalculatePending();
		_operator = "";
		_isNewEntry = true;
		_hasDecimal = false;
	}

	private void CalculatePending()
	{
		double result = _operand;
		double value = _current;
		switch (_operator)
		{
			case "+": result = _operand + value; break;
			case "-": result = _operand - value; break;
			case "*": result = _operand * value; break;
			case "/": result = value == 0 ? 0 : _operand / value; break;
			default: result = value; break;
		}
		_current = result;
		_operand = result;
		UpdateDisplay();
	}

	private void OnClearClicked(object? sender, EventArgs e)
	{
		_current = 0;
		_operand = 0;
		_operator = "";
		_isNewEntry = true;
		_hasDecimal = false;
		UpdateDisplay();
	}

	private void OnBackspaceClicked(object? sender, EventArgs e)
	{
		if (!_isNewEntry && ResultEntry.Text.Length > 0)
		{
			string text = ResultEntry.Text;
			if (text.EndsWith(",")) _hasDecimal = false;
			text = text.Substring(0, text.Length - 1);
			if (string.IsNullOrEmpty(text) || text == "-") text = "0";
			ResultEntry.Text = text;
			_current = ParseEntry(text);
		}
	}

	private void OnSqrtClicked(object? sender, EventArgs e)
	{
		if (_current >= 0)
		{
			_current = Math.Sqrt(_current);
			ResultEntry.Text = _current.ToString();
			_isNewEntry = true;
			_hasDecimal = ResultEntry.Text.Contains(",");
		}
	}

	private void OnSignClicked(object? sender, EventArgs e)
	{
		_current = -_current;
		ResultEntry.Text = _current.ToString();
		_isNewEntry = true;
		_hasDecimal = ResultEntry.Text.Contains(",");
	}

	private void OnCommaClicked(object? sender, EventArgs e)
	{
		if (!_hasDecimal)
		{
			if (_isNewEntry)
			{
				ResultEntry.Text = "0,";
				_isNewEntry = false;
			}
			else
			{
				ResultEntry.Text += ",";
			}
			_hasDecimal = true;
		}
	}

	private void OnPercentClicked(object? sender, EventArgs e)
	{
		_current = _operand * _current / 100.0;
		ResultEntry.Text = _current.ToString();
		_isNewEntry = true;
		_hasDecimal = ResultEntry.Text.Contains(",");
	}

	private void OnInverseClicked(object? sender, EventArgs e)
	{
		if (_current != 0)
		{
			_current = 1.0 / _current;
			ResultEntry.Text = _current.ToString();
			_isNewEntry = true;
			_hasDecimal = ResultEntry.Text.Contains(",");
		}
	}

	private void OnMRClicked(object? sender, EventArgs e)
	{
		_current = _memory;
		ResultEntry.Text = _current.ToString();
		_isNewEntry = true;
		_hasDecimal = ResultEntry.Text.Contains(",");
	}

	private void OnMCClicked(object? sender, EventArgs e)
	{
		_memory = 0;
		UpdateDisplay();
	}

	private void OnMPlusClicked(object? sender, EventArgs e)
	{
		_memory += _current;
		UpdateDisplay();
	}

	private void OnMMinusClicked(object? sender, EventArgs e)
	{
		_memory -= _current;
		UpdateDisplay();
	}

	private void OnOffClicked(object? sender, EventArgs e)
	{
		Navigation.PopModalAsync();
	}

	private void OnCosClicked(object? sender, EventArgs e)
	{
		_current = Math.Cos(_current);
		ResultEntry.Text = _current.ToString();
		_isNewEntry = true;
		_hasDecimal = ResultEntry.Text.Contains(",");
	}

	private void OnSinClicked(object? sender, EventArgs e)
	{
		_current = Math.Sin(_current);
		ResultEntry.Text = _current.ToString();
		_isNewEntry = true;
		_hasDecimal = ResultEntry.Text.Contains(",");
	}

	private void OnTanClicked(object? sender, EventArgs e)
	{
		_current = Math.Tan(_current);
		ResultEntry.Text = _current.ToString();
		_isNewEntry = true;
		_hasDecimal = ResultEntry.Text.Contains(",");
	}

	private void OnCotanClicked(object? sender, EventArgs e)
	{
		if (_current != 0)
		{
			_current = 1.0 / Math.Tan(_current);
		}
		else
		{
			_current = 0;
		}
		ResultEntry.Text = _current.ToString();
		_isNewEntry = true;
		_hasDecimal = ResultEntry.Text.Contains(",");
	}

	private double ParseEntry(string text)
	{
		if (string.IsNullOrWhiteSpace(text)) return 0;
		text = text.Replace(",", ".");
		double.TryParse(text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double val);
		return val;
	}
} 