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

namespace Practic5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        Money _firstMoney = new Money();
        Money _secondMoney = new Money();
        Money _endMoney = new Money();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ИСП-31. Назаров Д. Вариант 2. \nИспользовать класс Pair (пара чисел). Определить класс-наследник Money с полями: рубли и копейки. Переопределить операцию сложения и определить методы вычитания и деления денежных сумм.", "О программе");
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void startSum_Click(object sender, RoutedEventArgs e)
        {
            bool isNotErrorInFirstPair1 = Int32.TryParse(firstPairFirstNumber.Text, out int firstMoneyRuble);
            bool isNotErrorInSecondPair1 = Int32.TryParse(firstPairSecondNumber.Text, out int firstMoneyKopeck);
            bool isNotErrorInFirstPair2 = Int32.TryParse(secondPairFirstNumber.Text, out int secondMoneyRuble);
            bool isNotErrorInSecondPair2 = Int32.TryParse(secondPairSecondNumber.Text, out int secondMoneyKopeck);
            if (isNotErrorInFirstPair1 && isNotErrorInFirstPair2 && isNotErrorInSecondPair1 && isNotErrorInSecondPair2)
            {
                _firstMoney.First = firstMoneyRuble;
                _firstMoney.Second = firstMoneyKopeck;
                _secondMoney.First = secondMoneyRuble;
                _secondMoney.Second = secondMoneyKopeck;
                _endMoney = _firstMoney + _secondMoney;
                if(_endMoney.Second > 9) endSum.Text = $"{_endMoney.First},{_endMoney.Second}";
                else endSum.Text = $"{_endMoney.First},0{_endMoney.Second}";
            }
            else
            {
                MessageBox.Show("Введены некоректные значения, введите другие", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                firstPairFirstNumber.Clear();
                firstPairSecondNumber.Clear();
                secondPairFirstNumber.Clear();
                secondPairSecondNumber.Clear();
                endSum.Clear();
            }
        }

        private void addNumber_Click(object sender, RoutedEventArgs e)
        {
            bool isNotErrorInNumber = double.TryParse(numberToAdd.Text, out double number);
            if (isNotErrorInNumber)
            {
                Money addMoney;
                if (number >= 0)
                {
                    addMoney = new Money(number);
                    _endMoney = _endMoney + addMoney;
                    if (_endMoney.Second < 10) endSum.Text = $"{_endMoney.First},0{_endMoney.Second}";
                    else endSum.Text = $"{_endMoney.First},{_endMoney.Second}";
                }
                else
                {
                    addMoney = new Money(Math.Abs(number));
                    _endMoney.Minus(ref _endMoney, addMoney.First, addMoney.Second);
                    if (_endMoney.Second < 10) endSum.Text = $"{_endMoney.First},0{_endMoney.Second}";
                    else endSum.Text = $"{_endMoney.First},{_endMoney.Second}";
                }
            }
            else
            {
                MessageBox.Show("Введены некоректные значения, введите другие", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                numberToAdd.Clear();
            }
        }

        private void divisionNumber_Click(object sender, RoutedEventArgs e)
        {
            bool isNotErrorInNumber = double.TryParse(numberToAdd.Text, out double number);
            if (isNotErrorInNumber)
            {
                _endMoney.Division(ref _endMoney, number);
                if (_endMoney.Second < 10) endSum.Text = $"{_endMoney.First},0{_endMoney.Second}";
                else endSum.Text = $"{_endMoney.First},{_endMoney.Second}";
            }
            else
            {
                MessageBox.Show("Введены некоректные значения, введите другие", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                numberToAdd.Clear();
            }
        }

    }
}
