using System;
using System.Collections.Generic;
using System.Linq;

public class Task1
{
    public static void Main(string[] args)
    {
        int[] arr1 = { 1, 2, 3, 4, 5, 5, 6, 7, 8, 12, 4 };
        PrintMultiplierNumbers(arr1);
        int[] arr2 = { 10, 22, 32, 43, 54, 55, 66, 77, 88, 125, 43456 };
        PrintMultiplierNumbers(arr2);
        int[] arr3 = { 4, 8, 12, 16, 20, 24 };
        PrintMultiplierNumbers(arr3);
        int[] arr4 = { 6, 12, 18, 24, 30 };
        PrintMultiplierNumbers(arr4);
        int[] arr5 = { 12, 24, 36, 48, 60 };
        PrintMultiplierNumbers(arr5);
        int[] arr6 = { 3, 5, 13, 15, 22 };
        PrintMultiplierNumbers(arr6);
        int[] arr7 = { -3, -4, -6, -12 };
        PrintMultiplierNumbers(arr6);

        PrintIfStringIsPalindrome("woow");
        PrintIfStringIsPalindrome("bool");
        PrintIfStringIsPalindrome("t!#e#!t");
        PrintIfStringIsPalindrome("rotator");
        PrintIfStringIsPalindrome("Wow");
    }

    private static void PrintMultiplierNumbers(int[] arr)
    {
        var numbersList = ReturnMultiplier(arr);
        foreach (var number in numbersList)
        {
            Console.WriteLine("The number is: " + number.ToString());
        }
        Console.WriteLine("----------------------------");
    }

    private static void PrintIfStringIsPalindrome(string testString)
    {
        var isPalindrome = IsStringPalindrome(testString);
        Console.WriteLine("The string: " + testString + " is Palindrome?: " + isPalindrome.ToString());
    }

    private static List<int> ReturnMultiplier(int[] arr)
    {
        List<int> numbers = new List<int>();
        foreach (int x in arr)
        {
            if ((x % 6) == 0)
            {
                numbers.Add(x);
                continue;
            }
            if ((x % 4) == 0)
            {
                numbers.Add(x);
            }
        }
        return numbers;
    }

    private static bool IsStringPalindrome(string testString)
    {
        return testString.SequenceEqual(testString.Reverse());
    }
}
    

