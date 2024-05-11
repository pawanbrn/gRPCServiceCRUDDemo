using FluentAssertions;
using specs_product_offer.ProductOffer;
using specs_product_offer.ProductOffer.Client;
using specs_product_offer.ProductOffer.Client.Types;

var productOfferClient = new ProductOfferClient();
var productOfferHelper = new ProductOfferHelper(productOfferClient);

// Create Offer
var createOfferDetailRequest = new CreateOfferDetailRequest(new OfferDetail(Id: 2, ProductName: "Mobile", OfferDescription: "Test Mobile1"));
var createOfferDetailsResponse = await productOfferHelper.CreateOfferAsync(createOfferDetailRequest);
createOfferDetailsResponse.Id.Should().Be(createOfferDetailRequest.OfferDetail.Id);
createOfferDetailsResponse.ProductName.Should().Be(createOfferDetailRequest.OfferDetail.ProductName);
createOfferDetailsResponse.OfferDescription.Should().Be(createOfferDetailRequest.OfferDetail.OfferDescription);

// Get Offer by Id
var getOfferDetailRequest = new GetOfferDetailRequest(ProductId: 2);
var offerDetails = await productOfferHelper.GetOfferByIdAsync(getOfferDetailRequest);
offerDetails.Id.Should().Be(getOfferDetailRequest.ProductId);

// Get all Offers
var offersList = await productOfferHelper.GetOfferListAsync();
offersList.Should().NotBeNull();

Console.ReadLine();