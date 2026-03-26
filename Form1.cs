using System.Text;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        // 입력한 수식을 토큰 단위로 저장합니다.
        private readonly List<string> expressionTokens = new();
        private string currentInput = string.Empty;
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

            if (justCalculated)
            {
                ResetCalculator();
            }

            currentInput += button.Text;
            UpdateDisplays();
        }

        private void OperatorButton_Click(object? sender, EventArgs e)
        {
            if (sender is not Button button)
            {
                return;
            }

            if (!TryCommitCurrentInput())
            {
                return;
            }

            if (expressionTokens.Count == 0 || IsOperator(expressionTokens[^1]) || expressionTokens[^1] == "(")
            {
                return;
            }

            expressionTokens.Add(button.Text);
            justCalculated = false;
            UpdateDisplays();
        }

        private void btn_leftParen_Click(object? sender, EventArgs e)
        {
            if (justCalculated)
            {
                ResetCalculator();
            }

            if (!TryCommitCurrentInput())
            {
                return;
            }

            if (expressionTokens.Count > 0)
            {
                string lastToken = expressionTokens[^1];
                if (!IsOperator(lastToken) && lastToken != "(")
                {
                    return;
                }
            }

            expressionTokens.Add("(");
            UpdateDisplays();
        }

        private void btn_rightParen_Click(object? sender, EventArgs e)
        {
            if (!TryCommitCurrentInput())
            {
                return;
            }

            int leftParenCount = expressionTokens.Count(token => token == "(");
            int rightParenCount = expressionTokens.Count(token => token == ")");

            // 닫는 괄호가 더 많아지면 잘못된 입력입니다.
            if (leftParenCount <= rightParenCount)
            {
                return;
            }

            if (expressionTokens.Count == 0 || IsOperator(expressionTokens[^1]) || expressionTokens[^1] == "(")
            {
                return;
            }

            expressionTokens.Add(")");
            UpdateDisplays();
        }

        private void btn_equal_Click(object? sender, EventArgs e)
        {
            if (!TryCommitCurrentInput())
            {
                return;
            }

            if (expressionTokens.Count == 0)
            {
                return;
            }

            if (IsOperator(expressionTokens[^1]) || expressionTokens[^1] == "(")
            {
                return;
            }

            int leftParenCount = expressionTokens.Count(token => token == "(");
            int rightParenCount = expressionTokens.Count(token => token == ")");
            if (leftParenCount != rightParenCount)
            {
                MessageBox.Show("괄호 개수가 맞지 않습니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 현재 입력 중인 숫자까지 반영한 전체 수식을 계산합니다.
            if (!TryEvaluateExpression(out int result))
            {
                return;
            }

            string expression = BuildExpressionText();
            txt_show.Text = $"{expression} = {result}";
            txt_oprnd.Text = result.ToString();
            expressionTokens.Clear();
            currentInput = result.ToString();
            justCalculated = true;
        }

        private void btn_C_Click(object? sender, EventArgs e)
        {
            ResetCalculator();
        }

        private void btn_CE_Click(object? sender, EventArgs e)
        {
            if (justCalculated)
            {
                ResetCalculator();
                return;
            }

            if (!string.IsNullOrEmpty(currentInput))
            {
                currentInput = string.Empty;
                UpdateDisplays();
                return;
            }

            for (int i = expressionTokens.Count - 1; i >= 0; i--)
            {
                if (int.TryParse(expressionTokens[i], out _))
                {
                    expressionTokens.RemoveAt(i);
                    break;
                }
            }

            UpdateDisplays();
        }

        private void btn_del_Click(object? sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                currentInput = currentInput[..^1];
                UpdateDisplays();
                return;
            }

            if (expressionTokens.Count > 0)
            {
                expressionTokens.RemoveAt(expressionTokens.Count - 1);
                UpdateDisplays();
            }
        }

        // 입력 중인 숫자를 수식 목록에 확정합니다.
        private bool TryCommitCurrentInput()
        {
            if (string.IsNullOrEmpty(currentInput))
            {
                return true;
            }

            if (!int.TryParse(currentInput, out _))
            {
                return false;
            }

            expressionTokens.Add(currentInput);
            currentInput = string.Empty;
            return true;
        }

        private void UpdateDisplays()
        {
            txt_oprnd.Text = string.IsNullOrEmpty(currentInput) ? "0" : currentInput;

            // 위쪽 창에는 완성된 수식과 현재 입력값을 함께 보여줍니다.
            txt_show.Text = BuildExpressionText(currentInput);
        }

        // 토큰 목록을 화면에 보여줄 한 줄 문자열로 만듭니다.
        private string BuildExpressionText(string? trailingInput = null)
        {
            StringBuilder builder = new();

            for (int i = 0; i < expressionTokens.Count; i++)
            {
                string token = expressionTokens[i];

                if (builder.Length > 0 && token != ")" && expressionTokens[i - 1] != "(")
                {
                    builder.Append(' ');
                }

                if (token == ")" && builder.Length > 0 && builder[^1] == ' ')
                {
                    builder.Length--;
                }

                builder.Append(token);
            }

            if (!string.IsNullOrEmpty(trailingInput))
            {
                if (builder.Length > 0 && builder[^1] != '(')
                {
                    builder.Append(' ');
                }

                builder.Append(trailingInput);
            }

            return builder.ToString();
        }

        private bool TryEvaluateExpression(out int result)
        {
            result = 0;
            Stack<int> values = new();
            Stack<string> operators = new();

            // 스택을 이용해 괄호와 연산자 우선순위를 계산합니다.
            foreach (string token in expressionTokens)
            {
                if (int.TryParse(token, out int number))
                {
                    values.Push(number);
                    continue;
                }

                if (token == "(")
                {
                    operators.Push(token);
                    continue;
                }

                if (token == ")")
                {
                    while (operators.Count > 0 && operators.Peek() != "(")
                    {
                        if (!ApplyTopOperator(values, operators.Pop()))
                        {
                            return false;
                        }
                    }

                    if (operators.Count == 0 || operators.Pop() != "(")
                    {
                        MessageBox.Show("괄호 개수가 맞지 않습니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    continue;
                }

                while (operators.Count > 0 && operators.Peek() != "(" && Precedence(operators.Peek()) >= Precedence(token))
                {
                    if (!ApplyTopOperator(values, operators.Pop()))
                    {
                        return false;
                    }
                }

                operators.Push(token);
            }

            while (operators.Count > 0)
            {
                string op = operators.Pop();
                if (op == "(")
                {
                    MessageBox.Show("괄호 개수가 맞지 않습니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (!ApplyTopOperator(values, op))
                {
                    return false;
                }
            }

            if (values.Count != 1)
            {
                MessageBox.Show("수식이 올바르지 않습니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            result = values.Pop();
            return true;
        }

        // 가장 최근 연산자 하나를 두 피연산자에 적용합니다.
        private bool ApplyTopOperator(Stack<int> values, string op)
        {
            if (values.Count < 2)
            {
                MessageBox.Show("수식이 올바르지 않습니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            int right = values.Pop();
            int left = values.Pop();
            int calcResult;

            switch (op)
            {
                case "+":
                    calcResult = left + right;
                    break;
                case "-":
                    calcResult = left - right;
                    break;
                case "x":
                    calcResult = left * right;
                    break;
                case "÷":
                    if (right == 0)
                    {
                        MessageBox.Show("0으로 나눌 수 없습니다.", "계산 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    calcResult = left / right;
                    break;
                default:
                    return false;
            }

            values.Push(calcResult);
            return true;
        }

        private static bool IsOperator(string token)
        {
            return token is "+" or "-" or "x" or "÷";
        }

        private static int Precedence(string op)
        {
            return op is "x" or "÷" ? 2 : 1;
        }

        private void ResetCalculator()
        {
            expressionTokens.Clear();
            currentInput = string.Empty;
            justCalculated = false;
            txt_show.Text = string.Empty;
            txt_oprnd.Text = "0";
        }
    }
}
