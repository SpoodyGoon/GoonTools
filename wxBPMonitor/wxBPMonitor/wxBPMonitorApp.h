//---------------------------------------------------------------------------
//
// Name:        wxBPMonitorApp.h
// Author:      ayork
// Created:     7/8/2009 4:01:45 PM
// Description: 
//
//---------------------------------------------------------------------------

#ifndef __FRMMAINApp_h__
#define __FRMMAINApp_h__

#ifdef __BORLANDC__
	#pragma hdrstop
#endif

#ifndef WX_PRECOMP
	#include <wx/wx.h>
#else
	#include <wx/wxprec.h>
#endif

class frmMainApp : public wxApp
{
	public:
		bool OnInit();
		int OnExit();
};

#endif
