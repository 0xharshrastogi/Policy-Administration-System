using System.ComponentModel.DataAnnotations;

namespace Consumer.API.Models;

public class PropertyMaster
{
    [Key]
    public Guid PropertyTypeID { get; set; }

    public string PropertyName { get; set; }

    public DateTime ModifyDate { get; set; }

    public string ModifiedBy { get; set; }
}