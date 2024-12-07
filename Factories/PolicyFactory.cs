using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Factories;

public class CreatePolicyFactory : IPolicyFactory
{
    public InsurancePolicy CreatePolicy(string type, string holderName)
    {
        return new InsurancePolicy
        {
            PolicyType = type,
            PolicyHolderName = holderName
        };
    }
}