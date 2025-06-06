using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neetcode.Trees;
public static class SameBinaryTree
{
    //public static bool IsSameTree(TreeNode? p, TreeNode? q)
    //{
    //    if(p is null || q is null)
    //        return false;

    //    var treeDFSQueue = new Queue<int?>();
    //    TraverseTreeDFSAndAddToQueue(p, treeDFSQueue);
    //    return TraverseTreeDFSAndCompare(q, treeDFSQueue) && treeDFSQueue.Count == 0; ;
    //}

    //public static void TraverseTreeDFSAndAddToQueue(TreeNode? p, Queue<int?> treeDFSQueue)
    //{
    //    if (p is null)
    //    {
    //        treeDFSQueue.Enqueue(p?.val);
    //        return;
    //    }

    //    treeDFSQueue.Enqueue(p.val);

    //    TraverseTreeDFSAndAddToQueue(p.left, treeDFSQueue);
    //    TraverseTreeDFSAndAddToQueue(p.right, treeDFSQueue);

    //    return;
    //}

    //public static bool TraverseTreeDFSAndCompare(TreeNode? q, Queue<int?> treeDFSQueue)
    //{
    //    if (q is null)
    //    {
    //        return treeDFSQueue.Count > 0 && treeDFSQueue.Dequeue() == null;
    //    }

    //    return (treeDFSQueue.Count > 0 && treeDFSQueue.Dequeue() == q?.val) 
    //        && (TraverseTreeDFSAndCompare(q?.left, treeDFSQueue)) 
    //        && TraverseTreeDFSAndCompare(q?.right, treeDFSQueue);
    //}

    //public static bool IsSameTree3(TreeNode? p, TreeNode? q)
    //{
    //    if (p is null && q is not null)
    //        return false;

    //    if (p is not null && q is null)
    //        return false;

    //    if (p is null && q is null)
    //        return true;

    //    if (p is not null && q is not null && p.val == q.val)
    //        return IsSameTree3(p.left, q.left) && IsSameTree3(p.right, q.right);

    //    return false;
    //}
















    // DON"T SCROLL UP !!!!!!!!!!!!!!!!!!!!!!!!!!!
    // DON"T SCROLL UP !!!!!!!!!!!!!!!!!!!!!!!!!!!

    // DON"T SCROLL UP !!!!!!!!!!!!!!!!!!!!!!!!!!!
    // DON"T SCROLL UP !!!!!!!!!!!!!!!!!!!!!!!!!!!
    // DON"T SCROLL UP !!!!!!!!!!!!!!!!!!!!!!!!!!!




    public static bool IsSameTree(TreeNode? p, TreeNode? q)
    {
        if (p is null && q is null)
        {
            return true;
        } 
        else if ((p is null && p is not null) || (p is not null && q is null))
        {
            return false;
        }
        else if (p.val != q.val)
        {
            return false;
        }

        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }

}
