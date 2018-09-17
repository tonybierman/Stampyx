using StampyxCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
            string fname = args[0];
            if (string.IsNullOrEmpty(fname))
                System.Environment.Exit(1);

            if(!File.Exists(fname))
                System.Environment.Exit(1);

            m_config = Hydrator.HydrateFrom<ProcessConfig>(fname);
            ImageHelper.ProcessFilesInBackground(null, m_config);
        }
    }
}