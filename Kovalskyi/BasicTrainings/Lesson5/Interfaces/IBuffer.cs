
namespace Lesson5.Interfaces
{
	public interface IBuffer<T> : IPrintable<T>
	{
		bool IsEmpty();

		bool IsFull();

		T Peek();
	}
}
