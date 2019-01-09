using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DSW.Core.Utility.Services
{
    public class PropertyCopier<TParent, TChild>
        where TParent : class
        where TChild : class
    {
        public static void Copy(TParent parent, TChild child)
        {
            var parentProperties = parent.GetType().GetProperties();
            var childProperties = child.GetType().GetProperties();

            foreach (var parentProperty in parentProperties)
            {
                foreach (var childProperty in childProperties)
                {
                    if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType)
                    {
                        childProperty.SetValue(child, parentProperty.GetValue(parent,null),null);
                        break;
                    }
                }
            }
        }


        public static void Copy(TParent parent, TChild child, string destinationPrefix)
        {
            var parentProperties = parent.GetType().GetProperties();
            var childProperties = child.GetType().GetProperties();

            foreach (var parentProperty in parentProperties)
            {
                foreach (var childProperty in childProperties)
                {
                    if ((destinationPrefix +parentProperty.Name) ==  childProperty.Name 
                        && parentProperty.PropertyType == childProperty.PropertyType)
                    {
                        childProperty.SetValue(child, parentProperty.GetValue(parent, null), null);
                        break;
                    }
                }
            }
        }
    }
}
