using System;

namespace ConApp.Samples
{
    public partial class Program
    {
        #region 单链表

        public static void LinkNodeDemo()
        {
            LinkNode node = new LinkNode();
            node.Value = 1;

            node.Next = new LinkNode();
            node.Next.Value = 2;

            node.Next.Next = new LinkNode();
            node.Next.Next.Value = 3;
            node.Next.Next.Next = null;

            ShowLinkNode0(node);

            ShowLinkNode1(node);
        }

        public static void ShowLinkNode0(LinkNode node)
        {
            Console.WriteLine(node.Value);
            if (node.Next == null)
            {
                return;
            }
            else
            {
                ShowLinkNode0(node.Next);
            }
        }

        public static void ShowLinkNode1(LinkNode node)
        {
            for (LinkNode n = node; ; n = n.Next)
            {
                Console.WriteLine(n.Value);

                if (n.Next == null)
                {
                    break;
                }
            }
        }

        public class LinkNode
        {
            public int Value { get; set; }

            public LinkNode Next { get; set; }
        }

        #endregion 单链表
    }
}