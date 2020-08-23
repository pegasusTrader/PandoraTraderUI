#include "stdafx.h"
#include "cwPandoraUIStrategy.h"

void cwPandoraUIStrategy::PriceUpdate(cwMarketDataPtr pPriceData)
{
	if (m_fpPriceUpdateCallBackUI != NULL)
	{
		((PriceUpdateCallBackUI)m_fpPriceUpdateCallBackUI)((cwFtdcDepthMarketDataField*)(pPriceData.get()));
	}
}
