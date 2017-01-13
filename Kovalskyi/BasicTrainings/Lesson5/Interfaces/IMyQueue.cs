
namespace Lesson5.Interfaces
{
	public interface IMyQueue<T>
	{
		void Enqueue (T item);

		T Dequeue();
	}
}
