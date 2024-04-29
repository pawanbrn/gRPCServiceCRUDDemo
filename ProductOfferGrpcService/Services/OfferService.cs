using AutoMapper;
using Grpc.Core;
using ProductOfferGrpcService.Entities;
using ProductOfferGrpcService.Protos;
using ProductOfferGrpcService.Repositories;
using ProductOfferService = ProductOfferGrpcService.Protos.ProductOfferService;

namespace ProductOfferGrpcService.Services
{
    public class OfferService : ProductOfferService.ProductOfferServiceBase
    {
        private readonly IProductOfferService _prductOfferService;
        private readonly IMapper _mapper;

        public OfferService(IProductOfferService prductOfferService, IMapper mapper)
        {
            _prductOfferService = prductOfferService;
            _mapper = mapper;
        }

        public async override Task<Offers> GetOfferList(Empty request, ServerCallContext context)
        {
            var offersData = _prductOfferService.GetOfferList();

            Offers response = new Offers();
            foreach (Offer offer in offersData)
            {
                response.Items.Add(_mapper.Map<OfferDetail>(offer));
            }

            return response;
        }

        public async override Task<OfferDetail> GetOffer(GetOfferDetailRequest request, ServerCallContext context)
        {
            var offer = _prductOfferService.GetOfferByIdAsync(request.ProductId);
            var offerDetail = _mapper.Map<OfferDetail>(offer);
            return offerDetail;
        }

        public async override Task<OfferDetail> CreateOffer(CreateOfferDetailRequest request, ServerCallContext context)
        {
            var offer = _mapper.Map<Offer>(request.Offer);

            await _prductOfferService.AddOfferAsync(offer);

            var offerDetail = _mapper.Map<OfferDetail>(offer);
            return offerDetail;
        }

        public async override Task<OfferDetail> UpdateOffer(UpdateOfferDetailRequest request, ServerCallContext context)
        {
            var offer = _mapper.Map<Offer>(request.Offer);

             await _prductOfferService.UpdateOfferAsync(offer);

            var offerDetail = _mapper.Map<OfferDetail>(offer);
            return offerDetail;
        }

        public async override Task<DeleteOfferDetailResponse> DeleteOffer(DeleteOfferDetailRequest request, ServerCallContext context)
        {
            var isDeleted =  await _prductOfferService.DeleteOfferAsync(request.ProductId);
            var response = new DeleteOfferDetailResponse
            {
                IsDelete = isDeleted
            };

            return response;
        }
    }
}
