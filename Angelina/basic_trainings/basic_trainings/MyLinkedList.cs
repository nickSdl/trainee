using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_trainings
{
    class MyLinkedList <T> 
    {
        private MyNode<T> Head;
        private MyNode<T> Tail;
        public int Count { get; private set; }

        public MyLinkedList()
        {
            Count = 0;
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
            MyNode<T> previousItem = null;
            MyNode<T> currentItem = Head;
            MyNode<T> newNode = new MyNode<T>(Value);



            if (Head == null)//list is empty
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
                        if (currentItem == Head && currentItem == Tail)//there is only element in list
                        {
                            Head.Value = item;
                            Tail.Value = item;
                        }
                        else if (currentItem == Head)//necessary item is the first element of list
                        {
                            newNode.Next = Head.Next;
                            Head = newNode;
                        }
                        else if (currentItem == Tail)//necessary item is the last element of list
                        {
                            previousItem.Next = newNode;
                            newNode.Next = Tail;                            
                        }
                        else//necessary item isn't the first or the last element of list
                        {
                            previousItem.Next = newNode;
                            newNode.Next = currentItem;
                        }

                        Count++;
                        return true;
                    }
                    previousItem = currentItem;
                    currentItem = currentItem.Next;
                }

                Console.WriteLine("Can't addbefore: there isn't item in list: "+ item);
                return false;
            }
        }

          public bool AddAfter(T item, T Value)
          {
            MyNode<T> previousItem = null;
            MyNode<T> currentItem = Head;
            MyNode<T> newNode = new MyNode<T>(Value);



            if (Head == null)//list is empty
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
                        if (currentItem == Head && currentItem == Tail)//there is only element in list
                        {
                            Head.Value = item;
                            Tail.Value = item;
                        }
                        else if (currentItem == Head)//necessary item is the first element of list
                        {
                            newNode.Next = Head.Next;
                            Head.Next = newNode;                            
                        }
                        else if (currentItem == Tail)//necessary item is the last element of list
                        {
                            Tail.Next = newNode;
                            Tail = newNode;
                        }
                        else//necessary item isn't the first or the last element of list
                        {
                            newNode.Next = currentItem.Next;
                            currentItem.Next = newNode;                            
                        }

                        Count++;
                        return true;
                    }
                    previousItem = currentItem;
                    currentItem = currentItem.Next;
                }

                Console.WriteLine("Can't addbefore: there isn't item in list: " + item);
                return false;
            }
        }
               


        public void AddFirst(T Value)
        {            

            MyNode<T> newNode = new MyNode<T>(Value);
            if (Count == 0)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head = newNode;
            }

            Count++;
        }

        public void AddLast(T Value) 
        {
            MyNode<T> newNode = new MyNode<T>(Value);
            //add first and the only element  ==head==tail
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                //add element in the end ==tail
                Tail.Next = newNode;
                Tail = newNode;
            }
            Count++;
        }

        public bool Remove(T item)
        {
            MyNode<T> previousItem = null;
            MyNode<T> currentItem = Head;

            if(Head == null)//list is empty
            {
                Console.WriteLine("Can't remove: the list is empty!!!");
                return false;
            }
            else
            {
                while (currentItem != null)
                {
                    if(currentItem.Value.Equals(item))//necessary item was found
                    {
                        if (currentItem == Head && currentItem == Tail)//there is only element in list
                        {
                            Head = null;
                            Tail = null;
                        }
                        else if(currentItem == Head)//necessary item is the first element of list
                        {
                            Head = Head.Next;
                        }
                        else if (currentItem == Tail)//necessary item is the last element of list
                        {
                            Tail = previousItem;
                        }
                        else//necessary item isn't the first or the last element of list
                        {
                            previousItem.Next = currentItem.Next;
                        }


                        Count--;
                        return true;
                    }
                    previousItem = currentItem;
                    currentItem = currentItem.Next;
                }

                Console.WriteLine("Can't remove: the list not contains the item: {0}", item);

                return false;//??? is necessary here???????? maybe just delete the "else"???
            }

            
        }

        public bool RemoveFirst()
        {
            if (Head != null)
            {
                Head = Head.Next;
                Count--;
                return true;
            }
            else
            {
                Console.WriteLine("Can't remove: the list is empty!!!");
                return false;
            }

            //or
            /*
             return Remove(Head.Value);
              */

        }

        public bool RemoveLast()
        {
            //field "previous" is needed or:
            /*
             Tail=Tail.Previous;
             Count--;
            return true;*/

            if (Tail == null && Head== null)
            {
                Console.WriteLine("Can't remove: the list is empty!!!");
                return false;
            }
            else
            {
                return Remove(Tail.Value);//will work only if Tail.Value is unique
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
