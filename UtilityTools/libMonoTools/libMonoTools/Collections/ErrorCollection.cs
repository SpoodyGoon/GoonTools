using System;
using System.Collections;

namespace libMonoTools.Collections
{
    public class ErrorCollection : ICollection, IEnumerable
	{
		ArrayList _Errors = new ArrayList();
        public ErrorCollection()
		{
            
		}
        public int Count
        {
            get { return _Errors.Count; }
        }

        public bool IsReadOnly
        {
            get { return _Errors.IsReadOnly; }
        }

        public bool IsSynchronized
        {
            get { return _Errors.IsSynchronized; }
        }

        public object SyncRoot
        {
            get { return this; }
        }

        public void Add(Exception ex)
        {
            _Errors.Add(ex);
        }

        public bool Contains(Exception ex)
        {
            return _Errors.Contains(ex);
        }

        public void CopyTo(Array array, int index)
        {
            _Errors.CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return _Errors.GetEnumerator();
        }

        public void Remove(Exception ex)
        {
            _Errors.Remove(ex);
        }

        public void Clear()
        {
            _Errors.Clear();
        }

        public Exception this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException("index");

                return (Exception)_Errors[index];
            }
        }
	}
}
