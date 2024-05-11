using specs_product_offer.Grpc;
using Contract = ProductOfferGrpcService.Protos;

namespace specs_product_offer.ProductOffer.Client
{
    internal static class ProductOfferMappingExtension
    {
        public static Contract.CreateOfferDetailRequest MapToContractType(this Types.CreateOfferDetailRequest source)
        {
            return new Contract.CreateOfferDetailRequest { Offer = source.OfferDetail.MapToContractType() };
        }

        public static Contract.OfferDetail MapToContractType(this Types.OfferDetail source)
        {
            return new Contract.OfferDetail() 
            { 
                Id = source.Id, 
                ProductName = source.ProductName, 
                OfferDescription = source.OfferDescription 
            };
        }

        public static GrpcResponse<Types.Offers> MapToSpecsType(this Contract.Offers source)
        {
            var offerDetail = new Types.Offers(Items: source.Items.Select(x => x.MapToSpecsType().Data!));

            return new(offerDetail is not null ? offerDetail : null, null);
        }

        public static GrpcResponse<Types.OfferDetail> MapToSpecsType(this Contract.OfferDetail source)
        {
            return new(new Types.OfferDetail(
                Id: source.Id,
                ProductName: source.ProductName,
                OfferDescription: source.OfferDescription), null);
        }
    }
}
