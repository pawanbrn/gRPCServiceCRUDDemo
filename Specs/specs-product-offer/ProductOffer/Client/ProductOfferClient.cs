using Grpc.Net.Client;
using specs_product_offer.Grpc;
using specs_product_offer.ProductOffer.Client.Types;
using Contract = ProductOfferGrpcService.Protos;

namespace specs_product_offer.ProductOffer.Client
{
    internal class ProductOfferClient
    {
        private readonly Contract.ProductOfferService.ProductOfferServiceClient _productOfferServiceClient;

        public ProductOfferClient()
        {
            var channel = GrpcChannel.ForAddress("http://localhost:5263");
            _productOfferServiceClient = new Contract.ProductOfferService.ProductOfferServiceClient(channel);
        }

        public async Task<GrpcResponse<OfferDetail>> CreateOfferAsync(CreateOfferDetailRequest createOfferDetailRequest)
        {
            var request = createOfferDetailRequest.MapToContractType();
            var response = await _productOfferServiceClient.CreateOfferAsync(request);
            return response.MapToSpecsType();
        }

        public async Task<GrpcResponse<OfferDetail>> GetOfferByIdAsync(GetOfferDetailRequest getOfferDetailRequest)
        {
            var request = getOfferDetailRequest.MapToContractType();
            var response = await _productOfferServiceClient.GetOfferAsync(request);
            return response.MapToSpecsType();
        }

        public async Task<GrpcResponse<Offers>> GetOfferListAsync()
        {
            var response = await _productOfferServiceClient.GetOfferListAsync(new Contract.Empty());
            return response.MapToSpecsType();
        }
    }
}
