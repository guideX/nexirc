using nexIRC.Enum;
namespace nexIRC.Models.Command {
    /// <summary>
    /// Command Model
    /// </summary>
    public class CommandModel {
        /// <summary>
        /// Data
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// Command Type
        /// </summary>
        public CommandTypes CommandType { get; set; }
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
    }
}