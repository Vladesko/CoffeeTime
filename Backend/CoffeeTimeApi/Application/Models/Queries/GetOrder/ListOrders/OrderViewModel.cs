using Application.Interfaces;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Queries.GetOrder.ListOrders
{
    public class OrderViewModel : IMapWith<Order>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Person { get; set; } = string.Empty;
        public Status Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderViewModel>().
                ForMember(vm => vm.Name, opt => opt.MapFrom(ins => ins.Name)).
                ForMember(vm => vm.Id, opt => opt.MapFrom(ins => ins.Id)).
                ForMember(vm => vm.Person, opt => opt.MapFrom(ins => ins.Person)).
                ForMember(vm => vm.Status, opt => opt.MapFrom(ins => ins.Status));
        }
    }
}
