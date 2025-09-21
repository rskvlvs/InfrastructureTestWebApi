using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsStorage.Entities
{
    /// <summary>
    /// File paths for analyze.
    /// </summary>
    public class FilePathsOptions
    {
        public string GeneratedErrors { get; set; }
        public string ErrorsAmountBySeverity { get; set; }
        public string ErrorsAmountByProductAndVersion { get; set; }
        public string TopTenErrors { get; set; }
    }
}
