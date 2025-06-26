using winforms_bmi.classes;
using System.Globalization;

namespace winforms_bmi;

static class Program
{
    //Adding person as a field so we can access it here or in Mainform
    public static Person person = new classes.Person();

    //Check the local decimal separator or else the calculations will fail due to 90,7 will be read as 907
    private static string decimalFormat = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new Mainform());
    }

    public static double ValidateHeightInput(string input)
    {
        double output;

        //Replace ',' with '.' if found 
        if (!input.Contains(decimalFormat))
            input = input.Replace(",", decimalFormat);

        if (string.IsNullOrWhiteSpace(input) || !double.TryParse(input, out output))// || !input.Contains(decimalFormat))
        {
            output = 0;
            return output;
        }
        Program.person.HeightFloat = output;
        return output;
    }

    public static double ValidateWeightInput(string input)
    {
        double output;

        if (!input.Contains(decimalFormat))
            input = input.Replace(",", decimalFormat);

        if (string.IsNullOrWhiteSpace(input) || !double.TryParse(input, out output))// || !input.Contains(decimalFormat))
        {
            output = 0;
            return output;
        }
        Program.person.WeightFloat = output;
        return output;
    }

    public static double CalculateBMI()
    {
        //Calculate BMI using the BMI formula
        return person.WeightFloat / (person.HeightFloat / 100 * person.HeightFloat / 100);
    }
}