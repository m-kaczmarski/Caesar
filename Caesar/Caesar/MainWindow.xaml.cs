using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Caesar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LetterValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                e.Handled = true;
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[0-9]"))
            {
                e.Handled = true;
            }
        }

        private void Cipher(object sender, RoutedEventArgs e)
        {
            output.Text = "";
            int encryptionKey;
            bool res = Int32.TryParse(key.Text, out encryptionKey);

            if (res == true && encryptionKey > 0 && encryptionKey < 26)
            {
                foreach (char c in input.Text)
                {
                    char letter = c;
                    if (char.IsLetter(c))
                    {
                        int num = (int)c;
                        letter = (char)(c + encryptionKey);
                        if (char.IsUpper(c))
                        {
                            if (letter > 'Z')
                            {
                                letter = (char)(letter - 26);
                            }
                            else
                            {
                                if (letter < 'A')
                                {
                                    letter = (char)(letter + 26);
                                }
                            }
                        }
                        output.Text += letter;
                    }
                    else
                    {
                        output.Text += c;
                    }
                }
            }
            else
            {
                MessageBox.Show("Tylko wartosci 1-25");
                return;
            }
        }

        private void Decipher(object sender, RoutedEventArgs e)
        {
            output.Text = "";
            int encryptionKey;
            bool res = Int32.TryParse(key.Text, out encryptionKey);

            if (res == true && encryptionKey > 0 && encryptionKey < 26)
            {
                foreach (char c in input.Text)
                {
                    char letter = c;
                    if (char.IsLetter(c))
                    {
                        int num = (int)c;
                        letter = (char)(c - encryptionKey);
                        if (char.IsUpper(c))
                        {
                            if (letter > 'Z')
                            {
                                letter = (char)(letter - 26);
                            }
                            else
                            {
                                if (letter < 'A')
                                {
                                    letter = (char)(letter + 26);
                                }
                            }
                        }
                        output.Text += letter;
                    }
                    else
                    {
                        output.Text += c;
                    }
                }
            }
            else
            {
                MessageBox.Show("Tylko wartosci 1-25");
                return;
            }
        }
    }
}
