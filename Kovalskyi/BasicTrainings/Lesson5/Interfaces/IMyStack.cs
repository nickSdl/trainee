
namespace Lesson5.Interfaces
{
	public interface IMyStack<T>
	{
		void Push(T item);

		T Pop();
	}
}
