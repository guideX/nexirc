using System.Collections.Generic;
namespace nexIRC.Models.Media {
    /// <summary>
    /// Media File Collection
    /// </summary>
    public class MediaFileCollection {
        /// <summary>
        /// Files
        /// </summary>
        public List<MediaFileModel> Files { get; set; }
        /// <summary>
        /// Media File Collection
        /// </summary>
        public MediaFileCollection() {
            Files = new List<MediaFileModel>();
        }
    }
}