using System;

namespace CalculatorBMI;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCalculateButtonClicked(object sender, EventArgs e)
    {
        string weightText = WeightEntry.Text;
        string heightText = HeightEntry.Text;

        if (double.TryParse(weightText, out double weight) && double.TryParse(heightText, out double height) && height > 0)
        {
            double bmi = weight / (height * height);
            ResultLabel.Text = $"Your BMI: {bmi:F2}";
        }
        else
        {
            ResultLabel.Text = "Please enter valid numbers for weight and height.";
        }
    }
}