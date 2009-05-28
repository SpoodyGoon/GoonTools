//---------------------------------------------------------------------------
//
// Name:        MonoCheckApp.h
// Author:      Andrew York
// Created:     1/12/2008 2:08:22 PM
// Description: 
//
//---------------------------------------------------------------------------

#ifndef __FRMMONOCHECKApp_h__
#define __FRMMONOCHECKApp_h__

#ifdef __BORLANDC__
	#pragma hdrstop
#endif

#ifndef WX_PRECOMP
	#include <wx/wx.h>
#else
	#include <wx/wxprec.h>
#endif

class frmMonoCheckApp : public wxApp
{
	public:
		bool OnInit();
		int OnExit();
};

#endif
