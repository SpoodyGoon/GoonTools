using System;
using System.Collections;

namespace  libMonoTools.Collections
{
    public class FileInfoCollection : ICollection, IEnumerable
	{
		ArrayList _Files = new ArrayList();
        public FileInfoCollection()
		{            
		}

        public int Count
        {
            get { return _Files.Count; }
        }

        public bool IsReadOnly
        {
            get { return _Files.IsReadOnly; }
        }

        public bool IsSynchronized
        {
            get { return _Files.IsSynchronized; }
        }

        public object SyncRoot
        {
            get { return this; }
        }

        public void Add(System.IO.FileInfo fi)
        {
            if (!fi.Exists)
                throw new System.IO.FileNotFoundException("Not able to locate file.", fi.FullName);

            _Files.Add(fi);
        }

        public bool Contains(System.IO.FileInfo fi)
        {
            return _Files.Contains(fi);
        }

        public void CopyTo(Array array, int index)
        {
            _Files.CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return _Files.GetEnumerator();
        }

        public void Remove(System.IO.FileInfo fi)
        {
            _Files.Remove(fi);
        }

        public void Remove(string FileName)
        {
            System.IO.FileInfo fi = this[FileName];
            if (fi != null)
                this.Remove(fi);
        }

        public void Clear()
        {
            _Files.Clear();
        }

        public System.IO.FileInfo this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException("index");

                return (System.IO.FileInfo)_Files[index];
            }
        }

        public System.IO.FileInfo this[string FileName]
        {
            get
            {
                int index = -1;
                for (int i = 0; i < _Files.Count; i++)
                {
                    if (((System.IO.FileInfo)_Files[i]).Name == FileName)
                    {
                        index = i;
                        break;
                    }
                }

                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException("index");

                return (System.IO.FileInfo)_Files[index];
            }
        }
	}
}
