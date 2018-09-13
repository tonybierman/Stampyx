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

        public static void DehydrateTo<T>(T config, string fname)
        {
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                FileStream fsout = new FileStream(fname, FileMode.Create, FileAccess.Write, FileShare.None);
                using (fsout)
                {
                    bf.Serialize(fsout, config);
                }
            }
            catch
            {

            }
        }

        public static T HydrateFrom<T>(string fname) where T : new()
        {
            T retval = default(T);
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                FileStream fsin = new FileStream(fname, FileMode.Open, FileAccess.Read, FileShare.None);
                using (fsin)
                {
                    retval = (T)bf.Deserialize(fsin);
                }
            }
            catch
            {
            }

            return retval == null ? new T() : retval;
        }
    }
}
