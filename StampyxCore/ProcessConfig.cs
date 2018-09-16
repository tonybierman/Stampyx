using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampyxCore
{
    /// <summary>
    /// Parameters for a watermaerked processing run
    /// </summary>
    [Serializable]
    public class ProcessConfig : ICloneable
    {
        string m_pathSrc = string.Empty;
        string m_pathDest = string.Empty;
        string m_prefix = string.Empty;
        bool m_isMaint = true;
        WatermarkCollection m_marks = new WatermarkCollection();

        /// <summary>
        /// The folder containing original images
        /// </summary>
        public string PathSrc { get => m_pathSrc; set => m_pathSrc = value; }

        /// <summary>
        /// The location to save watermarked copies
        /// </summary>
        public string PathDest { get => m_pathDest; set => m_pathDest = value; }

        /// <summary>
        /// The prefix to apply to a watermarked copy's file name
        /// </summary>
        public string Prefix { get => m_prefix; set => m_prefix = value; }

        /// <summary>
        /// Maintenance mode flag
        /// Only process files without a watermarked copy if true
        /// </summary>
        public bool IsMaint { get => m_isMaint; set => m_isMaint = value; }

        public WatermarkCollection Marks { get => m_marks; set => m_marks = value; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
