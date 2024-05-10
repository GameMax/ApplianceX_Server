using ApplianceX.Server.Client.Payload.Seller;
using ApplianceX.Server.Database.Seller;
using ApplianceX.Server.Database.Seller.Statistic;

namespace ApplianceX.Server.Client.Codec;

public static class SellerCodec
{
    public static Payload.Seller.Seller EncodeSeller(SellerModel dbModel)
    {
        return new Payload.Seller.Seller
        {
            Id = dbModel.Id,
            
        };
    }
}