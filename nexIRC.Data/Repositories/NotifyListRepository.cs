using System.Collections.Generic;
using nexIRC.Data.Interfaces;
using nexIRC.Data.Repositories.Base;
using nexIRC.Models.NotifyList;
using TeamNexgenCore.Helpers;
namespace nexIRC.Data.Repositories {
    /// <summary>
    /// Notify List Repository
    /// </summary>
    public class NotifyListRepository : Repository<NotifyListModel>, INotifyListRepository {
        /// <summary>
        /// Notify List
        /// </summary>
        public List<NotifyListModel> NotifyList { get; set; }
        /// <summary>
        /// Notify List Repository
        /// </summary>
        /// <param name="ini"></param>
        public NotifyListRepository(string ini, bool load = true) {
            Ini = ini;
            if (load) Load();
        }
        /// <summary>
        /// Read All
        /// </summary>
        /// <returns></returns>
        public void Load() {
            if (!string.IsNullOrEmpty(Ini)) {
                NotifyList = new List<NotifyListModel>();
                for (var i = 1; i <= ReadCount() - 1; i++) {
                    var obj = new NotifyListModel();
                    obj.Message = NativeMethods.ReadINI(Ini, i.ToString(), "Message");
                    obj.Network = NativeMethods.ReadINI(Ini, i.ToString(), "Network");
                    obj.Nickname = NativeMethods.ReadINI(Ini, i.ToString(), "Nickname");
                    if (!string.IsNullOrEmpty(obj.Message) && !string.IsNullOrEmpty(obj.Network) && !string.IsNullOrEmpty(obj.Nickname)) {
                        NotifyList.Add(obj);
                    }
                }
            }
        }
        /// <summary>
        /// Save Notify List
        /// </summary>
        public void SaveNotifyList() {
            var n = 0;
            SetCount(NotifyList.Count);
            for (var i = 0; i <= NotifyList.Count - 1; i++) {
                if (NotifyList[i] != null && !string.IsNullOrEmpty(NotifyList[i].Nickname)) {
                    n++;
                    NativeMethods.WriteINI(Ini, n.ToString(), "Nickname", NotifyList[i].Nickname);
                    NativeMethods.WriteINI(Ini, n.ToString(), "Network", NotifyList[i].Network);
                    NativeMethods.WriteINI(Ini, n.ToString(), "Message", NotifyList[i].Message);
                }
            }
        }
    }
}