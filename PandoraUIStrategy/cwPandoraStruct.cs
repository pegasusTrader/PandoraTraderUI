using System.Runtime.InteropServices;


namespace PandoraUIStrategy
{
	/// 买卖方向类型
	public enum cwFtdcDirectionType : byte
	{
		/// 卖
		CW_FTDC_D_Sell = (byte)'1',
		/// 买
		CW_FTDC_D_Buy = (byte)'0'
	}

	///报单价格条件类型
	public enum cwFtdcOrderPriceType : byte
	{
		///任意价
		CW_FTDC_OPT_AnyPrice = (byte)'1',
		///限价
		CW_FTDC_OPT_LimitPrice = (byte)'2',
		///最优价
		CW_FTDC_OPT_BestPrice = (byte)'3',
		///最新价
		CW_FTDC_OPT_LastPrice = (byte)'4',
		///最新价浮动上浮1个ticks
		CW_FTDC_OPT_LastPricePlusOneTicks = (byte)'5',
		///最新价浮动上浮2个ticks
		CW_FTDC_OPT_LastPricePlusTwoTicks = (byte)'6',
		///最新价浮动上浮3个ticks
		CW_FTDC_OPT_LastPricePlusThreeTicks = (byte)'7',
		///卖一价
		CW_FTDC_OPT_AskPrice1 = (byte)'8',
		///卖一价浮动上浮1个ticks
		CW_FTDC_OPT_AskPrice1PlusOneTicks = (byte)'9',
		///卖一价浮动上浮2个ticks
		CW_FTDC_OPT_AskPrice1PlusTwoTicks = (byte)'A',
		///卖一价浮动上浮3个ticks
		CW_FTDC_OPT_AskPrice1PlusThreeTicks = (byte)'B',
		///买一价
		CW_FTDC_OPT_BidPrice1 = (byte)'C',
		///买一价浮动上浮1个ticks
		CW_FTDC_OPT_BidPrice1PlusOneTicks = (byte)'D',
		///买一价浮动上浮2个ticks
		CW_FTDC_OPT_BidPrice1PlusTwoTicks = (byte)'E',
		///买一价浮动上浮3个ticks
		CW_FTDC_OPT_BidPrice1PlusThreeTicks = (byte)'F',
		///五档价
		CW_FTDC_OPT_FiveLevelPrice = (byte)'G'
	}

	///有效期类型类型
	public enum cwFtdcTimeConditionType : byte
	{
		//立即完成，否则撤销
		CW_FTDC_TC_IOC = (byte)'1',
		//本节有效
		CW_FTDC_TC_GFS = (byte)'2',
		//当日有效
		CW_FTDC_TC_GFD = (byte)'3',
		//指定日期前有效
		CW_FTDC_TC_GTD = (byte)'4',
		//撤销前有效
		CW_FTDC_TC_GTC = (byte)'5',
		//集合竞价有效
		CW_FTDC_TC_GFA = (byte)'6'
	}

	///成交量类型类型
	public enum cwFtdcVolumeConditionType : byte
	{
		///任何数量
		CW_FTDC_VC_AV = (byte)'1',
		///最小数量
		CW_FTDC_VC_MV = (byte)'2',
		///全部数量
		CW_FTDC_VC_CV = (byte)'3'
	}

    ///触发条件类型
    public enum cwFtdcContingentConditionType : byte
    {
		///立即
		CW_FTDC_CC_Immediately = (byte)'1',
		///止损
		CW_FTDC_CC_Touch = (byte)'2',
		///止赢
		CW_FTDC_CC_TouchProfit = (byte)'3',
		///预埋单
		CW_FTDC_CC_ParkedOrder = (byte)'4',
		///最新价大于条件价
		CW_FTDC_CC_LastPriceGreaterThanStopPrice = (byte)'5',
		///最新价大于等于条件价
		CW_FTDC_CC_LastPriceGreaterEqualStopPrice = (byte)'6',
		///最新价小于条件价
		CW_FTDC_CC_LastPriceLesserThanStopPrice = (byte)'7',
		///最新价小于等于条件价
		CW_FTDC_CC_LastPriceLesserEqualStopPrice = (byte)'8',
		///卖一价大于条件价
		CW_FTDC_CC_AskPriceGreaterThanStopPrice = (byte)'9',
		///卖一价大于等于条件价
		CW_FTDC_CC_AskPriceGreaterEqualStopPrice = (byte)'A',
		///卖一价小于条件价
		CW_FTDC_CC_AskPriceLesserThanStopPrice = (byte)'B',
		///卖一价小于等于条件价
		CW_FTDC_CC_AskPriceLesserEqualStopPrice = (byte)'C',
		///买一价大于条件价
		CW_FTDC_CC_BidPriceGreaterThanStopPrice = (byte)'D',
		///买一价大于等于条件价
		CW_FTDC_CC_BidPriceGreaterEqualStopPrice = (byte)'E',
		///买一价小于条件价
		CW_FTDC_CC_BidPriceLesserThanStopPrice = (byte)'F',
		///买一价小于等于条件价
		CW_FTDC_CC_BidPriceLesserEqualStopPrice = (byte)'H'
	}

