using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocializeService.Mappings.Configuration
{
    public class ProfilesConfiguration
    {
        public static IMapper MapProfiles()
        {
            // Auto Mapper Configurations            
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AllowNullCollections = true;

                // Agregar los nuevos profiles aqui.
               mc.AddProfile(new UserDTOMapping());
               mc.AddProfile(new EventDTOMapping());

            });

            return mappingConfig.CreateMapper();
        }
    }
}
