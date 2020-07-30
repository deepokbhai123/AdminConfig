using AT.Data.Entity;
using AT.Service.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AT.Service.MapperClass
{
    public class AutoOrCustomMapper:Profile
    {
        public AutoOrCustomMapper()
        {

            CreateMap<ATMenu, MenuVM>();//for all automaper

            CreateMap<ATMenu, MenuVM>().ConstructUsing(d=>new MenuVM{
               
                Id=5 //custom value
            });
        }
    }
}
