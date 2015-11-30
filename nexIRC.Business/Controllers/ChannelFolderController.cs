using System.Linq;
using nexIRC.Business.Repositories;
using nexIRC.Business.ViewModels;
namespace nexIRC.Business.Controllers {
    /// <summary>
    /// Channel Folder Controller
    /// </summary>
    public class ChannelFolderController {
        /// <summary>
        /// Channel Folder Controller
        /// </summary>
        /// <param name="startupPath"></param>
        /// <returns></returns>
        public ChannelFolderViewModel Form_Load(string startupPath) {
            var ircSettings = new IrcSettings(startupPath);
            var networkSettings = new NetworkRepository(startupPath);
            var model = new ChannelFolderViewModel();
            model.DefaultNetwork = ircSettings.IrcNetworks.GetDefault().Description;
            model.IrcNetworkDescriptions = networkSettings.Get().Select(ns => ns.Description).ToList();
            return model;
        }
    }
}