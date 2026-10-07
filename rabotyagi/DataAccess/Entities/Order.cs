using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using rabotyagi.DataAccess.Enums;

namespace rabotyagi.DataAccess.Entities;

public class Order : BaseEntity
{
    [InverseProperty(nameof(User.InitiatedOrders))]
    [DeleteBehavior((DeleteBehavior.Cascade))]
    public User Initiator { get; set; } = null!;
    
    [InverseProperty(nameof(User.ExecutedOrders))]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public User? Executor { get; set; }
    
    public EOrderType OrderType { get; set; }
    public string Comment { get; set; }
    
    public Guid AddressId { get; set; }
    [ForeignKey(nameof(AddressId))]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public Address Address { get; set; } = null!;
}