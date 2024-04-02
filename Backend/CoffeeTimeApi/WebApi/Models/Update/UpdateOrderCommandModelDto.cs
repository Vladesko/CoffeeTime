using Application.Interfaces;
using Application.Models.Update;
using AutoMapper;
using Domain;

namespace WebApi.Models.Update
{
    public class UpdateOrderCommandModelDto : IMapWith<UpdateOrderModel>
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateOrderCommandModelDto, UpdateOrderModel>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(model => model.Status, opt => opt.MapFrom(dto => dto.Status));
        }
    }
}
