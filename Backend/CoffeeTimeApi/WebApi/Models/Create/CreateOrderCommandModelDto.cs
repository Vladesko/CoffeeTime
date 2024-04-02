using Application.Interfaces;
using Application.Models.Create;
using AutoMapper;

namespace WebApi.Models.Create
{
    public class CreateOrderCommandModelDto : IMapWith<CreateOrderModel>
    {
        public string Name { get; set; } = string.Empty;
        public string Person { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Phone { get; set; } = string.Empty;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrderCommandModelDto, CreateOrderModel>()
                .ForMember(model => model.Name, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(model => model.Price, opt => opt.MapFrom(dto => dto.Price))
                .ForMember(model => model.Person, opt => opt.MapFrom(dto => dto.Person))
                .ForMember(model => model.Phone, opt => opt.MapFrom(dto => dto.Phone));
        }

    }
}
