/*
	Credit to Aaron Gage for original tree code
	http://stackoverflow.com/a/2012855
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTFP.DataStructures
{
	public delegate void TreeVisitor<T>(T nodeData);

	public class GenericTree<T>
	{
		protected T data;
		private LinkedList<GenericTree<T>> children;

		public GenericTree(T data)
		{
			this.data = data;
			children = new LinkedList<GenericTree<T>>();
		}

		public void AddChild(T data)
		{
			children.AddFirst(new GenericTree<T>(data));
		}

		public void AddChildToParent(T parent, T child)
		{
			if (data.Equals(parent))
				this.AddChild(child);
			else
			{
				foreach (GenericTree<T> n in children)
				{
					if (n.data.Equals(data))
					{
						n.AddChild(child);
						return;
					}
				}
			}
		}

		public GenericTree<T> GetChild(int i)
		{
			foreach (GenericTree<T> n in children)
				if (--i == 0)
					return n;
			return null;
		}

		public void Traverse(GenericTree<T> node, TreeVisitor<T> visitor)
		{ 
			visitor(node.data);
			foreach (GenericTree<T> kid in node.children)
				Traverse(kid, visitor);
		}
	}
}
