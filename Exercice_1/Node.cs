using System;

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
