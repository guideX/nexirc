using System.Collections.Generic;
namespace nexIRC.Business.Models.Dcc {
    /// <summary>
    /// Dcc Ignore Items Model
    /// </summary>
    public class DccIgnoreItemsModel {
        /// <summary>
        /// Count
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Items
        /// </summary>
        public List<DccIgnoreItemModel> Items { get; set; }
        /// <summary>
        /// Entry Point
        /// </summary>
        public DccIgnoreItemsModel() {
            Items = new List<DccIgnoreItemModel>(); // Initialise Items
        }
    }
}