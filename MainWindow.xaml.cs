using System.Diagnostics.Eventing.Reader;
using System.IO.IsolatedStorage;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace X0
{

    public partial class MainWindow : Window
    {
        Random random = new Random();
        Button[] buttons;

        public MainWindow()
        {
            InitializeComponent();
            buttons = new Button[10] { _1, _2, _3, _4, _5, _6, _7, _8, _9, _10 };
        }

        private void _1_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (sender as Button);

            if (clickedButton.Content == null || clickedButton.Content.ToString() == "")
            {
                clickedButton.Content = "x";
                clickedButton.IsEnabled = false;

                if (!IsBoardFull() && !CheckForWinner())
                {
                    MakeRandomMove();
                }
            }
        }


        private bool CheckForWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (buttons[i * 3].Content == "x" && buttons[i * 3 + 1].Content == "x" && buttons[i * 3 + 2].Content == "x" ||
                    buttons[i].Content == "x" && buttons[i + 3].Content == "x" && buttons[i + 6].Content == "x")
                {
                    MessageBox.Show("Крестики выиграли!");
                    RestartGame();
                    return true;
                }
            }

            if (buttons[0].Content == "x" && buttons[4].Content == "x" && buttons[8].Content == "x" ||
                buttons[2].Content == "x" && buttons[4].Content == "x" && buttons[6].Content == "x")
            {
                MessageBox.Show("Крестики выиграли!");
                RestartGame();
                return true;
            }

            for (int i = 0; i < 3; i++)
            {
                if (buttons[i * 3].Content == "0" && buttons[i * 3 + 1].Content == "0" && buttons[i * 3 + 2].Content == "0" ||
                    buttons[i].Content == "0" && buttons[i + 3].Content == "0" && buttons[i + 6].Content == "0")
                {
                    MessageBox.Show("Нолики выиграли!");
                    RestartGame();
                    return true;
                }
            }

            if (buttons[0].Content == "0" && buttons[4].Content == "0" && buttons[8].Content == "0" ||
                buttons[2].Content == "0" && buttons[4].Content == "0" && buttons[6].Content == "0")
            {
                MessageBox.Show("Нолики выиграли!");
                RestartGame();
                return true;
            }

            return false;
        }

        private void MakeRandomMove()
        {
            int knopka = random.Next(0, 9);
            while (!buttons[knopka].IsEnabled)
                knopka = random.Next(0, 9);

            buttons[knopka].Content = "0";
            buttons[knopka].IsEnabled = false;

            if (CheckForWinner())
            {
            }
            else if (IsBoardFull())
            {
                MessageBox.Show("Ничья!");
                RestartGame();
            }
        }

        private bool IsBoardFull()
        {
            return buttons.All(button => button.Content != null && button.Content.ToString() != "");
        }

        private void RestartGame()
        {
            foreach (Button button in buttons)
            {
                button.Content = "";
                button.IsEnabled = true;
            }

            MakeRandomMove();
        }
        private void _10_Click(object sender, RoutedEventArgs e)
        {
            RestartGame();
        }
    }
}

