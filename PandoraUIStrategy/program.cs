using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandoraUIStrategy
{
    class program
    {
        private readonly List<Delegate> _listDele = new List<Delegate>();


        public static cwPandoraUIApp TheApp = null;


        static void Main(string[] args)
        {
            TheApp = new cwPandoraUIApp();

            TheApp.SetMdLoginField("9999", "042792", "123456");
            TheApp.SetTradeLoginField("9999", "042792", "123456");
            TheApp.PandoraAppRun("tcp://180.168.146.187:10131", "tcp://180.168.146.187:10130");

            while(true)
            {
                
            }
        }
    }
}
