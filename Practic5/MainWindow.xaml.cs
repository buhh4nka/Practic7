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
        Pair _firstPair = new Pair();
        Pair _secondPair = new Pair();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ИСП-31. Назаров Д. Вариант 2. \nСоздать класс Pair (пара чисел). Создать необходимые методы и свойства. Определить методы метод сложения полей и операцию сложения пар(а, b) + (с, d)= (а + c, b + d).\nСоздать перегруженные методы для увеличения полей на 1, сложения трех пар чисел.", "О программе");
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void startSum_Click(object sender, RoutedEventArgs e)
        {
            bool isNotErrorInFirstPair1 = Int32.TryParse(firstPairFirstNumber.Text, out int firstNumberPair1);
            bool isNotErrorInSecondPair1 = Int32.TryParse(firstPairSecondNumber.Text, out int secondNumberPair1);
            bool isNotErrorInFirstPair2 = Int32.TryParse(secondPairFirstNumber.Text, out int firstNumberPair2);
            bool isNotErrorInSecondPair2 = Int32.TryParse(secondPairSecondNumber.Text, out int secondNumberPair2);
            if (isNotErrorInFirstPair1 && isNotErrorInFirstPair2 && isNotErrorInSecondPair1 && isNotErrorInSecondPair2)
            {
                _firstPair.First = firstNumberPair1;
                _firstPair.Second = secondNumberPair1;
                _secondPair.First = firstNumberPair2;
                _secondPair.Second = secondNumberPair2;
                Pair endPair = new Pair();
                endPair = _firstPair + _secondPair;
                endSum.Text = $"{endPair.First}, {endPair.Second}";
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
                Money endMoney = new Money(number);
                if (endMoney.Second < 10) endSum.Text = $"{endMoney.First}, 0{endMoney.Second}";
                else endSum.Text = $"{endMoney.First}, {endMoney.Second}";



            }
            else
            {
                MessageBox.Show("Введены некоректные значения, введите другие", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                numberToAdd.Clear();
            }
        }


    }
}
