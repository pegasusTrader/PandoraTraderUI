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
            //_handle = LoadLibrary(Path.Combine(dll_path, "PandoraDLL.dll"));
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
        public delegate IntPtr DealSetMdLoginField(IntPtr pApp, string strBrokerID, string strUserID, string strPassword);
        public IntPtr SetMdLoginField(string strBrokerID, string strUserID, string strPassword)
        {
            return (Invoke(_handle, "SetMdLoginField", typeof(DealSetMdLoginField)) as DealSetMdLoginField)(_pApp, strBrokerID, strUserID, strPassword);
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate IntPtr DealSetTradeLoginField(IntPtr pApp, string strBrokerID, string strUserID, string strPassword);
        public IntPtr SetTradeLoginField(string strBrokerID, string strUserID, string strPassword)
        {
            return (Invoke(_handle, "SetTradeLoginField", typeof(DealSetTradeLoginField)) as DealSetTradeLoginField)(_pApp, strBrokerID, strUserID, strPassword);
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate IntPtr DealSetAuthenticateInfo(IntPtr pApp, string strAppID, string strAuthCode);
        public IntPtr SetAuthenticateInfo(string strAppID, string strAuthCode)
        {
            return (Invoke(_handle, "SetAuthenticateInfo", typeof(DealSetAuthenticateInfo)) as DealSetAuthenticateInfo)(_pApp, strAppID, strAuthCode);
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate IntPtr DealPandoraAppRun(IntPtr pApp, string strMdFront, string strTradeFront);
        public IntPtr PandoraAppRun(string strMdFront, string strTradeFront)
        {
            return (Invoke(_handle, "PandoraAppRun", typeof(DealPandoraAppRun)) as DealPandoraAppRun)(_pApp, strMdFront, strTradeFront);
        }

        //Quotes
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        delegate void DeleSet(IntPtr spi, Delegate func);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate void DeleOnRtnDepthMarketData(ref CThostFtdcDepthMarketDataField pDepthMarketData);

        public void SetOnRtnDepthMarketData(DeleOnRtnDepthMarketData func) { (Invoke(_handle, "SetPriceUpdateCallBack", typeof(DeleSet)) as DeleSet)(_pApp, func); }

        //Trade


        #endregion

    }
}
