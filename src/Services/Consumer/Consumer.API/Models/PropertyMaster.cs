using System.ComponentModel.DataAnnotations;

namespace Consumer.API.Models;

public class PropertyMaster{
    [Key]
    public Guid PropertyType{get;set;}
}