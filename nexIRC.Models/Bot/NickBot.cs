using nexIRC.Models.Base;
namespace nexIRC.Models.Bot {
    /// <summary>
    /// Nick Bot
    /// </summary>
    public class NickBotModel : AllBotModel {
        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="statusIndex"></param>
        public NickBotModel(int statusIndex) {
            StatusIndex = statusIndex;
        }
    }
}