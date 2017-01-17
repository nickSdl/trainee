using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_trainings
{
    class MyDoubleLinkedList<T>
    {
        private MyNode<T> Head;
        private MyNode<T> Tail;
        public int Count { get; private set; }
        

        public MyDoubleLinkedList()
        {
            Count = 0;
        }

        public bool IsEmpty()
        {
            if (Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void Add(T Value)
        {
            AddLast(Value);
        }


        public bool AddBefore(T item, T Value)
        {
            MyNode<T> currentItem = Head;
            MyNode<T> newNode = new MyNode<T>(Value);

            if (IsEmpty())//list is empty
            {
                Console.WriteLine("Can't add before the item '{0}' because the list is empty!!!");
                return false;
            }
            else
            {
                while (currentItem != null)
                {
                    if (currentItem.Value.Equals(item))//necessary item was found
                    {
                        if (Count == 1 || currentItem == Head)//add before head or there is only element in list
                        {
                            AddFirst(Value);
                        }
                        else if (currentItem == Tail)//necessary item is the last element of list
                                                     //add before Tail
                        {
                            newNode.Previous = Tail.Previous;
                            Tail.Previous = newNode;
                            newNode.Previous.Next = newNode;
                            newNode.Next = Tail;

                            Count++;
                        }
                        else//necessary item isn't the first or the last element of list
                        {
                            currentItem.Previous.Next = newNode;
                            newNode.Previous = currentItem.Previous;
                            newNode.Next = currentItem;
                            currentItem.Previous = newNode;

                            Count++;
                        }

                        return true;
                    }
                    currentItem = currentItem.Next;
                }

                Console.WriteLine("Can't addbefore: there isn't item in list: " + item);
                return false;
            }
        }

        public bool AddAfter(T item, T Value)
        {
            MyNode<T> currentItem = Head;
            MyNode<T> newNode = new MyNode<T>(Value);



            if (IsEmpty())//list is empty
            {
                Console.WriteLine("Can't add after the item '{0}' because the list is empty!!!");
                return false;
            }
            else
            {
                while (currentItem != null)
                {
                    if (currentItem.Value.Equals(item))//necessary item was found
                    {
                        if (Count == 1)//there is only element in list
                        {
                            AddLast(Value);
                        }
                        else if (currentItem == Head)//necessary item is the first element of list
                        {
                            Head.Next.Previous = newNode;
                            newNode.Next = Head.Next;
                            newNode.Previous = Head;
                            Head.Next = newNode;

                            Count++;

                        }
                        else if (currentItem == Tail)//add after the last element of list
                        {
                            AddLast(Value);
                        }
                        else//necessary item isn't the first or the last element of list
                        {
                            currentItem.Next.Previous = newNode;
                            newNode.Next = currentItem.Next;
                            currentItem.Next = newNode;
                            newNode.Previous = currentItem;

                            Count++;
                        }

                        return true;
                    }
                    currentItem = currentItem.Next;
                }

                Console.WriteLine("Can't addbefore: there isn't item in list: " + item);
                return false;
            }
        }



        public void AddFirst(T Value)
        {

            MyNode<T> newNode = new MyNode<T>(Value);
            if (IsEmpty())
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Head.Previous = newNode;
                newNode.Next = Head;
                Head = newNode;
            }

            Count++;
        }

        public void AddLast(T Value)
        {
            MyNode<T> newNode = new MyNode<T>(Value);
            
            if (IsEmpty())//add first and the only element  ==head==tail
            {
                Head = newNode;
                Tail = newNode;
            }
            else //add element in the end ==tail
            {                
                Tail.Next = newNode;
                newNode.Previous = Tail;
                Tail = newNode;
            }
            Count++;
        }

        public bool Remove(T item)
        {
            MyNode<T> currentItem = Head;

            if (IsEmpty())//list is empty
            {
                Console.WriteLine("Can't remove: the list is empty!!!");
                return false;
            }
            else
            {
                while (currentItem != null)
                {
                    if (currentItem.Value.Equals(item))//necessary item was found
                    {
                        if (Count == 1 || currentItem == Head)//there is only element in list
                        {
                            RemoveFirst();
                        }
                        else if (currentItem == Tail)//necessary item is the last element of list
                        {
                            RemoveLast();
                        }
                        else//necessary item isn't the first or the last element of list
                        {
                            currentItem.Previous.Next = currentItem.Next;
                            currentItem.Next.Previous = currentItem.Previous;
                            Count--;
                        }

                        return true;
                    }
                    currentItem = currentItem.Next;
                }

                Console.WriteLine("Can't remove: the list not contains the item: {0}", item);
                return false;
            }


        }

        public bool RemoveFirst()
        {
            if (!IsEmpty())
            {
                Head.Next.Previous = null;
                Head = Head.Next;

                Count--;
                return true;
            }
            else
            {
                Console.WriteLine("Can't remove: the list is empty!!!");
                return false;
            }
        }

        public bool RemoveLast()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Can't remove: the list is empty!!!");
                return false;
            }
            else
            {
                Tail.Previous.Next = null;
                Tail = Tail.Previous;

                Count--;
                return true;
            }

        }

        public void Print()
        {
            if (Head != null)
            {
                Console.WriteLine("____________________\nLinked List:");
                MyNode<T> item = Head;

                while (item != null)
                {
                    Console.WriteLine(item.Value);
                    item = item.Next;
                }
                Console.WriteLine("____________________");
            }
            else
            {
                Console.WriteLine("Can't print: the list is empty!!!");
            }
        }


    }
}
