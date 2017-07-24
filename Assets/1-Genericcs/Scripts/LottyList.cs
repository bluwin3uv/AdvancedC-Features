using UnityEngine;

namespace Generics
{

    public class LottyList<T>
    {
        public T[] list;
        public int amount { get; private set; }
        public LottyList() { amount = 0; }
        public T this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                list[index] = value;
            }
        }
        public void Add(T items)
        {
            T[] cache = new T[amount + 1];
            if(list != null)
            {
                for(int i = 0; i < list.Length; i++)
                {
                    cache[i] = list[i];
                }
                cache[amount] = items;
                list = cache;
                amount++;
            } 
        }
    }
}
