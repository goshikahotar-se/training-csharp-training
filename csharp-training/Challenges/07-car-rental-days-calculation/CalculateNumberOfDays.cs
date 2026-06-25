namespace csharp.Challenges._07_car_rental_days_calculation;

public class CalculateNumberOfDays
{
    //Changing a method's return type to handle exception
    /*
    public static void Run()
    {
        // do the exercise with new type and then use cursor to check what was the alternatives that the interviewers were asking.
        CalculateDaysResult CalculateDaysDifference(DateTime firstInput, DateTime secondInput)
        {
            CalculateDaysResult result = new CalculateDaysResult();
            if (firstInput > secondInput)
            {
                TimeSpan daysDiff = firstInput.Date - secondInput.Date;
                result.IsSuccess = true;
                result.NumberOfDays = daysDiff.Days;
                
                return result;
            }

            result.IsSuccess = false;
            result.ErrorMessage = "Invalid input";
                
            return result;
        }

        CalculateDaysResult differenceInDays = CalculateDaysDifference(DateTime.Now, DateTime.Parse("June 17, 2026"));
        if (differenceInDays.IsSuccess)
        {
            Console.WriteLine(differenceInDays.NumberOfDays);
        }
        else
        {
            Console.WriteLine(differenceInDays.ErrorMessage);
        }
    }
    */

    //best way when a method cannot fulfill the promise of returning the expected type, it's simply to throw an exception
    //the caller of the function should then be using a try-catch
    public static void Run()
    {
        int CalculateDaysDifference(DateTime firstDate, DateTime secondDate)
        {
            if (firstDate > secondDate)
            {
                var result = firstDate - secondDate;
                return result.Days;
            }

            throw new ArgumentException("First date must be before second date");
        }

        //test_data_1
        //var daysAllocated = CalculateDaysDifference(DateTime.Now, DateTime.Parse("June 17, 2026"));
        
        //test_data_2
        try
        {
            var daysAllocated = CalculateDaysDifference(DateTime.Parse("June 17, 2026"), DateTime.Now);
            Console.WriteLine(daysAllocated);
        }
        catch (Exception e)
        {
            Console.WriteLine($"[User Error]: {e.Message}");
            Console.ResetColor();
        }
        
        /*
        var daysAllocated = CalculateDaysDifference(DateTime.Parse("June 17, 2026"), DateTime.Now);
        Console.WriteLine(daysAllocated);
        */
    }
}