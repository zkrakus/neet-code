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
    //public int diameter { get; set; } = 0;

    //public int FindDiameter(TreeNode? root)
    //{
    //    if (root is null)
    //        return 0;

    //    FindHeightRecursive(root);

    //    return diameter;
    //}

    //public int FindHeightRecursive(TreeNode? node)
    //{
    //    if (node is null)
    //        return 0;

    //    var leftHeight = FindHeightRecursive(node.left);
    //    var rightHeight = FindHeightRecursive(node.right);

    //    this.diameter = Math.Max(this.diameter, leftHeight + rightHeight);

    //    return 1 + Math.Max(leftHeight, rightHeight);
    //}



    public int FindDiameter(TreeNode? root)
    {
        int maxDiameter = 0;
        int DiameterOfBinaryTreeRec2(TreeNode? node, int depth)
        {
            if (node is null)
                return 0;

            var lh = DiameterOfBinaryTreeRec2(node.left, 0);
            var rh = DiameterOfBinaryTreeRec2(node.right, 0);

            var greaterDepth = Math.Max(lh, rh);
            maxDiameter = Math.Max(maxDiameter, lh + rh);

            return greaterDepth + 1;
        }

        _ = DiameterOfBinaryTreeRec2(root, maxDiameter);

        return maxDiameter;
    }




















}
