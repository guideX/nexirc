namespace nexIRC.Data.Interfaces.Base {
    /// <summary>
    /// IRepository
    /// </summary>
    public interface IRepository<T> {
        /// <summary>
        /// Set Index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        bool SetIndex(int index);
        /// <summary>
        /// Read Index
        /// </summary>
        /// <returns></returns>
        int ReadIndex();
    }
}