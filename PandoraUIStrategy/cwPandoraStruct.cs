using System.Runtime.InteropServices;


namespace PandoraUIStrategy
{
  
	/// <summary>
	/// 深度行情
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct CThostFtdcDepthMarketDataField
	{
		/// <summary>
		/// 交易日
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
		public string TradingDay;
		/// <summary>
		/// 合约代码
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
		public string InstrumentID;
		/// <summary>
		/// 交易所代码
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
		public string ExchangeID;
		/// <summary>
		/// 合约在交易所的代码
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
		public string ExchangeInstID;
		/// <summary>
		/// 最新价
		/// </summary>
		public double LastPrice;
		/// <summary>
		/// 上次结算价
		/// </summary>
		public double PreSettlementPrice;
		/// <summary>
		/// 昨收盘
		/// </summary>
		public double PreClosePrice;
		/// <summary>
		/// 昨持仓量
		/// </summary>
		public double PreOpenInterest;
		/// <summary>
		/// 今开盘
		/// </summary>
		public double OpenPrice;
		/// <summary>
		/// 最高价
		/// </summary>
		public double HighestPrice;
		/// <summary>
		/// 最低价
		/// </summary>
		public double LowestPrice;
		/// <summary>
		/// 数量
		/// </summary>
		public int Volume;
		/// <summary>
		/// 成交金额
		/// </summary>
		public double Turnover;
		/// <summary>
		/// 持仓量
		/// </summary>
		public double OpenInterest;
		/// <summary>
		/// 今收盘
		/// </summary>
		public double ClosePrice;
		/// <summary>
		/// 本次结算价
		/// </summary>
		public double SettlementPrice;
		/// <summary>
		/// 涨停板价
		/// </summary>
		public double UpperLimitPrice;
		/// <summary>
		/// 跌停板价
		/// </summary>
		public double LowerLimitPrice;
		/// <summary>
		/// 昨虚实度
		/// </summary>
		public double PreDelta;
		/// <summary>
		/// 今虚实度
		/// </summary>
		public double CurrDelta;
		/// <summary>
		/// 最后修改时间
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
		public string UpdateTime;
		/// <summary>
		/// 最后修改毫秒
		/// </summary>
		public int UpdateMillisec;
		/// <summary>
		/// 申买价一
		/// </summary>
		public double BidPrice1;
		/// <summary>
		/// 申买量一
		/// </summary>
		public int BidVolume1;
		/// <summary>
		/// 申卖价一
		/// </summary>
		public double AskPrice1;
		/// <summary>
		/// 申卖量一
		/// </summary>
		public int AskVolume1;
		/// <summary>
		/// 申买价二
		/// </summary>
		public double BidPrice2;
		/// <summary>
		/// 申买量二
		/// </summary>
		public int BidVolume2;
		/// <summary>
		/// 申卖价二
		/// </summary>
		public double AskPrice2;
		/// <summary>
		/// 申卖量二
		/// </summary>
		public int AskVolume2;
		/// <summary>
		/// 申买价三
		/// </summary>
		public double BidPrice3;
		/// <summary>
		/// 申买量三
		/// </summary>
		public int BidVolume3;
		/// <summary>
		/// 申卖价三
		/// </summary>
		public double AskPrice3;
		/// <summary>
		/// 申卖量三
		/// </summary>
		public int AskVolume3;
		/// <summary>
		/// 申买价四
		/// </summary>
		public double BidPrice4;
		/// <summary>
		/// 申买量四
		/// </summary>
		public int BidVolume4;
		/// <summary>
		/// 申卖价四
		/// </summary>
		public double AskPrice4;
		/// <summary>
		/// 申卖量四
		/// </summary>
		public int AskVolume4;
		/// <summary>
		/// 申买价五
		/// </summary>
		public double BidPrice5;
		/// <summary>
		/// 申买量五
		/// </summary>
		public int BidVolume5;
		/// <summary>
		/// 申卖价五
		/// </summary>
		public double AskPrice5;
		/// <summary>
		/// 申卖量五
		/// </summary>
		public int AskVolume5;
		/// <summary>
		/// 当日均价
		/// </summary>
		public double AveragePrice;
		/// <summary>
		/// 业务日期
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
		public string ActionDay;
	}
}
