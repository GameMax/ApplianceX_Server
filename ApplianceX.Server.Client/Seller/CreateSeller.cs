using System.ComponentModel.DataAnnotations;

namespace ApplianceX.Server.Client.Seller;

public class CreateSeller
{
    [Required]
    public string Name { get; set; }

    public class Response
    {
        public Payload.Seller.Seller SellerPayload { get; set; }

        public Response(Payload.Seller.Seller sellerPayload)
        {
            SellerPayload = sellerPayload;
        }
    }
}