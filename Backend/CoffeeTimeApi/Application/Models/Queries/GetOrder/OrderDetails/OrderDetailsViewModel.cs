using Application.Interfaces;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Queries.GetOrder.GetOrder
{
    public class OrderDetailsViewModel : IMapWith<Order>
    {
        public string Name { get; set; } = string.Empty;
        public string Person { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Phone { get; set; } = string.Empty;
        public DateTime Create { get; set; }
        public DateTime? Update { get; set; }
        public Status Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderDetailsViewModel>().
                ForMember(vm => vm.Name, opt => opt.MapFrom(ins => ins.Name)).
                ForMember(vm => vm.Price, opt => opt.MapFrom(ins => ins.Price)).
                ForMember(vm => vm.Status, opt => opt.MapFrom(ins => ins.Status)).
                ForMember(vm => vm.Phone, opt => opt.MapFrom(ins => ins.Phone)).
                ForMember(vm => vm.Create, opt => opt.MapFrom(ins => ins.Create)).
                ForMember(vm => vm.Update, opt => opt.MapFrom(ins => ins.Update)).
                ForMember(vm => vm.Person, opt => opt.MapFrom(ins => ins.Person));
        }
    }
}
