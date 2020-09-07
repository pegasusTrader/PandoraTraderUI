#include "stdafx.h"
#include "cwPandoraUIApp.h"

cwPandoraUIApp::cwPandoraUIApp()
	: m_ppOrder(NULL)
	, m_ipOrderCount(0)
	, m_ppPosition(NULL)
	, m_ipPositionCount(0)
	, m_ppTrade(NULL)
	, m_ipTradeCount(0)
{
}

cwPandoraUIApp::~cwPandoraUIApp()
{
	if (m_ppOrder != NULL)
	{
		delete[]m_ppOrder;
		m_ppOrder = NULL;
	}
	m_UIOrderMap.clear();

	if (m_ppPosition != NULL)
	{
		delete[] m_ppPosition;
		m_ppPosition = NULL;
	}
	m_UIPositionsMap.clear();

	if (m_ppTrade != NULL)
	{
		delete[] m_ppTrade;
		m_ppTrade = NULL;
	}
	m_UITradeMap.clear();
}

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

bool cwPandoraUIApp::GetUIAllOrders()
{
	bool Ret = m_cwPandoraUIStategy.GetAllOrders(m_UIOrderMap);

	if (m_UIOrderMap.size() > 0)
	{
		if ((int)m_UIOrderMap.size() > m_ipOrderCount)
		{
			m_ipOrderCount = (int)(m_UIOrderMap.size());

			if (m_ppOrder != NULL)
			{
				delete[]m_ppOrder;
			}
			m_ppOrder = new ORDERFIELD * [m_ipOrderCount];
		}

		memset(m_ppOrder, 0, sizeof(ORDERFIELD*) * m_ipOrderCount);

		int iCount = 0;
		for (auto it = m_UIOrderMap.begin();
			it != m_UIOrderMap.end(); it++, iCount++)
		{
			m_ppOrder[iCount] = it->second.get();
		}
	}
	return Ret;
}

bool cwPandoraUIApp::GetUIPositions()
{
	bool Ret = m_cwPandoraUIStategy.GetPositions(m_UIPositionsMap);
	
	if (m_UIPositionsMap.size() > 0)
	{
		if ((int)m_UIPositionsMap.size() * 2 > m_ipPositionCount)
		{
			m_ipPositionCount = (int)(m_UIPositionsMap.size()) * 2;

			if (m_ppPosition != NULL)
			{
				delete[]m_ppPosition;
			}
			m_ppPosition = new POSITIONFIELD * [m_ipPositionCount];
		}

		memset(m_ppPosition, 0, sizeof(POSITIONFIELD*) * m_ipPositionCount);

		int iCount = 0;
		for (auto it = m_UIPositionsMap.begin();
			it != m_UIPositionsMap.end(); it++, iCount++)
		{
			m_ppPosition[iCount * 2] = it->second->LongPosition.get();
			m_ppPosition[iCount * 2 + 1] = it->second->ShortPosition.get();
		}
	}

	return Ret;
}

bool cwPandoraUIApp::GetUIAllTrades()
{
	bool Ret = m_cwPandoraUIStategy.GetTrades(m_UITradeMap);

	if (m_UITradeMap.size() > 0)
	{
		if ((int)m_UITradeMap.size() > m_ipTradeCount)
		{
			m_ipTradeCount = (int)(m_UITradeMap.size());

			if (m_ppTrade != NULL)
			{
				delete[]m_ppTrade;
			}
			m_ppTrade = new TRADEFIELD * [m_ipTradeCount];
		}

		memset(m_ppTrade, 0, sizeof(TRADEFIELD*) * m_ipTradeCount);

		int iCount = 0;
		for (auto it = m_UITradeMap.begin();
			it != m_UITradeMap.end(); it++, iCount++)
		{
			m_ppTrade[iCount] = it->second.get();
		}
	}
	return Ret;
}
