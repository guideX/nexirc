using nexIRC.Business.ViewModels;
namespace nexIRC.Business.Controllers {
    public class AboutController {
        /// <summary>
        /// Load
        /// </summary>
        /// <returns></returns>
        public AboutViewModel Load() {
            var model = new AboutViewModel();
            model.ShowItemCloseButton = false;
            return model;
        }
    }
}