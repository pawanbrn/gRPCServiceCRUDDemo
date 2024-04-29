using AutoMapper;
using ProductOfferGrpcService.Entities;
using ProductOfferGrpcService.Protos;

namespace ProductOfferGrpcService.AutoMapper
{
    public class OfferMapper : Profile
    {
        public OfferMapper()
        {
            CreateMap<Offer, OfferDetail>().ReverseMap();
        }
    }
}
