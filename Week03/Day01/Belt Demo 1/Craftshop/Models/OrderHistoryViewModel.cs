#pragma warning disable CS8618
namespace Craftshop.Models;

public class OrderHistoryView
{
    public List<Order> Sales { get; set; } = new List<Order>() ;
    public List<Order> Orders { get; set; } = new List<Order>() ;
}