using System.Collections.Generic;
using System.Text;

namespace ConApp
{
    public class DescartesDemo
    {
        public static void Run(List<List<string>> dimvalue, List<string> result, int layer, string curstring)
        {
            if (layer < dimvalue.Count - 1)
            {
                if (dimvalue[layer].Count == 0)
                {
                    Run(dimvalue, result, layer + 1, curstring);
                }
                else
                {
                    for (int i = 0; i < dimvalue[layer].Count; i++)
                    {
                        StringBuilder s1 = new StringBuilder();
                        s1.Append(curstring);
                        s1.Append(dimvalue[layer][i]);
                        Run(dimvalue, result, layer + 1, s1.ToString());
                    }
                }
            }
            else if (layer == dimvalue.Count - 1)
            {
                if (dimvalue[layer].Count == 0)
                {
                    result.Add(curstring);
                }
                else
                {
                    for (int i = 0; i < dimvalue[layer].Count; i++)
                    {
                        result.Add(curstring + dimvalue[layer][i]);
                    }
                }
            }
        }
    }
}