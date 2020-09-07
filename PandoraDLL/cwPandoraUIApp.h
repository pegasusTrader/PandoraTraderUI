#pragma once
#include "cwFtdMdSpi.h"
#include "cwFtdTradeSpi.h"
#include "cwPandoraUIStrategy.h"

class cwPandoraUIApp
{
public:
	cwPandoraUIApp();
	~cwPandoraUIApp();

public:
	void					Run(const char* pszMdFront, const char* pszTradeFront);
	
	inline void				GetUIAccount() { m_pUIAccount = m_cwPandoraUIStategy.GetAccount(); }
	bool					GetUIAllOrders();
	bool					GetUIPositions();
	bool					GetUIAllTrades();

	cwFtdMdSpi								m_mdCollector;
	cwFtdTradeSpi							m_TradeChannel;
	cwPandoraUIStrategy						m_cwPandoraUIStategy;


	cwAccountPtr							m_pUIAccount;
	
	std::map<std::string, cwOrderPtr>		m_UIOrderMap;
	ORDERFIELD**							m_ppOrder;
	int										m_ipOrderCount;

	std::map<std::string, cwPositionPtr>	m_UIPositionsMap;
	POSITIONFIELD**							m_ppPosition;
	int										m_ipPositionCount;

	std::map<std::string, cwTradePtr>		m_UITradeMap;
	TRADEFIELD**							m_ppTrade;
	int										m_ipTradeCount;
};

