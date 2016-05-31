using nexIRC.Enum;
namespace nexIRC.Models.Media {
    /// <summary>
    /// Playlist Model
    /// </summary>
    public class PlaylistModel {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Type
        /// </summary>
        public PlaylistType Type { get; set; }
    }
}