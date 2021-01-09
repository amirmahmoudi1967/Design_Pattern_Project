using System;
using System.Collections.Generic;

namespace DesignPattern_Project_Ex1
{
	public class Queue<T>
	{
		public Node<T> head { get; set; }

		public void Enqueue(Node<T> node, bool onHead = false)
		{
			Console.WriteLine(node.data + " has been added to the queue\n");
			Node<T> new_node = new Node<T>(node.data);

			if (head == null)
			{
				head = new_node;
			}
			else
			{
				if (onHead)     // Add the new element on head
				{
					Node<T> temp = head;
					head = new_node;
					new_node.next = temp;
				}
				else        // Add the new element on tail
				{
					// Determine the last element of the list...
					Node<T> current = head;
					while (current.next != null)
						current = current.next;

					// ...and add the new node on tail
					current.next = new_node;
				}
			}
		}
		public void Dequeue()
		{
			Console.WriteLine(head.data + " has been removed to the queue\n");
			if (head == null)
			{
				Console.WriteLine("Your queue is empty\n");
			}
			else
			{
				Node<T> temp = head.next; // set the new head
				head = null;
				head = temp;

			}
		}

		public void print()
		{
			List<Node<T>> list_node = new List<Node<T>>();
			Node<T> current = head;

			while (current != null)
			{
				list_node.Add(current);
				current = current.next;
			}
			Console.WriteLine("\nCurrent queue :");
			if (list_node.Count == 0) { Console.WriteLine("Queue is empty\n"); }
			else
			{
				foreach (Node<T> nodes in list_node)
				{
					Console.Write($"{nodes.data} ");
				}
				Console.Write("\n\n");
			}
		}

	}

}
