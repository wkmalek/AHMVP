using System.Collections.Generic;
using System.Linq;
using System.Web;
using AHWForm.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MoreLinq;
using System.Web.UI.WebControls;
using System;

namespace AHWForm.Classes_And_Interfaces
{
    public class ExtensionMethods
    {
        public static void PopulateNodes(IEnumerable<CategoryModel> categories, TreeView tw)
        {
            
            foreach (var item in categories)
            {
                if (item.ParentCategoryId == null)
                {
                    var rootNode = new TreeNode(item.Name, item.Id.ToString());
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
                    TreeNode tn = new TreeNode(item.Name, item.Id.ToString());

                    AddChildren(categories, tn);
                    activeTreeNode.ChildNodes.Add(tn);
                }
            }

        }
    }
}