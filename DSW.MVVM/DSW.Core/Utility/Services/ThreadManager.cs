using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DSW.Core.Utility.Services
{
    public class ThreadManager
    {
        static Dictionary<string, object> tlsSlots = new Dictionary<string, object>();

        public static void SetData(string lotName, object lotValue)
        {
            //setting
            tlsSlots.Add(lotName, lotValue);
        }

        public static object GetData(string lotName)
        {
            //getting
            object lds = AllocateNamedDataSlot(lotName);

            return lds;
        }

        public static void FreeNamedDataSlots(params string[] names)
        {
            foreach (var item in names)
            {
                tlsSlots.Remove(item);
            }

        }


        public static object AllocateNamedDataSlot(string name)
        {
            lock (tlsSlots)
            {
                object slot = null;
                if (tlsSlots.TryGetValue(name, out slot))
                    return slot;

                return slot;
            }
        }

        public static bool DoesNamedDataSlotsExist(string name)
        {
            lock (tlsSlots)
            {
                return tlsSlots.ContainsKey(name);
            }
        }
    }
}
