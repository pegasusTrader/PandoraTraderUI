#pragma once
#include "cwFtdMdSpi.h"
#include "cwFtdTradeSpi.h"
#include "cwPandoraUIStrategy.h"

class cwPandoraUIApp
{

public:
	void					Run(const char* pszMdFront, const char* pszTradeFront);
	inline void				GetUIAccount() { m_pUIAccount = m_cwPandoraUIStategy.GetAccount(); }



	cwFtdMdSpi				m_mdCollector;
	cwFtdTradeSpi			m_TradeChannel;
	cwPandoraUIStrategy		m_cwPandoraUIStategy;


	cwAccountPtr			m_pUIAccount;

};

