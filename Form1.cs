namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        private int firstOperand;
        private int secondOperand;
        private int result;
        private string currentInput = string.Empty;
        private bool plusSelected;
        private bool justCalculated;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResetCalculator();
        }

        private void NumberButton_Click(object? sender, EventArgs e)
        {
            if (sender is not Button button)
            {
                return;
            }

            if (justCalculated && !plusSelected)
            {
                ResetCalculator();
            }

            currentInput += button.Text;
            UpdateInputDisplays();
        }

        private void btn_plus_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(currentInput, out firstOperand))
            {
                return;
            }

            currentInput = string.Empty;
            plusSelected = true;
            justCalculated = false;
            txt_show.Text = $"{firstOperand} +";
            txt_oprnd.Text = "0";
        }

        private void btn_equal_Click(object? sender, EventArgs e)
        {
            if (!plusSelected || !int.TryParse(currentInput, out secondOperand))
            {
                return;
            }

            result = firstOperand + secondOperand;
            txt_show.Text = $"{firstOperand} + {secondOperand} = {result}";
            txt_oprnd.Text = result.ToString();
            currentInput = result.ToString();
            plusSelected = false;
            justCalculated = true;
        }

        private void btn_CE_Click(object? sender, EventArgs e)
        {
            currentInput = string.Empty;
            txt_oprnd.Text = "0";

            if (plusSelected)
            {
                txt_show.Text = $"{firstOperand} +";
                return;
            }

            txt_show.Text = string.Empty;
        }

        private void btn_C_Click(object? sender, EventArgs e)
        {
            ResetCalculator();
        }

        private void btn_del_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentInput))
            {
                return;
            }

            currentInput = currentInput[..^1];
            UpdateInputDisplays();
        }

        private void UpdateInputDisplays()
        {
            txt_oprnd.Text = string.IsNullOrEmpty(currentInput) ? "0" : currentInput;

            if (plusSelected)
            {
                txt_show.Text = string.IsNullOrEmpty(currentInput)
                    ? $"{firstOperand} +"
                    : $"{firstOperand} + {currentInput}";
                return;
            }

            txt_show.Text = currentInput;
        }

        private void ResetCalculator()
        {
            firstOperand = 0;
            secondOperand = 0;
            result = 0;
            currentInput = string.Empty;
            plusSelected = false;
            justCalculated = false;
            txt_show.Text = string.Empty;
            txt_oprnd.Text = "0";
        }
    }
}
