using System;
namespace nexIRC.IrcSettings {
    public class IrcSettings {
        public ChannelFolders ChannelFolders;
        public NetworkSettings IrcNetworks;
        public QuerySettings QuerySettings;
        //public CompatibilitySettings CompatibilitySettings;
        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="startupPath"></param>
        public IrcSettings(string startupPath) {
            try {
                ChannelFolders = new ChannelFolders(startupPath);
                IrcNetworks = new NetworkSettings(startupPath);
                QuerySettings = new QuerySettings(startupPath);
                //CompatibilitySettings = new CompatibilitySettings(startupPath);
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}