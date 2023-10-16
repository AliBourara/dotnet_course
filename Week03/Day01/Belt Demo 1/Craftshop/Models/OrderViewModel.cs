#pragma warning disable CS8618
namespace Craftshop.Models;

public class OrderView
{
    public Order NewOrder { get; set; }
    public int OwnerId { get; set; }
}