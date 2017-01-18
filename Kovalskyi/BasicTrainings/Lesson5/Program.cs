using System;
using System.Collections.Generic;
using Lesson5.DynamicArray;
using Lesson5.LinkedList;
using Lesson5.Buffer;

namespace Lesson5
{
	class Program
	{
		static void Main(string[] args)
		{
			//List<Person> classmates = new List<Person>();

			//classmates.Add(new Person("Ivan", "Popov", 33));
			//classmates.Add(new Person("Peter", "Ivanov", 21));
			//classmates.Add(new Person("Mary", "Li", 13));
			//classmates.Add(new Person("Tony", "Bus", 45));
			//classmates.Add(new Person("Kevin", "Macalister", 18));

			//Console.WriteLine("Your classmates: ");
			//foreach (Person item in classmates)
			//{
			//	Console.WriteLine(item);
			//}
			//classmates.Sort();
			//Console.WriteLine();
			//Console.WriteLine("Sorted list of your classmates: ");

			//foreach (Person item in classmates)
			//{
			//	Console.WriteLine(item);
			//}

			MyStack<int> stack = new MyStack<int>(2);

			stack.Push(12);
			stack.Pop();
			


			Console.Read();
		}
	}
}
