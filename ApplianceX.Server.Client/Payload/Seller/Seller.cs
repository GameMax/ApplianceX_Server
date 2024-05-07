namespace ApplianceX.Server.Client.Payload.Seller;

public class Seller
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public SellerStatistic SellerStatisticPayload { get; set; }
}