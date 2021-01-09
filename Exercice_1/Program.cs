using System;

namespace DesignPattern_Project_Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
			Queue<string> l = new Queue<string>();

			l.Enqueue(new Node<string>("Ciao,"));
			l.Enqueue(new Node<string>("Mondo"));
			l.print();

			l.Dequeue();
			l.print();
			l.Dequeue();
			l.print();
		}
    }
}
