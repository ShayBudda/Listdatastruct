using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ListsDataStructure
{
    public class MyArrayList
    {
        int[] _list;
        int _size = 0;
        public int Size { get { return _size; } }
        public int[] List { get { return _list; } }

        public MyArrayList()
        {
            _list = new int[10];
        }

        public MyArrayList(int size)
        {
            _list = new int[size];
        }

        /// <summary>
        /// 
        /// Will add the incoming value to the end of the list
        /// </summary>
        /// <param name="value">the value that should be added</param>
        public void Append(int value)
        {
            IncreaseCapacity();
            _list[_size++] = value;
        }

        public void AddStart(int value)
        {
            IncreaseCapacity();
            for (int i = _size; i >= 0; i--)
            {
                _list[i + 1] = _list[i];
            }

            _list[0] = value;
            ++_size;
        }

        public void  Insert(int value, int indexToInsertAt)
        {
            if (indexToInsertAt < 0 || indexToInsertAt > _size)
                throw new IndexOutOfRangeException($"index {indexToInsertAt} is out of range");
            IncreaseCapacity();
            for (int i = _size - 1; i >= indexToInsertAt; i--)
            {
                _list[i + 1] = _list[i];
            }
            _list[indexToInsertAt] = value;
        }

        public void DeleteStart()
        {
            DeleteFromIndex(0);
        }
        public void DeleteEnd()
        {
            if (_size <= 0) return;
            _list[--_size] = 0;
        }

        public void DeleteFromIndex(int index)
        {
            if (_size <= 0) return;
            for (int i = 0; i < _size; i++)
            {
                if (i + 1 == _size)
                {
                    _list[i] = 0;
                    break;
                }
                _list[i] = _list[i + 1];
            }
            --_size;
        }
        private void IncreaseCapacity()
        {
            if (_size != _list.Length) return;
            int[] newArray = new int[_size * 2];
            for (int i = 0; i < _size; i++)
            {
                newArray[i] = _list[i];
            }


            _list = newArray;
        }
       

        
    }
}
