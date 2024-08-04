namespace Opcion1SaletGutierrez.src.Interfaces;

public interface IReportGenerator
{
    void GenerateBorrowedBooksReport(string filePath);

    void GenerateOverdueBooksReport(string filePath);

    void GenerateUserLoanHistoryReport(int memberNumber, string filePath);
}
