using System;
using System.Linq;
using System.Collections.Generic;
using nexIRC.Data.Interfaces;
using nexIRC.Data.Repositories;
using nexIRC.Models.NotifyList;
using Telerik.WinControls.UI;
namespace nexIRC.Business.Controllers {
    /// <summary>
    /// Notify List Controller
    /// </summary>
    public class NotifyListController : IDisposable {
        /// <summary>
        /// Ini
        /// </summary>
        private string _ini;
        /// <summary>
        /// Notify List
        /// </summary>
        public List<NotifyListModel> NotifyList { get; set; }
        /// <summary>
        /// Notify List Repository
        /// </summary>
        private INotifyListRepository _notifyListRepository;
        /// <summary>
        /// Notify List Controller
        /// </summary>
        public NotifyListController(string ini) {
            _notifyListRepository = new NotifyListRepository(ini);
            _ini = ini;
        }
        /// <summary>
        /// Is User In Notify List
        /// </summary>
        /// <param name="nickname"></param>
        /// <returns></returns>
        public bool IsUserInNotifyList(string nickname) {
            var objs = NotifyList.Where(n => n.Nickname.ToLower() == nickname.ToLower());
            return objs.Any();
        }
        /// <summary>
        /// Find Notify Index
        /// </summary>
        /// <param name="nickname"></param>
        /// <returns></returns>
        public int? FindNotifyIndex(string nickname) {
            for (var i = 1; i <= NotifyList.Count; i++) if (nickname.ToLower().Trim() == NotifyList[i].Nickname.ToLower().Trim()) return i;
            return null;
        }
        /// <summary>
        /// Populate Notify By ListView
        /// </summary>
        /// <param name="lv"></param>
        public void PopulateNotifyByListView(RadListView lv) {
            var objs = new List<NotifyListModel>();
            foreach (var item in lv.Items) {
                var notify = new NotifyListModel();
                notify.Nickname = item.Text;
                notify.Network = item[2].ToString();
                notify.Message = item[1].ToString();
                objs.Add(notify);
            }
            NotifyList = objs;
        }
        /// <summary>
        /// Save Notify List
        /// </summary>
        public void Save() {
            _notifyListRepository.SaveNotifyList();
        }
        /// <summary>
        /// Load
        /// </summary>
        public void Load() {
            _notifyListRepository.Load();
        }
        /// <summary>
        /// Disposed
        /// </summary>
        private bool _disposed = false;
        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose() {
            try {
                Dispose(true);
                GC.SuppressFinalize(this);
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Dispose
        /// </summary>
        protected virtual void Dispose(bool _disposing) {
            try {
                if (_disposed) {
                    return;
                }
                if (_disposing) {
                }
                _disposed = true;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}