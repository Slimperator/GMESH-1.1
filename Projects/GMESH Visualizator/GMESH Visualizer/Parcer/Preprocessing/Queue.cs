using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Preprocessing
{
    public class queue
    {
        int n;
        int end;
        int cur;
        int[] per;
        int[] inv;

        public queue(int n)
        {
            this.n = n;
            per = new int[n];
            inv = new int[n];
            for (int i = 0; i < n; i++) per[i] = inv[i] = i;
        }

        public void reset()
        {
            end = 0;
            cur = 0;
        }

        public bool push(int node)
        {
            if (inv[node] < end) return false;
            flip(inv[node], end);
            end++;
            return true;
        }

        public bool epmty()
        {
            return cur >= end;
        }

        public int pop()
        {
            return per[cur++];
        }


        void flip(int i, int j)
        {
            int tmp = per[i];
            per[i] = per[j];
            per[j] = tmp;
            inv[per[i]] = i;
            inv[per[j]] = j;
        }
    }
}
