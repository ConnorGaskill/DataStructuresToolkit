using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.DataStructures
{
    /// <summary>
    /// Represents a node in a singly linked list.
    /// Will probably need to expand this in a later assignment to include a head, tail, and add/remove methods
    /// </summary>
    public class ListNode
    {
        public int Value;
        public readonly ListNode? Next;

        public ListNode(int value, ListNode next = null)
        {
            Value = value;
            Next = next;
        }
    }
}