	///强平原因类型
	public enum cwFtdcForceCloseReasonType : byte
	{
        ///非强平
        CW_FTDC_FCC_NotForceClose = (byte)'0',
        ///资金不足
        CW_FTDC_FCC_LackDeposit = (byte)'1',
        ///客户超仓
        CW_FTDC_FCC_ClientOverPositionLimit = (byte)'2',
        ///会员超仓
        CW_FTDC_FCC_MemberOverPositionLimit = (byte)'3',
        ///持仓非整数倍
        CW_FTDC_FCC_NotMultiple = (byte)'4',
        ///违规
        CW_FTDC_FCC_Violation = (byte)'5',
        ///其它
        CW_FTDC_FCC_Other = (byte)'6',
        ///自然人临近交割
        CW_FTDC_FCC_PersonDeliv = (byte)'7'
    }

	///报单提交状态类型
	public enum cwFtdcOrderSubmitStatusType : byte
	{
		///已经提交
		CW_FTDC_OSS_InsertSubmitted = (byte)'0',
		///撤单已经提交
		CW_FTDC_OSS_CancelSubmitted = (byte)'1',
		///修改已经提交
		CW_FTDC_OSS_ModifySubmitted = (byte)'2',
		///已经接受
		CW_FTDC_OSS_Accepted = (byte)'3',
		///报单已经被拒绝
		CW_FTDC_OSS_InsertRejected = (byte)'4',
		///撤单已经被拒绝
		CW_FTDC_OSS_CancelRejected = (byte)'5',
		///改单已经被拒绝
		CW_FTDC_OSS_ModifyRejected = (byte)'6'
	}

	///报单来源类型
	public enum cwFtdcOrderSourceType : byte
	{
		///来自参与者
		CW_FTDC_OSRC_Participant = (byte)'0',
		///来自管理员
		CW_FTDC_OSRC_Administrator = (byte)'1'
	}

	///报单状态类型
	public enum cwFtdcOrderStatusType : byte
	{
		//全部成交
		CW_FTDC_OST_AllTraded = (byte)'0',
		//部分成交还在队列中
		CW_FTDC_OST_PartTradedQueueing = (byte)'1',
		//部分成交不在队列中
		CW_FTDC_OST_PartTradedNotQueueing = (byte)'2',
		//未成交还在队列中
		CW_FTDC_OST_NoTradeQueueing = (byte)'3',
		//未成交不在队列中
		CW_FTDC_OST_NoTradeNotQueueing = (byte)'4',
		//撤单
		CW_FTDC_OST_Canceled = (byte)'5',
		//订单已报入交易所未应答
		CW_FTDC_OST_AcceptedNoReply = (byte)'6',
		//未知
		CW_FTDC_OST_Unknown = (byte)'a',
		//尚未触发
		CW_FTDC_OST_NotTouched = (byte)'b',
		//已触发
		CW_FTDC_OST_Touched = (byte)'c',
		//Default
		CW_FTDC_OST_cwDefault = (byte)' '
	}

	///报单类型类型
	public enum cwFtdcOrderTypeType : byte
	{
		///正常
		CW_FTDC_ORDT_Normal = (byte)'0',
		///报价衍生
		CW_FTDC_ORDT_DeriveFromQuote = (byte)'1',
		///组合衍生
		CW_FTDC_ORDT_DeriveFromCombination = (byte)'2',
		///组合报单
		CW_FTDC_ORDT_Combination = (byte)'3',
		///条件单
		CW_FTDC_ORDT_ConditionalOrder = (byte)'4',
		///互换单
		CW_FTDC_ORDT_Swap = (byte)'5'
	}

