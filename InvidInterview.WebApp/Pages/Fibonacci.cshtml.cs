using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InvidInterview.WebApp.Pages;

public class Fibonacci : PageModel
{
    [FromQuery] public string Length { get; set; } = string.Empty;
    public string ResponseMessage { get; set; } = string.Empty;

    public void OnGet()
    {
        try
        {
            if (string.IsNullOrWhiteSpace(Length))
            {
                ResponseMessage = "Length is empty, provide a valid length from 0 to 30.";
                return;
            }

            if (!int.TryParse(Length, out var length))
            {
                ResponseMessage = "Length must be a number, provide a valid length from 0 to 30.";
                return;
            }

            if (length < 0 || length > 30)
            {
                ResponseMessage = "provide a valid length from 0 to 30.";
                return;
            }

            var sequence = "";

            if (length == 0) length += 1;
        
            for (int i = 0; i < length; i++)
            {
                sequence += FibonacciCalculation(i);

                if (i != length - 1) sequence += ", ";
            }

            ResponseMessage = sequence;
        }
        catch (Exception e)
        {
            ResponseMessage = "Something went wrong. Try Again";
        }
    }

    public static int FibonacciCalculation(int length)
    {
        if (length == 0 || length == 1) return length;
        
        return FibonacciCalculation(length - 1) + FibonacciCalculation(length - 2);
    }
}