using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using erp.fwk.VM;
using DataSource;
using AutoMapper;
namespace erp.fwk
{
    public class MapperManager : AutoMapper.Profile
    {

        public MapperManager()
        {
            CreateMap<Product, VMProduct>().ReverseMap();
        }

        public static void Run()
        {
            var config = new AutoMapper.MapperConfiguration(

              x =>
              {
                  x.AddProfile(new MapperManager());
              });
            var mapper = config.CreateMapper();
        }
    }


}
