using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genrics_and_lambda.Models
{
    public class GenericDataBase<T> where T : class
    {

        public delegate bool Callback(T item);

        public delegate T UpdateCallback(T item);


        private List<T> list = new List<T>();


        public void AddData(T data)
        {
            list.Add(data); 
        }

        public List<T> GetAllData()
        { 
            return list;
        }
      

        public void DeleteData(Callback callback)
        {
            foreach (T item in list)
            {
                if (callback(item))
                {
                    list.Remove(item);
                    break;
                }
            }
        }

        public T GetSingle(Callback callback)
        {
            T selected = null;
            foreach (T item in list)
            {
                if (callback(item))
                {
                    selected = item;
                    break;
                }
            }
            return selected;
        }

        public void UpdateData(Callback callback, UpdateCallback u_callback)
        {
            foreach (T item in list)
            {
                if (callback(item))
                {
                    u_callback(item);
                }
            }
        }

    }
}
