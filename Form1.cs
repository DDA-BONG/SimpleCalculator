namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        private int firstOperand;
        private int secondOperand;
        private int result;
        private string currentInput = string.Empty;
        private string currentOperator = string.Empty;
        private string expressionText = string.Empty;
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
            justCalculated = false;
            UpdateInputDisplays();
        }

        private void OperatorButton_Click(object? sender, EventArgs e)
        {
            if (sender is not Button button)//연산자 버튼이 아닌 경우 무시
            {
                return;
            }

            if (string.IsNullOrEmpty(currentInput))//피연산자가 없는 상태에서 연산자 버튼을 누른 경우 기존 연산자 변경 또는 무시
            {
                if (!string.IsNullOrEmpty(expressionText))//이미 연산이 진행 중인 경우 연산자 변경
                {
                    currentOperator = button.Text;
                    expressionText = $"{firstOperand} {currentOperator}";
                    txt_show.Text = expressionText;
                }

                return;
            }

            if (string.IsNullOrEmpty(currentOperator))//첫 번째 피연산자 입력 후 연산자 버튼을 누른 경우
            {
                if (!int.TryParse(currentInput, out firstOperand))
                {
                    return;
                }

                expressionText = currentInput;
            }
            else
            {
                if (!int.TryParse(currentInput, out secondOperand))
                {
                    return;
                }

                if (!TryCalculateResult(out result))//이전 연산 결과 계산 실패(예: 0으로 나누기) 시 연산자 변경 없이 종료
                {
                    return;
                }

                firstOperand = result;
                expressionText = result.ToString();
                txt_oprnd.Text = result.ToString();
                //새로운 연산자 입력 시 이전 결과를 첫 번째 피연산자로 사용하여 연산식 업데이트
            }

            currentInput = string.Empty;
            secondOperand = 0;
            currentOperator = button.Text;
            justCalculated = false;
            expressionText = $"{expressionText} {currentOperator}";
            txt_show.Text = expressionText;
            txt_oprnd.Text = firstOperand.ToString();
            //연산자 버튼을 누를 때마다 연산식과 현재 입력을 업데이트
        }

        private void btn_equal_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentOperator) || !int.TryParse(currentInput, out secondOperand))//연산자 또는 피연산자가 없는 경우 계산하지 않고 종료
            {
                return;
            }

            if (!TryCalculateResult(out result))
            {
                return;
            }

            txt_show.Text = $"{expressionText} {secondOperand} = {result}";//string으로 변환 후 결과표시 및 계산기 초기화
            txt_oprnd.Text = result.ToString();
            currentInput = result.ToString();
            firstOperand = result;
            secondOperand = 0;
            currentOperator = string.Empty;
            expressionText = result.ToString();
            justCalculated = true;
        }

        private void btn_C_Click(object? sender, EventArgs e)
        {
            ResetCalculator();
        }

        private void btn_CE_Click(object? sender, EventArgs e)
        {
            if (justCalculated && string.IsNullOrEmpty(currentOperator))
            {
                ResetCalculator();
                return;
            }

            currentInput = string.Empty;
            secondOperand = 0;
            txt_oprnd.Text = "0";
            

            if (!string.IsNullOrEmpty(currentOperator))
            {
                txt_show.Text = expressionText;
                return;
                
            }

            expressionText = string.Empty;
            txt_show.Text = string.Empty;
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
            txt_oprnd.Text = string.IsNullOrEmpty(currentInput) ? "0" : currentInput;//현재 입력이 없으면 0으로 표시, 그렇지 않으면 현재 입력 표시

            if (!string.IsNullOrEmpty(currentOperator))
            {
                txt_show.Text = string.IsNullOrEmpty(currentInput)
                    ? expressionText//현재 입력이 없으면 연산식만 표시, 그렇지 않으면 연산식과 현재 입력 함께 표시
                    : $"{expressionText} {currentInput}";
                return;
            }

            txt_show.Text = currentInput;
        }

        private void ResetCalculator() //초기화 통합
        {
            firstOperand = 0;
            secondOperand = 0;
            result = 0;
            currentInput = string.Empty;
            currentOperator = string.Empty;
            expressionText = string.Empty;
            justCalculated = false;
            txt_show.Text = string.Empty;
            txt_oprnd.Text = "0";
        }

        private bool TryCalculateResult(out int calculatedResult) //연산자 통합
        {
            if (currentOperator == "÷" && secondOperand == 0)
            {
                MessageBox.Show("0으로 나눌 수 없습니다.", "계산 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_show.Text = expressionText;
                txt_oprnd.Text = "0";
                currentInput = string.Empty;
                calculatedResult = 0;
                return false;
            }

            calculatedResult = currentOperator switch
            {
                "+" => firstOperand + secondOperand,
                "-" => firstOperand - secondOperand,
                "X" => firstOperand * secondOperand,
                "÷" => firstOperand / secondOperand,
                _ => 0
            };

            return true;
        }
    }
}
