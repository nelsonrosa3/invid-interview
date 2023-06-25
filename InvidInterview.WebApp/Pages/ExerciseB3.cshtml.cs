using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InvidInterview.WebApp.Pages;

public class ExerciseB3 : PageModel
{
    public string ResponseMessage { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
    [FromQuery] public string Input { get; set; } = string.Empty;
    
    public void OnGet()
    {
        if (string.IsNullOrWhiteSpace(Input))
        {
            ErrorMessage = "Please, enter a valid number list.";
            return;
        }

        Input = Input.Replace(" ", "");

        var numberList = Input.Split(',');

        var numbers = new List<int>();
        foreach (var s in numberList)
        {
            if (!int.TryParse(s, out var n))
            {
                ErrorMessage = $"{s} is not a valid integer.";
                return;
            }
            
            numbers.Add(n);
        }

        ResponseMessage = HasDuplicates(numbers) ? "YES" : "NO";
    }

    static bool HasDuplicates(List<int> numbers)
    {
        var set = new HashSet<int>();

        foreach (var item in numbers)
        {
            if (!set.Add(item))
            {
                return true;
            }
        }

        return false;
    }
}