namespace csharp.Challenges._01_missing_number;

public class MissingNumber
{
    //Problem: You are given an array containing all integers from 1 to N except for one missing number. Write a method to find and return the missing integer
    public static void Run()
    {
        static int MissingNumberInArray(int[] inputArray)
        {
            if (inputArray[0] != 1)
                return 1;

            for (int i = 1; i < inputArray.Length; i++)
            {
                if (inputArray[i] != (inputArray[i - 1] + 1))
                    return inputArray[i - 1] + 1;
            }

            return inputArray.Length + 1;
        }
        
        int[] input = [1, 2, 3, 4, 5];
        int result = MissingNumberInArray(input);
        Console.WriteLine(result);
    }
}