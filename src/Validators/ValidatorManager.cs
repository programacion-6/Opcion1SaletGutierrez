using Opcion1SaletGutierrez.src.Interfaces;

namespace Opcion1SaletGutierrez.src.Validators;

public class ValidatorManager<T> : IValidatorManager<T>
{
    public bool ValidateInputLength(string value, int minCharactersLength, int maxCharactersLength)
    {
        return value.Length >= minCharactersLength && value.Length <= maxCharactersLength; ;
    }

    public bool ValidateNullOrEmpty(string value)
    {
        return !string.IsNullOrEmpty(value);
    }
}
