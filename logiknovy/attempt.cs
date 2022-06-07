using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logiknovy
{
    public class attempt
    {
        public pin[] Pins { get; internal set; }

        public attempt()
        {
            Pins = new pin[4];
        }

        public List<bool> Evaluate(pin[] pattern)
        {
            List<bool> result = new List<bool>();
            bool[] flag = new bool[4];

            for (int i = 0; i < pattern.Length; i++)
            {
                if(pattern[i] == Pins[i])
                {
                    flag[i] = false;
                    result.Add(true);
                }
                else
                {
                    flag[i] = true;
                }

            }
            for(int i = 0; i < flag.Length; i++)
            {
                if (flag[i])
                {
                    for(int j = 0; j < pattern.Length; j++)
                    {
                        if (flag[j])
                        {
                            if(Pins[i] == pattern[j])
                            {
                                result.Add(false);
                                break;
                            }
                        }
                    }
                }
            }
            
            return new List<bool>();
        }
    }
}
