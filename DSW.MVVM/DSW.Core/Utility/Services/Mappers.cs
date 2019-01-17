using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DSW.Core.Utility.Services
{
    public static class Mappers
    {
        public static y Map<x, y>(this x model)
            where x : class
            where y : class, new()
        {
            var data = new y();
            PropertyCopier<x, y>.Copy(model, data);
            return data;
        }

        public static y Map<x, y>(this x model, string destinationPrefix)
            where x : class
            where y : class, new()
        {
            var data = new y();
            PropertyCopier<x, y>.Copy(model, data, destinationPrefix);
            return data;
        }

        public static y Map<x, y>(this x model, string destinationPrefix, y data)
            where x : class
            where y : class, new()
        {
            ;
            PropertyCopier<x, y>.Copy(model, data, destinationPrefix);
            return data;
        }

        public static y Map<x, y>(this x model, y data)
            where x : class
            where y : class, new()
        {
            PropertyCopier<x, y>.Copy(model, data);
            return data;
        }
    }
}
