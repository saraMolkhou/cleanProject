using AutoMapper;
using clean.core.DTOs;
using clean.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.core
{
    public class Mapping: Profile
    {
        public Mapping()
        {
            CreateMap<order, orderDTO>().ReverseMap();
            CreateMap<customer, customerDTO>().ReverseMap();
        }
    }
}
