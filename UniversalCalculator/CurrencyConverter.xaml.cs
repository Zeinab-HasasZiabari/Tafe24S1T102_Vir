using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class CurrencyConverter : Page
	{
		public CurrencyConverter()
		{
			this.InitializeComponent();
		}


		private void ConvertCurrency_Click(object sender, RoutedEventArgs e)
		{
			// Define conversion rates
			var conversionRates = new Dictionary<string, Dictionary<string, double>>
			{
				{"USD", new Dictionary<string, double>{{ "USD", 1.0}, { "EUR", 0.85189982}, {"GBP", 0.72872436}, {"INR", 74.257327}}},
				{"EUR", new Dictionary<string, double>{{ "EUR", 1.0 }, {"USD", 1.1739732}, {"GBP", 0.8556672}, {"INR", 87.00755}}},
				{"GBP", new Dictionary<string, double>{{ "GBP", 1.0 }, { "USD", 1.371907}, {"EUR", 1.1686692}, {"INR", 101.68635}}},
				{"INR", new Dictionary<string, double>{{ "INR", 1.0 }, { "USD", 0.011492628}, {"EUR", 0.013492774}, {"GBP", 0.0098339397}}}
			};

			// Extract user inputs.
			string fromCurrencyKey = ((ComboBoxItem)fromCurrency.SelectedItem).Content.ToString().Split("  ")[0];
			string toCurrencyKey = ((ComboBoxItem)toCurrency.SelectedItem).Content.ToString().Split("  ")[0];
			double amountToConvert = double.Parse(amountInput.Text);

			// Perform conversion.
			double convertedAmount = ConvertCurrency(amountToConvert, fromCurrencyKey, toCurrencyKey, conversionRates);

			// Display result.
			string from = $"{((ComboBoxItem)fromCurrency.SelectedItem).Content.ToString().Split("  ")[2]}";
			string to = $"{((ComboBoxItem)toCurrency.SelectedItem).Content.ToString().Split("  ")[2]}";
			conversionAmount.Text = $"{amountInput.Text} {from}s =";
			conversionResult.Text = $"${convertedAmount:F8} {to}s";
			conversionFoward.Text = $"1 {fromCurrencyKey} = {ConvertCurrency(1, fromCurrencyKey, toCurrencyKey, conversionRates)} {to}s";
			conversionReverse.Text = $"1 {toCurrencyKey} = {ConvertCurrency(1, toCurrencyKey, fromCurrencyKey, conversionRates)} {to}s";
		}

		private double ConvertCurrency(double amount, string fromCurrency, string toCurrency, Dictionary<string, Dictionary<string, double>> rates)
		{
			if (rates.ContainsKey(fromCurrency) && rates[fromCurrency].ContainsKey(toCurrency))
			{
				return amount * rates[fromCurrency][toCurrency];
			}
			else
			{
				return -1;
			}
		}

		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu));
		}
	}
}
