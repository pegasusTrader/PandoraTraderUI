using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;

namespace PandoraUIStrategy
{
    class program
    {


        public static cwPandoraUIApp TheApp = null;

        private static void CTPOnRtnDepthMarketData(ref cwFtdcDepthMarketDataField pDepthMarketData)
        {
            Console.WriteLine("{0} {1} {2}", pDepthMarketData.UpdateTime, pDepthMarketData.InstrumentID, pDepthMarketData.LastPrice);
        }

        static void Main(string[] args)
        {
            TheApp = new cwPandoraUIApp();

            TheApp.SetOnPriceUpdateCallBack((cwPandoraUIApp.DeleOnRtnDepthMarketData)(CTPOnRtnDepthMarketData));

            TheApp.SetMdLoginField("9999", "", "");
            TheApp.SetTradeLoginField("9999", "", "");
            TheApp.PandoraAppRun("tcp://180.168.146.187:10131", "tcp://180.168.146.187:10130");

            
            while(true)
            {
                IntPtr pAccount = TheApp.PandoraGetAccount();
                
                if (pAccount == IntPtr.Zero)
                {
                    continue;
                }
                cwFtdcAccountField accountField = (cwFtdcAccountField)Marshal.PtrToStructure(pAccount, typeof(cwFtdcAccountField));
                Console.WriteLine("{0} {1} {2}",
                    accountField.AccountID, 
                    accountField.Balance,
                    accountField.Available);

                Int32 iCount = 0;
                IntPtr pPositions = TheApp.PandoraGetPositions(ref iCount);

                Console.WriteLine("Positions: {0} ", iCount);

                for (int i = 0; i < iCount; i++)
                {
                    IntPtr pPos = (IntPtr)Marshal.PtrToStructure(pPositions + i * Marshal.SizeOf(pPositions), typeof(IntPtr));
                    if (pPos != IntPtr.Zero)
                    {
                        cwFtdcPositionField Position = (cwFtdcPositionField)Marshal.PtrToStructure(pPos, typeof(cwFtdcPositionField));
                        if (Position.TotalPosition > 0)
                        {
                            Console.WriteLine("{0} {1} {2}",
                                Position.InstrumentID,
                                Position.TotalPosition,
                                Position.PosiDirection == cwFtdcDirectionType.CW_FTDC_D_Buy ? "B" : "S");
                        }
                    }
                }

                Thread.Sleep(1000);
            }
        }
    }
}
