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
	public sealed partial class MortgageCalculator : Page
	{
		public MortgageCalculator()
		{
			this.InitializeComponent();
		}

		private void calculateButton_Click(object sender, RoutedEventArgs e)
		{
			double m, p, i;
			int year, month, n;

			p = double.Parse(principalBorrowTextBox.Text);
			double yearlyInterestRate = double.Parse(yearlyInterestRateTextBox.Text);
			year = int.Parse(yearsTextBox.Text);
			month = int.Parse(monthsTextBox.Text);
			n = (year * 12) + month;
			i = yearlyInterestRate / 1200;
			monthlyInterestRateTextBox.Text = i.ToString("F4") + "%";


			double baseNumber = 1 + i;
			double x = Math.Pow(baseNumber, n);
			m = (p * i * x) / (x - 1);
			monthlyRepaymentTextBox.Text  = m.ToString("N");

		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu));
		}
	}
}
