using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Observers;

public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    Task NotifyAsync(InsuranceCase insuranceCase);
}