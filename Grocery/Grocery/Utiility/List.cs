using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Grocery.Utiility
{
    public class Node<T>
    {
        //Cấu trúc dữ liệu của List
        private T info;
        private Node<T> link;
        //Các phương thức
        public T Info
        {
            get
            {
                return info;
            }    
            set
            {
                info = value;
            }    
        }
        public Node<T> Link
        {
             get
            {
                return link;
            }
            set
            {
                link = value;
            }    
        }    
        public Node()
        {

        }   
        public Node(T t)
        {
            info = t;
            link = null;
        }    
    }
    public class List<T>
    {
        private Node<T> l;
        public Node<T> L
        {
            get
            {
                return l;
            }
            set
            {
                l= value;
            }    
        }    
        public List()
        {
            l = null;
        }
        public T this[int i]
        {
            get
            {
                Node<T> tg = l;
                int d = 0;
                while (tg.Link != null && d != i)
                {
                    tg = tg.Link;
                    d++;
                }
                return tg.Info;
            }    
        }    
        public int Count
        {
            get
            {
                if (l == null)
                    return 0;
                Node<T> tg = l;
                int d = 0;
                while (tg.Link != null)
                {
                    tg = tg.Link;
                    d++;
                }
                return d + 1;
            }    
        }    
        public void Add(T x)
        {
            Node<T> tg = new Node<T>(x);
            if (l == null)
                l = tg;
            else
            {
                Node<T> p = l;
                while (p.Link != null)
                    p = p.Link;
                p.Link = tg;
            }    
        }    
        public void Add(T x, int i)
        {
            Node<T> tg = new Node<T>(x);
            if (Count == 0)
                l = tg;
            else if (i >=0 && i<=Count-1)
            {
                Node<T> p = l;
                int d = 0;
                while (p.Link != null && d !=i)
                {
                    p = p.Link;
                    d++;
                }    
                if (p==l)
                {
                    tg.Link = l;
                    l = tg;
                }    
                else
                {
                    Node<T> vt = l;
                    Node<T> tvt = vt;
                    while(vt != p)
                    {
                        tvt = vt;
                        vt = vt.Link;
                    }
                    tg.Link = vt;
                    tvt.Link= tg;
                }    
            }    
        }
        public void RemoveAt(int i)
        {
            if (Count == 0)
                return;
            else if (i>=0 && i<=Count-1)
            {
                Node<T> p = l;
                int d = 0;
                while(p.Link != null && d!=i)
                {
                    p = p.Link;
                    d++;
                }
                if (l.Link == null)
                    l = null;//Danh sách có một phần tử
                else if (p == l)//Phần tử cần xóa ở đàu danh sách
                    l = l.Link;
                else if (p.Link==null)//Phần tử cần xóa ở cuối danh sách
                {
                    Node<T> tg = l;
                    while (tg.Link.Link != null)
                        tg = tg.Link;
                    tg.Link = null;
                }    
                else//Phần tử cần xóa ở giữa danh sách
                {
                    Node<T> vt = l;
                    Node<T> tvt = vt;
                    while(vt!=p)
                    {
                        tvt = vt;
                        vt = vt.Link;
                    }
                    tvt.Link = vt.Link;
                }    
            }    
        }    
    }    
}
