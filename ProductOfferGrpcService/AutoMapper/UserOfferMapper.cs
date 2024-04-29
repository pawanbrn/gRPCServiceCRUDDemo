using AutoMapper;
using ProductOfferGrpcService.Entities;
using ProductOfferGrpcService.Protos;

namespace ProductOfferGrpcService.AutoMapper
{
    public class UserOfferMapper : Profile
    {
        public UserOfferMapper()
        {
            CreateMap<Offer, UserOfferDetail>().ReverseMap();
        }
    }
}
