using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consumer.API.Models;
public enum BusinessType
{
    RealEstate,
    DepartmentalStore,
    Service,
    Manufacturing,
    CoachingInstitute,
    ShowRoom
}
public class Business
{
    [Key]
    public Guid BusinessID { get; set; }
    public Guid CustomerID { get; set; }
    public string BusinessName { get; set; }
    public Customer Customer { get; set; }
    public BusinessType BusinessType { get; set; }
    // public Guid BusinessTypeID { get; set; }
    // [ForeignKey("BusinessTypeID")]
    // public virtual BusinessMaster BusinessMaster { get; set; }
    public int TotalEmployees { get; set; }
    public int AnnualTurnover { get; set; }
    public int BusinessValue { get; set; }
}