using System;
using System.Windows.Forms;

namespace PercentCalculator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            cmbMode.Items.AddRange(new string[]
            {
                "От числа",
                "На сколько % изменилось",
                "Наценка/скидка"
            });
            cmbMode.SelectedIndex = 0;
            txtBase.TextChanged += Recalculate;
            txtPercent.TextChanged += Recalculate;
            cmbMode.SelectedIndexChanged += Recalculate;
        }

        private void Recalculate(object sender, EventArgs e)
        {
            double baseValue = 0;
            double percent = 0;
            if (!double.TryParse(txtBase.Text, out baseValue))
            {
                lblResult.Text = "Введите корректное число";
                return;
            }
            if (!double.TryParse(txtPercent.Text, out percent))
            {
                lblResult.Text = "Введите корректный процент";
                return;
            }

            double result = 0;
            switch (cmbMode.SelectedItem.ToString())
            {
                case "От числа":
                    result = baseValue * (percent / 100);
                    lblResult.Text = $"Процент от числа: {result:F2}";
                    break;

                case "На сколько % изменилось":
                    result = baseValue + (baseValue * (percent / 100));
                    lblResult.Text = $"Результат: {result:F2}";
                    break;

                case "Наценка/скидка":
                    result = baseValue + (baseValue * (percent / 100));
                    lblResult.Text = $"Итоговая цена: {result:F2}";
                    break;

                default:
                    lblResult.Text = "Выберите режим";
                    break;
            }
        }
    }
}