using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Observers;

public class LoggingService : IObserver
{
    public Task UpdateAsync(InsuranceCase insuranceCase)
    {
        Console.WriteLine($"[LOG] Страховой случай с ID {insuranceCase.Id} изменил статус на {insuranceCase.Status}.");
        return Task.CompletedTask;
    }
}