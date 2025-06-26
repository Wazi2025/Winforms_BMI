namespace winforms_bmi;

public partial class Mainform : Form
{
    private Label lblHeight;
    private Label lblWeight;
    private TextBox tbHeight;
    private TextBox tbWeight;
    private TableLayoutPanel tblMain;
    private Button btnCalculate;
    private Label lblBMIOutput;

    void btnCalculate_Click(object sender, EventArgs e)
    {
        if (Program.ValidateHeightInput(tbHeight.Text) == 0 || Program.ValidateWeightInput(tbWeight.Text) == 0)
        {
            lblBMIOutput.Text = "Invalid input. Please use integer/decimal numbers";
        }
        else
        {
            //Calculate BMI using the BMI formula
            //Program.person.Bmi = Program.person.WeightFloat / (Program.person.HeightFloat / 100 * Program.person.HeightFloat / 100);
            Program.person.Bmi = Program.CalculateBMI();

            //Format with 2 decimals
            lblBMIOutput.Text = $"Your BMI is: {Program.person.Bmi.ToString("F2")}";
        }
    }

    private void tbHeight_TextChanged(object sender, EventArgs e)
    {
        lblBMIOutput.Text = "";
    }

    private void tbWeight_TextChanged(object sender, EventArgs e)
    {
        lblBMIOutput.Text = "";
    }
    public void InitializeControls()
    {
        //Initalize the form's labels, textboxes
        btnCalculate = new Button();
        btnCalculate.Text = "Calculate BMI";
        btnCalculate.AutoSize = true;

        //Hook up button clicked event
        btnCalculate.Click += new EventHandler(this.btnCalculate_Click);

        lblBMIOutput = new Label();
        lblBMIOutput.Text = "";
        lblBMIOutput.AutoSize = true;

        lblHeight = new Label();
        lblHeight.Text = "Height (in cm):";
        lblHeight.AutoSize = true;

        lblWeight = new Label();
        lblWeight.Text = "Weight (in kg):";
        lblWeight.AutoSize = true;

        tbHeight = new TextBox();

        //Hook up text changed event
        tbHeight.TextChanged += new EventHandler(this.tbHeight_TextChanged);

        tbWeight = new TextBox();

        //Hook up text changed event
        tbWeight.TextChanged += new EventHandler(this.tbWeight_TextChanged);

        tblMain = new TableLayoutPanel();
        tblMain.ColumnCount = 3;
        tblMain.Controls.Add(lblHeight, 2, 10);
        tblMain.Controls.Add(tbHeight, 2, 20);

        tblMain.Controls.Add(lblWeight, 2, 30);
        tblMain.Controls.Add(tbWeight, 2, 40);

        tblMain.Controls.Add(btnCalculate, 2, 50);
        tblMain.Controls.Add(lblBMIOutput, 2, 60);

        tblMain.AutoSize = true;
        this.Controls.Add(tblMain);
        this.Text = "BMI Calculator";
        this.MaximizeBox = false;
        this.Size = new System.Drawing.Size(300, 300);
        this.StartPosition = FormStartPosition.CenterScreen;

    }

    //Mainform's constructor
    public Mainform()
    {
        InitializeComponent();
        InitializeControls();
    }
}
