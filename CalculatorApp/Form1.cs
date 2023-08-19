namespace CalculatorApp
{    public partial class Form1 : Form
    {
        double result = 0;
        string operation = "";
        bool enter_value = false;
        char iOperation;
        string firstNum, secondNum;
        public Form1()
        {
            InitializeComponent();
        }
        private void numbers_Only(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if ((txtDisplay.Text == "0") || (enter_value))
                txtDisplay.Text = "";
            enter_value = false;

            if (b.Text == ".")
            {
                if (!txtDisplay.Text.Contains("."))
                {
                    txtDisplay.Text = txtDisplay.Text + b.Text;
                }
            }
            else
            {
                txtDisplay.Text = txtDisplay.Text + b.Text;
            }
        }
        private void operators_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (result != 0)
            {
                btnEquls.PerformClick();
                enter_value = true;
                operation = b.Text;
                lblShowOp.Text = result + " " + operation;
            }
            else
            {
                operation = b.Text;
                result = double.Parse(txtDisplay.Text);
                txtDisplay.Text = "";
                lblShowOp.Text = Convert.ToString(result) + " " + operation;
            }
            firstNum = lblShowOp.Text;
        }
        private void button23_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "";
            firstNum = "";
            secondNum = "";
            lblShowOp.Text = "";
            rtbDisplayHistory.Text = "";result = 0;
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            secondNum = txtDisplay.Text;
            lblShowOp.Text = "";
            switch (operation)
            {
                case "+":
                    txtDisplay.Text = (result + double.Parse(txtDisplay.Text)).ToString();
                    break;

                case "-":
                    txtDisplay.Text = (result - double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "*":
                    txtDisplay.Text = (result * double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "/":
                    txtDisplay.Text = (result / double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "%":
                    txtDisplay.Text = (result / 100 * double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "2/X":
                    txtDisplay.Text = Math.Pow(result, double.Parse(txtDisplay.Text)).ToString(); ;
                    break;
                default: break;
            }
            result = double.Parse(txtDisplay.Text);
            operation = "";
            rtbDisplayHistory.AppendText(firstNum + "  " + secondNum + "  " + "\n");
            rtbDisplayHistory.AppendText("\n\t" + txtDisplay.Text + "\n\t");
        }
    }
}