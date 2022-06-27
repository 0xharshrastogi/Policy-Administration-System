namespace Consumer.API.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Property
{
    [Key]
    public Guid PropertyID{get;set;}
    public Guid BusinessID{get;set;}
    public virtual Business Business{get;set;}
    public Guid PropertyTypeID{get;set;}
    
    [ForeignKey("PropertyTypeID")]
    public virtual PropertyMaster PropertyMaster{get;set;}

    public double Area{get;set;}

    public int BuildingStorey{get;set;}
    public int BuildingAge{get;set;}
    public int PropertyValue{get;set;}
}
