﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CygnetHRD.Entity.DBModel;
using CygnetHRD.Entity.Entities;

namespace CygnetHRD.WebAPI
{
    public class AutoMapperProfile : Profile
    {
        
       public AutoMapperProfile()
        {
            CreateMap<Users, User>();
            CreateMap<User, Users>();
        }
            
    }
}

