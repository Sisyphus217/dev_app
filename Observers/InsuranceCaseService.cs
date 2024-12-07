using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Observers;

public class InsuranceCaseService : ISubject
{
    private readonly List<IObserver> _observers = new();

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public async Task NotifyAsync(InsuranceCase insuranceCase)
    {
        foreach (var observer in _observers)
        {
            await observer.UpdateAsync(insuranceCase);
        }
    }

}