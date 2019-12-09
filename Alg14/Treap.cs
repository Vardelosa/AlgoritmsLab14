using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg14
{
    class Treap
    {
        public int x;
        public int y;
        Random rand = new Random();
        public Treap Left;
        public Treap Right;
        private Treap(int x, int y, Treap left = null, Treap right = null)
        {
            this.x = x;
            this.y = y;
            Left = left;
            Right = right;
        }
        public Treap(int x)
        {
            this.x = x;
            y = rand.Next(500);
            Left = null;
            Right = null;
        }
        public static Treap Merge(Treap L, Treap R)
        {
            if (L == null) return R;
            if (R == null) return L;

            if (L.y > R.y)
            {
                var newR = Merge(L.Right, R);
                return new Treap(L.x, L.y, L.Left, newR);
            }
            else
            {
                var newL = Merge(L, R.Left);
                return new Treap(R.x, R.y, newL, R.Right);
            }
        }
        public void Split(int x, out Treap L, out Treap R)
        {
            Treap newTree = null;
            if (this.x <= x)
            {
                if (Right == null)
                    R = null;
                else
                    Right.Split(x, out newTree, out R);
                L = new Treap(this.x, y, Left, newTree);
            }
            else
            {
                if (Left == null)
                    L = null;
                else
                    Left.Split(x, out L, out newTree);
                R = new Treap(this.x, y, newTree, Right);
            }
        }
        public Treap Add(int x)
        {
            Treap final;
            Treap l, r;
            Split(x, out l, out r);
            Treap m = new Treap(x, rand.Next(500));
            final = Merge(Merge(l, m), r);
            Update(final);
            return final;
        }
        public Treap Remove(int x)
        {
            Treap final;
            Treap l, m, r;
            Split(x - 1, out l, out r);
            r.Split(x, out m, out r);
            final = Merge(l, r);
            Update(final);
            return final;
        }
        public void Update(Treap final)
        {
            x = final.x;
            y = final.y;
            Left = final.Left;
            Right = final.Right;
        }
        private void Traverse(Treap node, ref string info, int n = 0)
        {
            if (node == null)
                return;

            Traverse(node.Right, ref info, n + 5);

            string temp = "";
            for (int i = 0; i < n; ++i)
                temp += "  ";
            info += temp + node.x + ";" +node.y+" <"+ "\n";
            

            Traverse(node.Left, ref info, n + 5);
        }

        public override string ToString()
        {
            string info = "";
            Traverse(this, ref info);

            return info;
        }
    }
    
}
