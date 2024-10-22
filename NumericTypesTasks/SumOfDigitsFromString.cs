using System;

namespace NumericTypesTasks;

public static class SumOfDigitsFromString
{
    public static int SumOfDigitsFromStringMethod(string s){

        if (s.Length == 0 || string.IsNullOrWhiteSpace(s)){
            Console.WriteLine("The input string is empty");
            return 0;
        }
        int result = 0;
        for(int i=0; i < s.Length; i++){
            if (int.TryParse(s[i].ToString(), out int number)){
                result += number;
            }
        }  
        return result;
    }
}
