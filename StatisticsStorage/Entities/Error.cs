using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsStorage.Entities
{
    /// <summary>
    /// Error in product.
    /// </summary>
    public class Error
    {
        #region Properties: public
        public DateTimeOffset Timestamp {  get; set; }
        public string Severity {  get; set; }
        public string Product {  get; set; }
        public int Version { get; set; }
        public int ErrorCode {  get; set; }

        #endregion
        #region Fields: Private
        private static string[] SeverityVariants = { "Critical", "High", "Normal", "Low" };
        private static string[] ProductVariants = { "Mobile", "CRM", "Helper", "TaskManager" };
        #endregion

        #region Methods: Public

        /// <summary>
        /// Generate error object.
        /// </summary>
        /// <param name="random"></param>
        /// <returns>Error object</returns>
        public static Error GenerateError(Random random)
        {
            return new Error
            {
                Timestamp = DateTimeOffset.UtcNow.Date.AddMinutes(random.Next(0, 1440)),
                Severity = SeverityVariants[random.Next(SeverityVariants.Length)],
                Product = ProductVariants[random.Next(ProductVariants.Length)],
                Version = random.Next(1, 21),
                ErrorCode = random.Next(1, 101)
            };
        }

        /// <summary>
        /// Convert error to string.
        /// </summary>
        /// <returns>Converted error</returns>
        public override string ToString()
        {
            return $"{this.Timestamp};{this.Severity};{this.Product};{this.Version};{this.ErrorCode}";
        }

        #endregion
    }
}
