#include "stdafx.h"
#include "cwPandoraUIApp.h"

void cwPandoraUIApp::Run(const char* pszMdFront, const char* pszTradeFront)
{
	this->m_TradeChannel.RegisterBasicStrategy(dynamic_cast<cwBasicStrategy*>(&(this->m_cwPandoraUIStategy)));

	this->m_mdCollector.RegisterTradeSPI(dynamic_cast<cwBasicTradeSpi*>(&(this->m_TradeChannel)));
	this->m_mdCollector.RegisterStrategy(dynamic_cast<cwBasicStrategy*>(&(this->m_cwPandoraUIStategy)));

	this->m_TradeChannel.SetSaveInstrumentDataToFile(true);

	if (pszTradeFront != NULL
		&& strlen(pszTradeFront) > 0)
	{
		this->m_TradeChannel.Connect(pszTradeFront);
	}

	if (pszMdFront != NULL
		&& strlen(pszMdFront) > 0)
	{
		this->m_mdCollector.Connect(pszMdFront);
	}

	std::vector<std::string> SubscribeInstrument;
	SubscribeInstrument.push_back("ag2012");
	this->m_mdCollector.SubscribeMarketData(SubscribeInstrument);
}
