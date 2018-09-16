using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StampyxCore
{
    public class XmlHydrator
    {
        private XmlHydrator() { }

        public static void DehydrateTo<T>(T someObject, string fname)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (TextWriter writer = new StreamWriter(fname))
                    serializer.Serialize(writer, someObject);
            }
            catch
            {

            }
        }

        public static T HydrateFrom<T>(string fname) where T : new()
        {
            T retval = default(T);
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            try
            {
                FileStream fsin = new FileStream(fname, FileMode.Open, FileAccess.Read, FileShare.None);
                using (fsin)
                {
                    retval = (T)serializer.Deserialize(fsin);
                }
            }
            catch
            {
            }

            return retval == null ? new T() : retval;
        }
    }
}
