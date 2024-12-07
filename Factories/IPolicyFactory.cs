using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Factories;

public interface IPolicyFactory
{
    InsurancePolicy CreatePolicy(string policyType, string policyHolderName);
}