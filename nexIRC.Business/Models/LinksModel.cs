using nexIRC.Business.Models.Link;
using System.Collections.Generic;
using System.Windows.Forms;
namespace nexIRC.Business.Models {
    /// <summary>
    /// Links Model
    /// </summary>
    public class LinksModel {
        /// <summary>
        /// Network Drop Down Description
        /// </summary>
        public string NetworkDropDownDescription { get; set; }
        /// <summary>
        /// Network Index
        /// </summary>
        public int NetworkIndex { get; set; }
        /// <summary>
        /// Status Index
        /// </summary>
        public int StatusIndex { get; set; }
        /// <summary>
        /// TreeNode
        /// </summary>
        public TreeNode TreeNode { get; set; }
        /// <summary>
        /// TreeNode Visible
        /// </summary>
        public bool TreeNodeVisible { get; set; }
        /// <summary>
        /// Visible
        /// </summary>
        public bool Visible { get; set; }
        /// <summary>
        /// Window
        /// </summary>
        public Form Window { get; set; }
        /// <summary>
        /// Links
        /// </summary>
        public List<LinkModel> Links { get; set; }
        /// <summary>
        /// Link Count
        /// </summary>
        public int LinkCount { get; set; }
    }
}