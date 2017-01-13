using System;

namespace Lesson5
{
	public class Person : IComparable<Person>
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public int Age { get; set; }

		public Person(string firstName, string lastName, int age)
		{
			FirstName = firstName;
			LastName = lastName;
			Age = age;
		}

		public int CompareTo(Person other)
		{
			if (this.Age > other.Age)
			{
				return 1;
			}
			else if (this.Age < other.Age)
			{
				return -1;
			}
			else
			{
				return 0;
			}
		}

		public override string ToString()
		{
			return string.Format($"Name: {FirstName}, LastName: {LastName}, Age: {Age}.");
		}
	}
}
