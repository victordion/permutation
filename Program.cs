using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    public class StringListChangedEventArgs : EventArgs
    {
        public string str;
    }
    class Perm
    {
        public event EventHandler<StringListChangedEventArgs> RetChanged;
        StringListChangedEventArgs args = new StringListChangedEventArgs();
        protected virtual void OnRetChanged(string str)
        {
            if (RetChanged != null)
            {
                args.str = str;
                RetChanged(this, args);
            }
        }

        public void print(object sender, StringListChangedEventArgs args)
        {
            Console.WriteLine("Event is raised");
            Console.WriteLine(args.str);
        }

        public void doPerm(List<string> ret, string curr, string str)
        {
            if (str.Length == 0)
            {
                ret.Add(curr);
                OnRetChanged(curr);
            }
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    doPerm(ret, curr + str[i], str.Substring(0, i) + str.Substring(i + 1));
                }
            }

            return;

        }
    }

    class Program
    {
       

        static void Main(string[] args)
        {
            List<string> ret = new List<string>();
            //public event EventHandler retChanged;
            Perm perm = new Perm();
            perm.RetChanged += perm.print;
            perm.doPerm(ret, "", "abcde");
            

            //foreach (string str in ret){
            //    Console.WriteLine(str);
            //}
                
        }

        

        
    }
}
