using System.Collections.Generic;
namespace nexIRC.Business.ViewModels {
    /// <summary>
    /// Channel Folder View Model
    /// </summary>
    public class ChannelFolderViewModel {
        /// <summary>
        /// Irc Network Descriptions
        /// </summary>
        public List<string> IrcNetworkDescriptions { get; set; }
        /// <summary>
        /// Default Network
        /// </summary>
        public string DefaultNetwork { get; set; }
        /// <summary>
        /// Popup Channel Folder Setting
        /// </summary>
        public bool PopupChannelFolderSetting { get; set; }
        /// <summary>
        /// Channel Folder Close on Join
        /// </summary>
        public bool ChannelFolderCloseOnJoin { get; set; }
    }
}
