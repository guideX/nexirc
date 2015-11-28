using System;
namespace nexIRC.Business.Repositories {
    public class IrcSettings {
        public ChannelFolderRepository ChannelFoldersRepo;
        public NetworkSettings IrcNetworks;
        public QuerySettings QuerySettings;
        //public CompatibilitySettings CompatibilitySettings;
        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="startupPath"></param>
        public IrcSettings(string startupPath) {
            try {
                ChannelFoldersRepo = new ChannelFolderRepository(startupPath);
                IrcNetworks = new NetworkSettings(startupPath);
                QuerySettings = new QuerySettings(startupPath);
                //CompatibilitySettings = new CompatibilitySettings(startupPath);
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}