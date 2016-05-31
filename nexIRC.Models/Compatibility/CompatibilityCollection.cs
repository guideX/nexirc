using System.Collections.Generic;
namespace nexIRC.Models.Compatibility {
    /// <summary>
    /// Compatibility Collection
    /// </summary>
    public class CompatibilityCollection {
        /// <summary>
        /// Modified
        /// </summary>
        public bool Modified { get; set; }
        /// <summary>
        /// Compatibilities
        /// </summary>
        public List<CompatibilityModel> Compatibilities { get; set; }
        /// <summary>
        /// Compatibilities Collection
        /// </summary>
        public CompatibilityCollection() {
            Compatibilities = new List<CompatibilityModel>();

        }
    }
}