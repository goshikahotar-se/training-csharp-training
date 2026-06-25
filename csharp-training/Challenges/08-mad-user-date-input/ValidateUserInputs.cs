namespace csharp.Challenges._08_mad_user_date_input;

public class ValidateUserInputs
{
    public static void Run()
    {
        while (true)
        {
            Console.WriteLine("Your inputs: ");
            try
            {
                int difference = CalculateDaysDifference();
                Console.WriteLine(difference);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Date order error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            
            Console.WriteLine("Press 'exit' to close the application.");
            string exitInput = Console.ReadLine();
        
            if (exitInput == "exit")
                break;
        }
    }

    private static int CalculateDaysDifference()
    {
        DateTime startDate, endDate;
        
        while (true)
        {
            try
            {
                Console.WriteLine("Enter start date: ");
                string startDateInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(startDateInput))
                {
                    startDate = DateTime.Parse(startDateInput);
                    Console.WriteLine(startDate);
                    break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid start date");
            }
        }
        
        while (true)
        {
            try
            {
                Console.WriteLine("Enter end date: ");
                string endDateInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(endDateInput))
                {
                    endDate = DateTime.Parse(endDateInput);
                    Console.WriteLine(endDate);
                    break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid end date");
            }
        }
        
        TimeSpan numberOfDaysDifference = endDate.Date - startDate.Date;

        if (numberOfDaysDifference.Days == 0)
            return 1;
        
        if(numberOfDaysDifference.Days < 0)
            throw new ArgumentException("The number of days difference must be greater than or equal to zero");
        
        return numberOfDaysDifference.Days;
    }
}