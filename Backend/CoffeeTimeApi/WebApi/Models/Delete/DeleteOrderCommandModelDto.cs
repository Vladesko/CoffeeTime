using Application.Interfaces;
using Application.Models.Delete;
using AutoMapper;

namespace WebApi.Models.Delete
{
    public class DeleteOrderCommandModelDto : IMapWith<DeleteOrderModel>
    {
        public Guid Id { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<DeleteOrderCommandModelDto, DeleteOrderModel>()
                .ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.Id));
        }
    }
}
