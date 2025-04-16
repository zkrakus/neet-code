using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace neetcode.Trees;
public class DiameterOfBinaryTree
{
    public int diameter { get; set; } = 0;

    public int FindDiameter(TreeNode? root)
    {
        if (root is null)
            return 0;

        FindHeightRecursive(root);

        return diameter;
    }

    public int FindHeightRecursive(TreeNode? node)
    {
        if (node is null)
            return 0;

        var leftHeight = FindHeightRecursive(node.left);
        var rightHeight = FindHeightRecursive(node.right);
        
        this.diameter = Math.Max(this.diameter, leftHeight + rightHeight);

        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
