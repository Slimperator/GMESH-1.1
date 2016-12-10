using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facets
{
    public class alg
    {
        static public graph.edge[][] cycles(graph g)
        {
            SortedList<string, graph.edge[]> c = new SortedList<string, graph.edge[]>();
            for (int i = 0; i < g.n; i++) foreach (var e in g[i]) e.tag = 0;
            queue q = new queue(g.n);
            q.reset();
            q.push(0);
            while (!q.epmty())
            {
                int node = q.pop();
                foreach (var e in g[node])
                    if (q.push(e.b)) e.tag = e.back.tag = 1;
                    else
                    {
                        e.tag = e.back.tag = 0;
                        List<graph.edge> path = alg.chain(g, e.b, e.a, 1);
                        e.tag = e.back.tag = 1;
                        if (path == null) continue;
                        path.Add(e);
                        string key = to_key(path);
                        if (c.ContainsKey(key)) continue;
                        c.Add(key, path.ToArray());
                    }
            }
            return c.Values.ToArray();
        }

        static private List<graph.edge> chain(graph g, int a, int b, int enabled_tag)
        {
            queue q = new queue(g.n);
            graph.edge[] prv = new graph.edge[g.n];
            q.reset();
            q.push(a);
            while (!q.epmty())
            {
                int node = q.pop();
                foreach (var e in g[node])
                {
                    if (e.tag != enabled_tag) continue;
                    if (q.push(e.b)) prv[e.b] = e;
                    if (e.b == b)
                    {
                        List<graph.edge> chain = new List<graph.edge>();
                        for (int k = b; prv[k] != null; k = prv[k].a) chain.Add(prv[k]);
                        chain.Reverse();
                        return chain;
                    }
                }
            }
            return null;
        }

        static private string to_key(IEnumerable<graph.edge> cycle)
        {
            List<int> items = new List<int>();
            foreach (var e in cycle) items.Add(e.a);
            items.Sort();
            string key = ""; 
            foreach (var i in items) key += string.Format("{0} ", i);
            return key;
        }
    }
}
