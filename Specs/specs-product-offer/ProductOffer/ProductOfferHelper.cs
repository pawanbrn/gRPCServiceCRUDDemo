using specs_product_offer.ProductOffer.Client;
using specs_product_offer.ProductOffer.Client.Types;

namespace specs_product_offer.ProductOffer
{
    internal class ProductOfferHelper(ProductOfferClient productOfferClient)
    {
        private ProductOfferClient _productOfferClient = productOfferClient;

        public async Task<OfferDetail> CreateOfferAsync(CreateOfferDetailRequest createOfferDetailRequest)
        {
            var response = await _productOfferClient.CreateOfferAsync(createOfferDetailRequest);
            response.ThrowIfFailed($"Could not create offer details with {createOfferDetailRequest.OfferDetail.Id}");
            return response.Data!;
        }

        public async Task<OfferDetail> GetOfferByIdAsync(GetOfferDetailRequest getOfferDetailRequest)
        {
            var response = await _productOfferClient.GetOfferByIdAsync(getOfferDetailRequest);
            response.ThrowIfFailed($"Could not retrieve offer by Id : {getOfferDetailRequest.ProductId}");
            return response.Data!;
        }

        public async Task<Offers> GetOfferListAsync()
        {
            var response = await _productOfferClient.GetOfferListAsync();
            response.ThrowIfFailed("Could not retrieve or list product offers");
            return response.Data!;
        }
    }
}