	///开平标志类型
	public enum cwFtdcOffsetFlagType : byte
	{
		///开仓
		CW_FTDC_OF_Open = (byte)'0',
		///平仓
		CW_FTDC_OF_Close = (byte)'1',
		///强平
		CW_FTDC_OF_ForceClose = (byte)'2',
		///平今
		CW_FTDC_OF_CloseToday = (byte)'3',
		///平昨
		CW_FTDC_OF_CloseYesterday = (byte)'4',
		///强减
		CW_FTDC_OF_ForceOff = (byte)'5',
		///本地强平
		CW_FTDC_OF_LocalForceClose = (byte)'6'
	}
	///投机套保标志类型
	public enum cwFtdcHedgeFlagType : byte
    {
        //投机
        CW_FTDC_HF_Speculation = (byte)'1',
        //套利
        CW_FTDC_HF_Arbitrage = (byte)'2',
		//套保
		CW_FTDC_HF_Hedge = (byte)'3',
		//做市商
		CW_FTDC_HF_MarketMaker = (byte)'5'

	}
	///成交类型类型
	public enum cwFtdcTradeTypeType : byte
	{
        ///组合持仓拆分为单一持仓,初始化不应包含该类型的持仓
        CW_FTDC_TRDT_SplitCombination = (byte)'#',
        ///普通成交
        CW_FTDC_TRDT_Common = (byte)'0',
        ///期权执行
        CW_FTDC_TRDT_OptionsExecution = (byte)'1',
        ///OTC成交
        CW_FTDC_TRDT_OTC = (byte)'2',
        ///期转现衍生成交
        CW_FTDC_TRDT_EFPDerived = (byte)'3',
        ///组合衍生成交
        CW_FTDC_TRDT_CombinationDerived = (byte)'4'
    }

	///成交价来源类型
	public enum cwFtdcPriceSourceType : byte
	{
		///前成交价
		CW_FTDC_PSRC_LastPrice = (byte)'0',
		///买委托价
		CW_FTDC_PSRC_Buy = (byte)'1',
		///卖委托价
		CW_FTDC_PSRC_Sell = (byte)'2'
	}

	///成交来源类型
	public enum cwFtdcTradeSourceType : byte
	{
		///来自交易所普通回报
		CW_FTDC_TSRC_NORMAL = (byte)'0',
		///来自查询
		CW_FTDC_TSRC_QUERY = (byte)'1'
	}

	///成交来源类型
	public enum cwUserCanceleStatus : System.UInt32
	{
		///
		cwUserCancel_NoCancel = 0,
		///
		cwUserCancel_ReqCancel = 1,
		///
		cwUserCancel_Canceled
	}

	/// 深度行情
	[StructLayout(LayoutKind.Sequential)]
    public struct cwFtdcDepthMarketDataField
	{
		/// 交易所代码
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
		public string ExchangeID;

		/// 交易日
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
		public string TradingDay;

		/// 业务日期
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
		public string ActionDay;

		/// 最后修改时间
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
		public string UpdateTime;

		/// 最后修改毫秒
		public System.Int32 UpdateMillisec;

		/// 合约代码
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string InstrumentID;

		/// 申买价一
		public double BidPrice1;
		/// 申买量一
		public System.Int32 BidVolume1;
		/// 申买价二
		public double BidPrice2;
		/// 申买量二
		public System.Int32 BidVolume2;
		/// 申买价三
		public double BidPrice3;
		/// 申买量三
		public System.Int32 BidVolume3;
		/// 申买价四
		public double BidPrice4;
		/// 申买量四
		public System.Int32 BidVolume4;
		/// 申买价五
		public double BidPrice5;
		/// 申买量五
		public System.Int32 BidVolume5;

		/// 申卖价一
		public double AskPrice1;
		/// 申卖量一
		public System.Int32 AskVolume1;
		/// 申卖价二
		public double AskPrice2;
		/// 申卖量二
		public System.Int32 AskVolume2;
		/// 申卖价三
		public double AskPrice3;
		/// 申卖量三
		public System.Int32 AskVolume3;
		/// 申卖价四
		public double AskPrice4;
		/// 申卖量四
		public System.Int32 AskVolume4;
		/// 申卖价五
		public double AskPrice5;
		/// 申卖量五
		public System.Int32 AskVolume5;

		/// 最新价
		public double LastPrice;
		/// 上次结算价
		public double PreSettlementPrice;
		/// 昨收盘
		public double PreClosePrice;
		/// 昨持仓量
		public double PreOpenInterest;
		/// 昨虚实度
		public double PreDelta;

		/// 数量
		public System.Int64 Volume;
		/// 成交金额
		public double Turnover;
		/// 持仓量
		public double OpenInterest;

		/// 今开盘
		public double OpenPrice;
		/// 最高价
		public double HighestPrice;
		/// 最低价
		public double LowestPrice;
		/// 今收盘
		public double ClosePrice;
		/// 本次结算价
		public double SettlementPrice;
		/// 涨停板价
		public double UpperLimitPrice;
		/// 跌停板价
		public double LowerLimitPrice;
		/// 今虚实度
		public double CurrDelta;

