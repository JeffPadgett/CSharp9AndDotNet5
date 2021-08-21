

namespace WiredBrainCoffee.StackApp
{
    public class SimpleStackTest<T>
    {
        private int _currentIndex = -1;

        public T[] Items { get; private set; }
        public SimpleStackTest() => Items = new T[10];

        public int Count => _currentIndex + 1;

        public void Push(T item) => Items[++_currentIndex] = item;//Plus 1 BEFORE getting the index

        public T Pop() => Items[_currentIndex--];//minus 1 AFTER getting the index. 
    }
}