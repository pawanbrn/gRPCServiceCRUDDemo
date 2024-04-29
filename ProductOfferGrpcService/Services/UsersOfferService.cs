using AutoMapper;
using Grpc.Core;
using ProductOfferGrpcService.Protos;
using ProductOfferGrpcService.Repositories;
using ProductOfferService = ProductOfferGrpcService.Protos.UserOfferService;

namespace ProductOfferGrpcService.Services
{
    public class UsersOfferService : ProductOfferService.UserOfferServiceBase
    {
        private readonly IProductOfferService _prductOfferService;
        private readonly IMapper _mapper;

        public UsersOfferService(IProductOfferService prductOfferService, IMapper mapper)
        {
            _prductOfferService = prductOfferService;
            _mapper = mapper;
        }

        public async override Task<UserOffers> GetUserOfferList(EmptyRequestArg request, ServerCallContext context)
        {
            var offersData = _prductOfferService.GetOfferList();

            UserOffers response = new UserOffers();
            foreach (var offer in offersData)
            {
                response.Items.Add(_mapper.Map<UserOfferDetail>(offer));
            }

            return response;
        }
    }
}
