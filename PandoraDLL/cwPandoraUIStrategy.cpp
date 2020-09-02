#include "stdafx.h"
#include "cwPandoraUIStrategy.h"

void cwPandoraUIStrategy::PriceUpdate(cwMarketDataPtr pPriceData)
{
	if (m_fpPriceUpdateCallBackUI != NULL)
	{
		((PriceUpdateCallBackUI)m_fpPriceUpdateCallBackUI)((cwFtdcDepthMarketDataField*)(pPriceData.get()));
	}
}

void cwPandoraUIStrategy::OnRtnTrade(cwTradePtr pTrade)
{
	if (m_fpRtnTradeCallBackUI != NULL)
	{
		((RtnTradeCallBackUI)m_fpRtnTradeCallBackUI)((TRADEFIELD*)(pTrade.get()));
	}
}

void cwPandoraUIStrategy::OnRtnOrder(cwOrderPtr pOrder, cwOrderPtr pOriginOrder)
{
	if (m_fpRtnOrderCallBackUI != NULL)
	{
		((RtnOrderCallBackUI)m_fpRtnOrderCallBackUI)((ORDERFIELD*)(pOrder.get()), (ORDERFIELD*)(pOriginOrder.get()));
	}
}