		/// 当日均价
		//public double AveragePrice;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct cwFtdcAccountField
	{
		///投资者帐号
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
		public string AccountID;
		///上次结算准备金
		public double PreBalance;
		///入金金额
		public double Deposit;
		///出金金额
		public double Withdraw;
		///当前保证金总额
		public double CurrMargin;
		///手续费
		public double Commission;
		///冻结的保证金
		public double FrozenMargin;
		///冻结的手续费
		public double FrozenCommission;
		///平仓盈亏
		public double CloseProfit;
		///持仓盈亏
		public double PositionProfit;
		///期货结算准备金
		public double Balance;
		///可用资金
		public double Available;
	}

    [StructLayout(LayoutKind.Sequential)]
	public struct cwFtdcOrderField
	{
		///经纪公司代码
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
		public string BrokerID;
		///投资者代码
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 19)]
		public string InvestorID;
		///合约代码
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string InstrumentID;
		///报单引用
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 23)]
		public string OrderRef;
		///用户代码
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
		public string UserID;
		///买卖方向
		public cwFtdcDirectionType Direction;
		///组合开平标志
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
		public string CombOffsetFlag;
		///组合投机套保标志
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
		public string CombHedgeFlag;
		///价格
		public double LimitPrice;
		///数量
		public System.Int32 VolumeTotalOriginal;
		///最小成交量
		public System.Int32 MinVolume;
		///报单价格条件
		public cwFtdcOrderPriceType OrderPriceType;
		///有效期类型
		public cwFtdcTimeConditionType TimeCondition;
		///GTD日期
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
		public string GTDDate;
		///成交量类型
		public cwFtdcVolumeConditionType VolumeCondition;
		///触发条件
		public cwFtdcContingentConditionType ContingentCondition;
		///强平原因
		cwFtdcForceCloseReasonType ForceCloseReason;
		///本地报单编号
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
		public string OrderLocalID;
		///交易所代码
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
		public string ExchangeID;
		///客户代码
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 19)]
		public string ClientID;
		///报单提交状态
		public cwFtdcOrderSubmitStatusType OrderSubmitStatus;
		///报单来源
		public cwFtdcOrderSourceType OrderSource;
		///报单状态
		cwFtdcOrderStatusType OrderStatus;
		///止损价
		public double StopPrice;
		///交易日
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
		public string TradingDay;
		///报单编号
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
		public string OrderSysID;
		///今成交数量
		public System.Int32 VolumeTraded;
		///剩余数量
		public System.Int32 VolumeTotal;
		///报单日期
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
		public string InsertDate;
		///委托时间
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
		public string InsertTime;
		///激活时间
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
		public string ActiveTime;
		///挂起时间
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
		public string SuspendTime;
		///最后修改时间
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
		public string UpdateTime;
		///撤销时间
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
		public string CancelTime;
		///用户端产品信息
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
		public string UserProductInfo;
		///状态信息
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 87)]
		public string StatusMsg;
		///相关报单
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
		public string RelativeOrderSysID;
		///报单类型
		public cwFtdcOrderTypeType OrderType;
		///结算编号
		public System.UInt32 SettlementID;
		///前置编号
		public System.UInt32 FrontID;
		///会话编号
		public System.UInt32 SessionID;
		///用户强评标志
		public System.UInt32 UserForceClose;
		///Mac地址
		//cwFtdcMacAddressType				MacAddress;
		///IP地址
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
		public string IPAddress;
		///币种代码
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
		public string CurrencyID;

		cwUserCanceleStatus UserCancelStatus;
		public System.UInt32 UserCancelTime;
		// Add From PlatForm
		public System.Int32 iRanked;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct cwFtdcTradeField
	{
		///经纪公司代码
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
		public string BrokerID;
		///投资者代码
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 19)]
		public string InvestorID;
		///合约代码
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string InstrumentID;
		///报单引用
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 23)]
		public string OrderRef;
		///用户代码
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
		public string UserID;
		///交易所代码
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
		public string ExchangeID;
		///成交编号
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
		public string TradeID;
		///买卖方向
		public cwFtdcDirectionType Direction;
		///报单编号
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
		public string OrderSysID;
		///客户代码
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 19)]
		public string ClientID;
		///价格
		public double LimitPrice;
		///数量
		public System.Int32 Volume;
		///开平标志
		public cwFtdcOffsetFlagType OffsetFlag;
		///投机套保标志
		public cwFtdcHedgeFlagType HedgeFlag;
		///成交时期
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
		public string TradeDate;
		///成交时间
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
		public string TradeTime;
		///成交类型
		public cwFtdcTradeTypeType TradeType;
		///成交来源
		public cwFtdcTradeSourceType TradeSource;
		///交易所交易员代码
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
		public string TraderID;
		///本地报单编号
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
		public string OrderLocalID;
	}
}