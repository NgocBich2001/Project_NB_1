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
        private Node<T> pHead;
        public Node<T> L
        {
            get
            {
                return pHead;
            }
            set
            {
                pHead= value;
            }    
        }    
        public List()
        {
            pHead = null;
        }
        public T this[int i]
        {
            get
            {
                Node<T> tg = pHead;
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
                if (pHead == null)
                    return 0;
                Node<T> tg = pHead;
                int dem = 0;
                while (tg.Link != null)
                {
                    tg = tg.Link;
                    dem++;
                }
                return dem + 1;
            }    
        }    
        public void Add(T x)
        {
            Node<T> tg = new Node<T>(x);
            if (pHead == null)
                pHead = tg;
            else
            {
                Node<T> p = pHead;
                while (p.Link != null)
                    p = p.Link;
                p.Link = tg;
            }    
        }    
        public void Add(T x, int i)
        {
            Node<T> tg = new Node<T>(x);
            if (Count == 0)
                pHead = tg;
            else if (i >=0 && i<=Count-1)
            {
                Node<T> p = pHead;
                int d = 0;
                while (p.Link != null && d !=i)
                {
                    p = p.Link;
                    d++;
                }    
                if (p==pHead)
                {
                    tg.Link = pHead;
                    pHead = tg;
                }    
                else
                {
                    Node<T> vt = pHead;
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
                Node<T> p = pHead;
                int d = 0;
                while(p.Link != null && d!=i)
                {
                    p = p.Link;
                    d++;
                }
                if (pHead.Link == null)
                    pHead = null;//Danh sách có một phần tử
                else if (p == pHead)//Phần tử cần xóa ở đàu danh sách
                    pHead = pHead.Link;
                else if (p.Link==null)//Phần tử cần xóa ở cuối danh sách
                {
                    Node<T> tg = pHead;
                    while (tg.Link.Link != null)
                        tg = tg.Link;
                    tg.Link = null;
                }    
                else//Phần tử cần xóa ở giữa danh sách
                {
                    Node<T> vt = pHead;
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
