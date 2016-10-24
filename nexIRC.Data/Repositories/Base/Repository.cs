using nexIRC.Data.Interfaces.Base;
using TeamNexgenCore.Helpers;
namespace nexIRC.Data.Repositories.Base {
    /// <summary>
    /// Repository
    /// </summary>
    public abstract class Repository<T> : IRepository<T> {
        /// <summary>
        /// Ini
        /// </summary>
        public virtual string Ini { get; set; }
        /// <summary>
        /// Set Index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public virtual bool SetIndex(int index) {
            NativeMethods.WriteINI(Ini, "Settings", "Index", index.ToString());
            return true;
        }
        /// <summary>
        /// Read Index
        /// </summary>
        /// <returns></returns>
        public virtual int ReadIndex() {
            return NativeMethods.ReadINIInt(Ini, "Settings", "Index");
        }
        /// <summary>
        /// Set Count
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public virtual bool SetCount(int count) {
            NativeMethods.WriteINI(Ini, "Settings", "Count", count.ToString());
            return true;
        }
        /// <summary>
        /// Read Count
        /// </summary>
        /// <returns></returns>
        public virtual int ReadCount() {
            return NativeMethods.ReadINIInt(Ini, "Settings", "Count");
        }
    }
}