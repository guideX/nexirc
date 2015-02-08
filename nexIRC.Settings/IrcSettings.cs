using System;
namespace nexIRC.IrcSettings {
    public class IrcSettings {
        public ChannelFolders ChannelFolders;
        public Networks IrcNetworks;
        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="startupPath"></param>
        public IrcSettings(string startupPath) {
            try {
                ChannelFolders = new ChannelFolders(startupPath);
                IrcNetworks = new Networks(startupPath);
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}