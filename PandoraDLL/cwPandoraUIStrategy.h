#pragma once
#include "cwBasicKindleStrategy.h"

class cwPandoraUIStrategy :
    public cwBasicKindleStrategy
{
public:
    typedef int (WINAPI* PriceUpdateCallBackUI)(cwFtdcDepthMarketDataField * pDepthMarketData);
    void *                  m_fpPriceUpdateCallBackUI;

    virtual void			PriceUpdate(cwMarketDataPtr pPriceData);

};

