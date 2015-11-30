using nexIRC.Business.Enums;
namespace nexIRC.Business.Models.Command {
    /// <summary>
    /// Command
    /// </summary>
    public class Command {
        /// <summary>
        /// Data
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// Display
        /// </summary>
        public string Display { get; set; }
        /// <summary>
        /// Param 1
        /// </summary>
        public string Param1 { get; set; }
        /// <summary>
        /// Param 2
        /// </summary>
        public string Param2 { get; set; }
        /// <summary>
        /// Param 3
        /// </summary>
        public string Param3 { get; set; }
        /// <summary>
        /// Param 4
        /// </summary>
        public string Param4 { get; set; }
        /// <summary>
        /// Command Type
        /// </summary>
        public IrcCommandTypes CommandType { get; set; }
    }
}