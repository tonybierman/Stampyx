using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatermarkerCore
{
    public class ProcessConfig
    {
        string m_pathSrc = string.Empty;
        string m_pathDest = string.Empty;
        string m_prefix = string.Empty;
        string m_body = string.Empty;
        bool m_isMaint = true;

        public string PathSrc { get => m_pathSrc; set => m_pathSrc = value; }
        public string PathDest { get => m_pathDest; set => m_pathDest = value; }
        public string Prefix { get => m_prefix; set => m_prefix = value; }
        public string Body { get => m_body; set => m_body = value; }
        public bool IsMaint { get => m_isMaint; set => m_isMaint = value; }
    }
}
