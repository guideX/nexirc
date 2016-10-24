using nexIRC.Data.Interfaces.Base;
using nexIRC.Models.NotifyList;
namespace nexIRC.Data.Interfaces {
    /// <summary>
    /// Notify List Repository
    /// </summary>
    public interface INotifyListRepository : IRepository<NotifyListModel> {
        /// <summary>
        /// Save Notify List
        /// </summary>
        void SaveNotifyList();
        /// <summary>
        /// Load
        /// </summary>
        void Load();
    }
}