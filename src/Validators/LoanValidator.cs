namespace Opcion1SaletGutierrez;

public class LoanValidator
{
    private const int MinMembershipNumberLength = 5;
    private const int MaxMembershipNumberLength = 10;

    public bool ValidateMembershipNumber(string input, out int membershipNumber)
    {
        membershipNumber = 0;

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("El número de membresía está vacío. Ingresa un número de membresía correcto.");
            return false;
        }

        if (!int.TryParse(input, out membershipNumber))
        {
            Console.WriteLine("El número de membresía no es válido. Ingresa un número como el ejemplo proporcionado.");
            return false;
        }

        if (input.Length < MinMembershipNumberLength || input.Length > MaxMembershipNumberLength)
        {
            Console.WriteLine($"El número de membresía debe tener entre {MinMembershipNumberLength} y {MaxMembershipNumberLength} dígitos.");
            return false;
        }
        return true;
    }
}
