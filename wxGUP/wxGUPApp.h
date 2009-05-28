//---------------------------------------------------------------------------
//
// Name:        wxGUPApp.h
// Author:      Andrew York
// Created:     5/26/2008 11:12:49 AM
// Description: 
//
//---------------------------------------------------------------------------

#ifndef __WXGUPDLGApp_h__
#define __WXGUPDLGApp_h__

#ifdef __BORLANDC__
	#pragma hdrstop
#endif

#ifndef WX_PRECOMP
	#include <wx/wx.h>
#else
	#include <wx/wxprec.h>
#endif

class wxGUPDlgApp : public wxApp
{
	public:
		bool OnInit();
		int OnExit();
};

#endif
