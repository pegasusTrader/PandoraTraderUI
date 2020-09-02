using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;

namespace PandoraUIStrategy
{
    class cwPandoraUIApp
    {
        #region Pandora Dll Interface
        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32", EntryPoint = "FreeLibrary", SetLastError = true)]
        private static extern bool FreeLibrary(IntPtr hModule);

        private static Delegate Invoke(IntPtr pHModule, string lpProcName, Type t)
        {
            // 若函数库模块的句柄为空，则抛出异常
            if (pHModule == IntPtr.Zero)
            {
                throw (new Exception(" Pandora Dll 未载入!"));
            }
            // 取得函数指针
            IntPtr farProc = GetProcAddress(pHModule, lpProcName);
            // 若函数指针，则抛出异常
            if (farProc == IntPtr.Zero)
            {
                throw (new Exception(" 没有找到 :" + lpProcName + " 这个函数 "));
            }
            return Marshal.GetDelegateForFunctionPointer(farProc, t);
        }
        #endregion


        #region PandoraUI APP Intial Interface
        IntPtr _handle = IntPtr.Zero, _pApp = IntPtr.Zero;

        delegate IntPtr CreatecwPandoraUIApp();

        public cwPandoraUIApp()
        {
            string curPath = Environment.CurrentDirectory;
            var dll_path = new FileInfo(this.GetType().Assembly.Location).DirectoryName;
            Environment.CurrentDirectory = dll_path;
            dll_path = Path.Combine(dll_path, "PandoraDLL.dll");
            _handle = LoadLibrary(dll_path);
            if (_handle == IntPtr.Zero)
            {
                throw (new Exception(String.Format("没有找到:", dll_path)));
            }
            Environment.CurrentDirectory = curPath;

            _pApp = (Invoke(_handle, "CreatecwPandoraUIApp", typeof(CreatecwPandoraUIApp)) as CreatecwPandoraUIApp)();
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        delegate void ReleasePandoraUIApp(IntPtr p);
        ~cwPandoraUIApp()
        {
            if (_pApp != IntPtr.Zero)
            {
                (Invoke(_handle, "ReleasePandoraUIApp", typeof(ReleasePandoraUIApp)) as ReleasePandoraUIApp)(_pApp);
            }

            FreeLibrary(_handle);
            _handle = IntPtr.Zero;
        }

        //App initial interface:
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate IntPtr DeleSetMdLoginField(IntPtr pApp, string strBrokerID, string strUserID, string strPassword);
        public IntPtr SetMdLoginField(string strBrokerID, string strUserID, string strPassword)
        {
            return (Invoke(_handle, "SetMdLoginField", typeof(DeleSetMdLoginField)) as DeleSetMdLoginField)(_pApp, strBrokerID, strUserID, strPassword);
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate IntPtr DeleSetTradeLoginField(IntPtr pApp, string strBrokerID, string strUserID, string strPassword);
        public IntPtr SetTradeLoginField(string strBrokerID, string strUserID, string strPassword)
        {
            return (Invoke(_handle, "SetTradeLoginField", typeof(DeleSetTradeLoginField)) as DeleSetTradeLoginField)(_pApp, strBrokerID, strUserID, strPassword);
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate IntPtr DeleSetAuthenticateInfo(IntPtr pApp, string strAppID, string strAuthCode);
        public IntPtr SetAuthenticateInfo(string strAppID, string strAuthCode)
        {
            return (Invoke(_handle, "SetAuthenticateInfo", typeof(DeleSetAuthenticateInfo)) as DeleSetAuthenticateInfo)(_pApp, strAppID, strAuthCode);
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate IntPtr DelePandoraAppRun(IntPtr pApp, string strMdFront, string strTradeFront);
        public IntPtr PandoraAppRun(string strMdFront, string strTradeFront)
        {
            return (Invoke(_handle, "PandoraAppRun", typeof(DelePandoraAppRun)) as DelePandoraAppRun)(_pApp, strMdFront, strTradeFront);
        }

        //Call Back
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate void DeleSetCallBack(IntPtr pApp, Delegate func);
 
        //[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate void DeleOnRtnDepthMarketData(ref cwFtdcDepthMarketDataField pDepthMarketData);
        public void SetOnPriceUpdateCallBack(DeleOnRtnDepthMarketData func) { (Invoke(_handle, "SetPriceUpdateCallBack", typeof(DeleSetCallBack)) as DeleSetCallBack)(_pApp, func); }

        //[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate void DeleOnRtnOrder(ref cwFtdcOrderField pOrder, ref cwFtdcOrderField pOriginOrder);
        public void SetOnRtnOrderCallBack(DeleOnRtnOrder func) { (Invoke(_handle, "SetOnRtnOrderCallBack", typeof(DeleSetCallBack)) as DeleSetCallBack)(_pApp, func); }

        //[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate void DeleOnRtnTrade(ref cwFtdcTradeField pTrade);
        public void SetOnRtnTradeCallBack(DeleOnRtnTrade func) { (Invoke(_handle, "SetOnRtnTradeCallBack", typeof(DeleSetCallBack)) as DeleSetCallBack)(_pApp, func); }
       
        //Quotes

        //Trade
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate IntPtr DelePandoraGetAccount(IntPtr pApp);
        public IntPtr PandoraGetAccount()
        {
            return (Invoke(_handle, "GetAccount", typeof(DelePandoraGetAccount)) as DelePandoraGetAccount)(_pApp);
        }

      
        #endregion

    }
}
