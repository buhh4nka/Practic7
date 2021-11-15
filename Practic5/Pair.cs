using System;
using System.Collections.Generic;
using System.Text;

namespace Practic5
{
    class Pair
    {

        public Pair()
        {
            First = 0;
            Second = 0;
        }
        public Pair(int first, int second)
        {
            First = first;
            Second = second;
        }
        public int First { get; set; }
        public int Second { get; set; }
        public static Pair operator +(Pair firstPair, Pair secondPair)
        {
            Pair result = new Pair();
            result.First = firstPair.First + secondPair.First;
            result.Second = firstPair.Second + secondPair.Second;
            return result;
        }
        public static Pair operator +(Pair firstPair, int number)
        {
            Pair result = new Pair();
            result.First = firstPair.First + number;
            result.Second = firstPair.Second + number;
            return result;
        }

        public static Pair operator ++(Pair pair)
        {
            pair.First += 1;
            pair.Second += 1;
            return pair;
        }
        public static Pair operator --(Pair pair)
        {
            pair.First -= 1;
            pair.Second -= 1;
            return pair;
        }
    }
    class Money : Pair
    {
        public Money()
        {
            First = 0;
            Second = 0;
        }
        public Money(int ruble, int kopeck) : base(ruble, kopeck)
        {
        }
        public Money(double money)
        {
            First = (int)money;
            Second = Convert.ToInt32((money - (int)money) * 100);
        }
        public static Money operator +(Money firstNumber, Money secondNumber)
        {
            Money result = new Money();
            result.First = firstNumber.First + secondNumber.First;
            result.Second = firstNumber.Second + secondNumber.Second;
            while (result.Second >= 100)
            {
                result.Second -= 100;
                result.First += 1;
            }
            return result;
        }
        public Money Minus(ref Money money, int ruble, int kopeck)
        {
            money.First -= ruble;
            money.Second -= kopeck;
            while (money.Second < 0)
            {
                money.First -= 1;
                money.Second += 100;
            }
            return money;
        }

    }
}
