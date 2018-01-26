using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using AHWForm.Models;

namespace AHWForm.Helper
{
    public class TreeHelper
    {
        public static void PopulateNodes(IEnumerable<CategoryModel> categories, TreeView tw)
        {
            foreach (var item in categories)
            {
                if (item.ParentCategoryId == null)
                {
                    var rootNode = new TreeNode(item.Name, item.Id);
                    AddChildren(categories.ToList(), rootNode);
                    tw.Nodes.Add(rootNode);
                }
            }
        }

        public static void AddChildren(List<CategoryModel> categories, TreeNode activeTreeNode)
        {
            foreach (var item in categories)
            {
                if (item.ParentCategoryId == activeTreeNode.Value)
                {
                    TreeNode tn = new TreeNode(item.Name, item.Id);

                    AddChildren(categories, tn);
                    activeTreeNode.ChildNodes.Add(tn);
                }
            }
        }
    }
}