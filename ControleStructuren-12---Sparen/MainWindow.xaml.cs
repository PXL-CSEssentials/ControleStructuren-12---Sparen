using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControleStructuren_12___Sparen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            decimal weeklyAmount = 0.0M;
            decimal weeklyIncrement = 0.0M;
            decimal desiredAmount = 0.0M;

            bool hasFailed = !decimal.TryParse(weeklyAmountTextBox.Text, out weeklyAmount) ||
                !decimal.TryParse(weeklyIncrementTextBox.Text, out weeklyIncrement) ||
                !decimal.TryParse(desiredAmountTextBox.Text, out desiredAmount);

            /*
            bool isSucceeded = decimal.TryParse(weeklyAmountTextBox.Text, out weeklyAmount) &&
                decimal.TryParse(weeklyIncrementTextBox.Text, out weeklyIncrement) &&
                decimal.TryParse(desiredAmountTextBox.Text, out desiredAmount);
            */

            if (hasFailed)
            {
                clearButton_Click(this, null);
                return;
            }

            decimal savings = 0.0M;
            decimal extraWeeklyAmount = 0.0M;
            decimal totalSavings = 0.0M;
            int numberOfWeeks = 0;
            do
            {
                savings += weeklyAmount;
                extraWeeklyAmount += weeklyIncrement;
                totalSavings = savings + extraWeeklyAmount;
                numberOfWeeks++;
            } while (totalSavings < desiredAmount);

            resultTextBox.Text = $"Spaarbedrag na {numberOfWeeks} weken: {savings:c}\r\n\r\n" +
                $"Extra weekgeld op dat moment: {extraWeeklyAmount:c}\r\n\r\n" +
                $"Totaal spaargeld: {totalSavings:c}";
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            weeklyAmountTextBox.Clear();
            weeklyIncrementTextBox.Clear();
            desiredAmountTextBox.Clear();
            resultTextBox.Clear();

            weeklyAmountTextBox.Focus();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
