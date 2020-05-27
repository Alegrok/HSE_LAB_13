using System;
using System.Collections;
using System.Collections.Generic;


namespace HSE_LAB_13
{
	public class MyTree<T> : IEnumerable<T>, ICloneable
	{
		public Point<T> root = null;
		List<T> list = new List<T>();

		public MyTree()
		{
			root = null;
		}

		public MyTree(params T[] arr)
		{
			foreach (T item in arr)
			{
				list.Add(item);
			}
			int i = 0;
			root = MakeTree(list.Count, root, ref i);
		}

		public int Count
		{
			get
			{
				return list.Count;
			}
		}

		public T this[int index]
		{
			set
			{
				SetValueByIndex(index, value);
			}
			get
			{
				return GetByIndex(index);
			}
		}

		public virtual void SetValueByIndex(int index, T value)
		{
			if (index >= Count || index < 0) throw new ArgumentException("Индекс превышает размер или меньше размера коллекции");
			list[index] = value;
			int i = 0;
			root = MakeTree(list.Count, root, ref i);
		}

		public virtual T GetByIndex(int index)
		{
			if (index >= Count || index < 0) throw new ArgumentException("Индекс превышает размер или меньше размера коллекции");
			return list[index];
		}

		Point<T> MakeTree(int size, Point<T> p, ref int i)
		{
			Point<T> r;
			int nl, nr;
			if (size == 0)
			{
				p = null;
				return p;
			}
			nl = size / 2;
			nr = size - nl - 1;
			r = new Point<T>(list[i]);
			i++;
			r.left = MakeTree(nl, r.left, ref i);
			r.right = MakeTree(nr, r.left, ref i);
			return r;
		}

		Point<T> MakeTreeClone(int size, Point<T> p, ref int i)
		{
			Point<T> r;
			int nl, nr;
			if (size == 0)
			{
				p = null;
				return p;
			}
			nl = size / 2;
			nr = size - nl - 1;
			r = (Point<T>)new Point<T>(list[i]).Clone();
			i++;
			r.left = MakeTree(nl, r.left, ref i);
			r.right = MakeTree(nr, r.left, ref i);
			return r;
		}

		public static void ShowTree(Point<T> p, int l)
		{
			if (p != null)
			{
				ShowTree(p.left, l + 3);
				for (int i = 0; i < l; i++) Console.Write(" ");
				Console.WriteLine(p.data);
				ShowTree(p.right, l + 3);
			}
		}

		public virtual void Add(T d)
		{
			list.Add(d);
			int i = 0;
			root = MakeTree(list.Count, root, ref i);
		}

		public virtual void Add(params T[] arr)
		{
			foreach (T item in arr)
			{
				list.Add(item);
			}
			int i = 0;
			root = MakeTree(list.Count, root, ref i);
		}

		public virtual bool Remove(int j)
		{
			if (j < 1 || j >= list.Count) return false;
			list.RemoveAt(j);
			int i = 0;
			root = MakeTree(list.Count, root, ref i);
			return true;
		}

		public virtual bool Remove(T data)
		{
			int i = 0;
			while (i < list.Count)
			{
				if (list[i].Equals(data))
				{
					list.Remove(data);
					int j = 0;
					root = MakeTree(list.Count, root, ref j);
					return true;
				}
				i++;
			}
			return false;
		}

		public bool Find(T elem)
		{
			int i = 0;
			while (i < list.Count)
			{
				if (list[i].Equals(elem)) return true;
				i++;
			}
			return false;
		}

		public object Clone()
		{
			int i = 0;
			Point<T> newRoot = MakeTreeClone(list.Count, root, ref i);
			return newRoot;
		}

		public object ShallowCopy()
		{
			return root;
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			int i = 0;
			while (i < list.Count)
			{
				yield return list[i];
				i++;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		private IEnumerator GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Clear()
		{
			root = null;
		}

		public override int GetHashCode()
		{
			return root.GetHashCode() * Count;
		}

		public override bool Equals(object obj)
		{
			MyTree<T> tmp = (MyTree<T>)obj;
			return root.Equals(tmp.root);
		}
	}
}
