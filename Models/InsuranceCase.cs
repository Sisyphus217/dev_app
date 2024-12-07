using System.Text.Json.Serialization;

namespace InsuranceManagementSystem.Models;

public class InsuranceCase
{
    
    [JsonIgnore]
    public int Id { get; set; }
    public CaseStatus Status { get; set; } = CaseStatus.New;
    public int PolicyId { get; set; }
    public InsurancePolicy Policy { get; set; } = null!;
}