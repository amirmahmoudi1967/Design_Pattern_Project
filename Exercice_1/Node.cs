using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_Project_Ex1
{
	public class Node<T> : IEquatable<Node<T>>
	{
		public Node(T val)
		{
			data = val;
			next = null;
		}

		public T data { get; set; }
		public Node<T> next { get; set; }

		public bool Equals(Node<T> other)
		{
			return this.GetHashCode() == other.GetHashCode();
		}

		public override int GetHashCode()
		{
			return data.GetHashCode();
		}
	}
}
