#pragma once
#include "cwBasicKindleStrategy.h"
#include "cwBasicCout.h"

class cwPandoraUIStrategy :
    public cwBasicKindleStrategy
{
public:

	//行情更新（PriceUpdate回调会先于OnBar， 在PriceUpdate已经可以获取更新好的K线）
    virtual void			PriceUpdate(cwMarketDataPtr pPriceData);
	typedef int (WINAPI* PriceUpdateCallBackUI)(cwFtdcDepthMarketDataField* pDepthMarketData);
	void* m_fpPriceUpdateCallBackUI;

	
	//当生成一根新K线的时候，会调用该回调
	virtual void			OnBar(std::string InstrumentID, int iTimeScale, cwBasicKindleStrategy::cwKindleSeriesPtr pKindle) {};

	///Trade SPI
	//成交回报
	virtual void			OnRtnTrade(cwTradePtr pTrade);
	typedef int (WINAPI* RtnTradeCallBackUI)(TRADEFIELD* pDepthMarketData);
	void* m_fpRtnTradeCallBackUI;

	//报单回报, pOrder为最新报单，pOriginOrder为上一次更新报单结构体，有可能为NULL
	virtual void			OnRtnOrder(cwOrderPtr pOrder, cwOrderPtr pOriginOrder = cwOrderPtr());
	typedef int (WINAPI* RtnOrderCallBackUI)(ORDERFIELD* pOrder, ORDERFIELD* pOriginOrder);
	void* m_fpRtnOrderCallBackUI;


	//撤单成功
	virtual void			OnOrderCanceled(cwOrderPtr pOrder) {};
	//报单录入请求响应
	virtual void			OnRspOrderInsert(cwOrderPtr pOrder, cwRspInfoPtr pRspInfo) {};
	//报单操作请求响应
	virtual void			OnRspOrderCancel(cwOrderPtr pOrder, cwRspInfoPtr pRspInfo) {};

	///System Call Back
	//定时器响应
	virtual void			OnStrategyTimer(int iTimerId) {};
	//当策略交易初始化完成时会调用OnReady, 可以在此函数做策略的初始化操作
	virtual void			OnReady() {};

	cwBasicCout				m_cwShow;
};

