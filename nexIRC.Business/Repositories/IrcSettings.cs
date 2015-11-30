namespace nexIRC.Business.Repositories {
    /// <summary>
    /// Irc Settings
    /// </summary>
    public class IrcSettings {
        /// <summary>
        /// Channel Folders Repository
        /// </summary>
        public ChannelFolderRepository ChannelFoldersRepository;
        public NetworkRepository IrcNetworks;
        public QuerySettings QuerySettings;
        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="startupPath"></param>
        public IrcSettings(string startupPath) {
            ChannelFoldersRepository = new ChannelFolderRepository(startupPath);
            IrcNetworks = new NetworkRepository(startupPath);
            QuerySettings = new QuerySettings(startupPath);
        }
    }
}