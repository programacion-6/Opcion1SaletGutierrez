namespace Opcion1SaletGutierrez.src.Interfaces;

public interface IValidatorManager<T>
{
    bool ValidateNullOrEmpty(string value);

    bool ValidateInputLength(string value, int minCharactersLength, int maxCharactersLength);
}
