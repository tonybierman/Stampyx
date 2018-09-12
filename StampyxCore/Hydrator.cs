using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace StampyxCore
{
    public class Hydrator
    {
        private Hydrator() { }

        public static void DehydrateTo(WatermarkCollection objects, string fname)
        {
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                FileStream fsout = new FileStream(fname, FileMode.Create, FileAccess.Write, FileShare.None);
                using (fsout)
                {
                    bf.Serialize(fsout, objects);
                }
            }
            catch
            {
                
            }
        }

        public static WatermarkCollection HydrateFrom(string fname)
        {
            WatermarkCollection retval = null;
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                FileStream fsin = new FileStream(fname, FileMode.Open, FileAccess.Read, FileShare.None);
                using (fsin)
                {
                    retval = (WatermarkCollection)bf.Deserialize(fsin);
                }
            }
            catch
            {
            }

            return retval == null ? new WatermarkCollection() : retval;
        }
    }
}
