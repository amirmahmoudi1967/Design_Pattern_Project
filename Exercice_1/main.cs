using System;

public class Program
{
	public static void Main()
	{
		Queue<string> l = new Queue<string>();
		
		l.Enqueue(new Node<string>("Ciao,"));
		l.Enqueue(new Node<string>("Mondo\n"));
		l.print();
		
		l.Dequeue;
		l.print();
		l.Dequeue;
		l.print();
	}
}
