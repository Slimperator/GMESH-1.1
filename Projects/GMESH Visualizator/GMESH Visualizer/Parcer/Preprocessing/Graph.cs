using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facets
{
    public class graph
    {
        public class edge
        {
            public int tag = -1;
            public readonly int a, b;
            public edge back { get; private set; }
            private edge(int a, int b) { this.a = a; this.b = b; }

            public static void create(int a, int b, out edge ab, out edge ba)
            {
                ab = new edge(a, b);
                ba = new edge(b, a);
                ab.back = ba;
                ba.back = ab;
            }
        }

        public readonly int n, m;
        
        public graph(int n, int m) { this.n = n; this.m = m; }

        private edge[][] inc;

        public edge[] this[int node] { get { return inc[node]; } }

        public static graph construct(params int[] edges)
        {
            graph g = new graph(edges.Max() + 1, edges.Length);
            
            edge[] e = new edge[g.m];
            for (int i = 0; i < g.m; i += 2)
                edge.create(edges[i], edges[i + 1], out e[i], out e[i + 1]);

            List<edge>[] inc = new List<edge>[g.n];
            for (int i = 0; i < g.n; i++) inc[i] = new List<edge>();
            foreach (var i in e) inc[i.a].Add(i);

            g.inc = new edge[g.n][];
            for (int i = 0; i < g.n; i++) g.inc[i] = inc[i].ToArray();
            
            return g;
        }
    }
}
