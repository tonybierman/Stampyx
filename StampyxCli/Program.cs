using StampyxCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StampyxCli
{
    class Program
    {
        static ProcessConfig m_config;
        static void Main(string[] args)
        {
            m_config = Hydrator.HydrateFrom<ProcessConfig>("josie_config.stx");
            ImageHelper.ProcessFilesInBackground(null, m_config);
        }
    }
}