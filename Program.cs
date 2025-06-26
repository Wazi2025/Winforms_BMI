using winforms_bmi.classes;

namespace winforms_bmi;

static class Program
{
    public static Person person = new classes.Person();
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

    public static double ValidateInput(string input)
    {
        double output;

        if (string.IsNullOrWhiteSpace(input) || !double.TryParse(input, out output))
        {
            return 0;
        }

        return output;
    }
}