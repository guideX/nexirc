using nexIRC.Enum;
using System.Collections.Generic;
namespace nexIRC.Models.String {
    /// <summary>
    /// Fixed String Model
    /// </summary>
    public class FixedStringModel {
        /// <summary>
        /// Data
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// Type
        /// </summary>
        public IrcNumeric Type { get; set; }
        /// <summary>
        /// Find
        /// </summary>
        public List<string> Find { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Support
        /// </summary>
        public string Support { get; set; }
        /// <summary>
        /// Syntax
        /// </summary>
        public string Syntax { get; set; }
        /// <summary>
        /// Entry Point
        /// </summary>
        public FixedStringModel() {
            Find = new List<string>();
        }
    }
}