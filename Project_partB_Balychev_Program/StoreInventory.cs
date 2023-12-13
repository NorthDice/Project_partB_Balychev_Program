using Project_partB_Balychev_Program;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_partB_Balychev_Program
{
    public class StoreInventory : IEnumerable<StoreItem>, ICollection,Iinvoice
    {
        protected List<StoreItem> items;

        public StoreInventory()
        {
            items = new List<StoreItem>();
        }

        public int Count => items.Count;

        public bool IsSynchronized => ((ICollection)items).IsSynchronized;

        public object SyncRoot => ((ICollection)items).SyncRoot;

        public StoreItem this[int index]
        {
            get { return items[index]; }
            set { items[index] = value; }
        }

        public void Add(StoreItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null.");
            }

            items.Add(item);
        }

        public void Clear()
        {
            items.Clear();
        }

        public bool Contains(StoreItem item)
        {
            return items.Contains(item);
        }

        public void SortByPrice()
        {
            items.Sort((item1, item2) => item1.Price.CompareTo(item2.Price));
        }

        public IEnumerator<StoreItem> GetEnumerator()
        {
            return ((IEnumerable<StoreItem>)items).GetEnumerator();
        }

        public bool Remove(StoreItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null.");
            }
            if(!items.Contains(item))
            {
                throw new ArgumentException();
            }
            return items.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)items).GetEnumerator();
        }


        public void CopyTo(Array array, int index)
        {
            items.CopyTo((StoreItem[])array, index);
        }

        public string GetStorageInfo()
        {
            string info = string.Empty;

            foreach (var item in items)
            {
                info += item.ToString();
            }

            return info;

        }
    }
}
