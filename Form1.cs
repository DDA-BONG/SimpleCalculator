namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        private int firstOperand;
        private int secondOperand;
        private int result;
        private string currentInput = string.Empty;
        private string currentOperator = string.Empty;
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

            if (justCalculated && string.IsNullOrEmpty(currentOperator))
            {
                ResetCalculator();
            }

            currentInput += button.Text;
            UpdateInputDisplays();
        }

        private void OperatorButton_Click(object? sender, EventArgs e)
        {
            if (sender is not Button button)
            {
                return;
            }

            if (!int.TryParse(currentInput, out firstOperand))
            {
                return;
            }

            currentInput = string.Empty;
            currentOperator = button.Text;
            justCalculated = false;
            txt_show.Text = $"{firstOperand} {currentOperator}";
            txt_oprnd.Text = "0";
        }

        private void btn_equal_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentOperator) || !int.TryParse(currentInput, out secondOperand))
            {
                return;
            }

            if (!TryCalculateResult(out result))
            {
                return;
            }

            txt_show.Text = $"{firstOperand} {currentOperator} {secondOperand} = {result}";
            txt_oprnd.Text = result.ToString();
            currentInput = result.ToString();
            currentOperator = string.Empty;
            justCalculated = true;
        }

        private void btn_CE_Click(object? sender, EventArgs e)
        {
            currentInput = string.Empty;
            txt_oprnd.Text = "0";

            if (!string.IsNullOrEmpty(currentOperator))
            {
                txt_show.Text = $"{firstOperand} {currentOperator}";
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

            if (!string.IsNullOrEmpty(currentOperator))
            {
                txt_show.Text = string.IsNullOrEmpty(currentInput)
                    ? $"{firstOperand} {currentOperator}"
                    : $"{firstOperand} {currentOperator} {currentInput}";
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
            currentOperator = string.Empty;
            justCalculated = false;
            txt_show.Text = string.Empty;
            txt_oprnd.Text = "0";
        }

        private bool TryCalculateResult(out int calculatedResult)
        {
            calculatedResult = currentOperator switch
            {
                "+" => firstOperand + secondOperand,
                "-" => firstOperand - secondOperand,
                "*" => firstOperand * secondOperand,
                "/" when secondOperand != 0 => firstOperand / secondOperand,
                _ => 0
            };

            if (currentOperator == "/" && secondOperand == 0)
            {
                MessageBox.Show("0으로 나눌 수 없습니다.", "계산 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_show.Text = $"{firstOperand} {currentOperator}";
                txt_oprnd.Text = "0";
                currentInput = string.Empty;
                return false;
            }

            return true;
        }
    }
}
