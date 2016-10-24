using nexIRC.Enum;
namespace nexIRC.Models.Bot {
    /// <summary>
    /// Bot Model
    /// </summary>
    public class BotModel {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Type
        /// </summary>
        public BotTypes Type { get; set; }
    }
}