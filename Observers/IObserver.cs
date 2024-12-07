using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Observers;

public interface IObserver
{
    Task UpdateAsync(InsuranceCase insuranceCase);
}