using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InsuranceManagementSystem.Models;

public class InsurancePolicy
{
    
    [JsonIgnore]
    public int Id { get; set; }
    public string PolicyType { get; set; } = null!;
    public string PolicyHolderName { get; set; } = null!;
}