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

namespace Number_Conversion_System_WPF
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

        private void getResult_Click(object sender, RoutedEventArgs e)
        {
            string val = value.Text;
            string tp = type.Text;

            // check the type of the number
            if (val != "")
            {
                if (tp == "Decimal")
                {
                    // Decimal
                    long value1 = (long) Convert.ToInt64(val);
                    string binary = Convert.ToString(value1, 2);
                    string oct = Convert.ToString(value1, 8);
                    string hex = Convert.ToString(value1, 16).ToUpper();

                    decimalField.Visibility = Visibility.Collapsed;
                    binField.Text = "Binary: " + binary;
                    octalField.Text = "Octal: " + oct;
                    hexField.Text = "Hexadecimal: " + hex;

                    result.Visibility = Visibility.Visible;
                }
                else if (tp == "Binary")
                {
                    // Binary
                    string deci = new MainWindow().BinToDeci(value.Text);
                    long value1 = (long) Convert.ToInt16(deci);

                    // get other values...
                    string oct = Convert.ToString(value1, 8);
                    string hex = Convert.ToString(value1, 16);

                    // write them in the UI
                    binField.Visibility = Visibility.Collapsed;
                    hexField.Text = "Hexadecimal: " + hex.ToUpper();
                    octalField.Text = "Octal: " + oct;
                    decimalField.Text = "Decimal: " + deci;

                    result.Visibility = Visibility.Visible;
                }
                else if (tp == "Octal")
                {
                    // Octal
                    string dec = "";
                    string deci = "";
                    string bin = "";
                    string hex = "";
                    try
                    {
                        dec = Convert.ToInt64(Convert.ToString(Convert.ToInt64(value.Text, 8), 10)).ToString();

                        deci = dec;
                        long val1 = (long)Convert.ToInt16(deci);
                        bin = Convert.ToString(val1, 2);
                        hex = Convert.ToString(val1, 16);

                        octalField.Visibility = Visibility.Collapsed;

                        decimalField.Text = "Decimal value: " + deci;
                        binField.Text = "Binary value: " + bin;
                        hexField.Text = "Hexadecimal value: " + hex;

                        result.Visibility = Visibility.Visible;
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.Message + "\n\n, maybe you used values higher than 7 in octal base.");
                    }
                }
                else if (tp == "Hexadecimal")
                {
                    // Hex
                    string dec = "";
                    string deci = "";
                    string bin = "";
                    string oct = "";
                    try
                    {
                        dec = Convert.ToInt64(Convert.ToString(Convert.ToInt64(value.Text, 16), 10)).ToString();

                        deci = dec;
                        long val1 = (long)Convert.ToInt16(deci);
                        bin = Convert.ToString(val1, 2);
                        oct = Convert.ToString(val1, 8);

                        hexField.Visibility = Visibility.Collapsed;

                        decimalField.Text = "Decimal value: " + deci;
                        binField.Text = "Binary value: " + bin;
                        octalField.Text = "Octal value: " + oct;

                        result.Visibility = Visibility.Visible;
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.Message + "\n\n, maybe you used values higher than 15 in hexadecimal base.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Valid value is required. Try again!");
            }
        }

        public string BinToDeci(string value)
        {
            char[] characters = value.ToCharArray();
            int streak = (characters.Length - 1);
            double result1 = 0;

            for (int i = 0; i < characters.Length; i++)
            {
                int number = Convert.ToInt16(characters[i].ToString());
                result1 += number * (Math.Pow(2, streak));
                streak--;
            }
            return result1.ToString();
        }
    }
}
