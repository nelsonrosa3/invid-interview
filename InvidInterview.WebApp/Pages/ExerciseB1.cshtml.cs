using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InvidInterview.WebApp.Pages;

public class ExerciseB1 : PageModel
{
    public string ResponseMessage { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
    [FromQuery] public string Input { get; set; } = string.Empty;

    public void OnGet()
    {
        if (string.IsNullOrWhiteSpace(Input))
        {
            ErrorMessage = "Please, enter a valid number.";
            return;
        }

        Input = Input.Replace(" ", "");

        if (!int.TryParse(Input, out var number))
        {
            ErrorMessage = $"{Input} is not a valid integer.";
            return;
        }

        if (number < 1 || number > 100)
        {
            ErrorMessage = $"{Input} must be between 1 and 100";
            return;
        }

        ResponseMessage = ThreeFifteenMultiplierReplacer(number);
    }

    public string ThreeFifteenMultiplierReplacer(int number)
    {
        var result = "";

        for (int i = 1; i <= number; i++)
        {
            if (i % 15 == 0)
            {
                result += "F";
                continue;
            }

            if (i % 3 == 0)
            {
                result += "T";
                continue;
            }
            
            result += i.ToString();
        }

        return result;
    }
}