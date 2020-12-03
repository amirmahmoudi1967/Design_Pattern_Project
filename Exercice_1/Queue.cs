using System;
using System.Collections.Generic;

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
	#region getnode()
	public Node<T> getNode(int idx)
	{
		Node<T> current = head;
		int pos = 0;

		while (current != null)
		{
			if (pos == idx)
				return current;

			current = current.next;
			pos++;
		}

		return null;
	}

	public Node<T> getNode(Node<T> elem)
	{
		Node<T> current = head;
		int pos = 0;

		while (current != null)
		{
			if (current.Equals(elem))
				return current;

			current = current.next;
			pos++;
		}

		return null;
	}
	#endregion getnode
	public void setNode(int idx, Node<T> node)
	{
		Node<T> current = head;
		Node<T> prev_current = null;
		int pos = 0;

		while (current != null)
		{
			if (pos == idx)
			{
				Node<T> new_node = new Node<T>(node.data);
				new_node.next = current.next;
				prev_current.next = new_node;
				break;
			}

			prev_current = current;
			current = current.next;
			pos++;
		}
	}

	// Override operator [] for SingleLinkedList objects
	public Node<T> this[int index]
	{
		get
		{
			return getNode(index);
		}

		set
		{
			setNode(index, value);
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
