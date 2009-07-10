//---------------------------------------------------------------------------
//
// Name:        frmMain.h
// Author:      ayork
// Created:     7/8/2009 4:01:45 PM
// Description: frmMain class declaration
//
//---------------------------------------------------------------------------

#ifndef __FRMMAIN_h__
#define __FRMMAIN_h__

#ifdef __BORLANDC__
	#pragma hdrstop
#endif

#ifndef WX_PRECOMP
	#include <wx/wx.h>
	#include <wx/frame.h>
#else
	#include <wx/wxprec.h>
#endif

//Do not add custom headers between 
//Header Include Start and Header Include End.
//wxDev-C++ designer will remove them. Add custom headers after the block.
////Header Include Start
#include <wx/menu.h>
#include <wx/toolbar.h>
#include <wx/sizer.h>
////Header Include End

////Dialog Style Start
#undef frmMain_STYLE
#define frmMain_STYLE wxDOUBLE_BORDER | wxRAISED_BORDER | wxCAPTION | wxRESIZE_BORDER | wxSYSTEM_MENU | wxMINIMIZE_BOX | wxMAXIMIZE_BOX | wxCLOSE_BOX | wxFRAME_SHAPED
////Dialog Style End

class frmMain : public wxFrame
{
	private:
		DECLARE_EVENT_TABLE();
		
	public:
		frmMain(wxWindow *parent, wxWindowID id = 1, const wxString &title = wxT("Blood Pressure Monitor"), const wxPoint& pos = wxDefaultPosition, const wxSize& size = wxDefaultSize, long style = frmMain_STYLE);
		virtual ~frmMain();
		void tbEditUserClick(wxCommandEvent& event);
		void mnuQuit_Clicked(wxCommandEvent& event);
		void tbEntryClick(wxCommandEvent& event);
		
	private:
		//Do not add custom control declarations between
		//GUI Control Declaration Start and GUI Control Declaration End.
		//wxDev-C++ will remove them. Add custom code after the block.
		////GUI Control Declaration Start
		wxMenuBar *WxMenuBar1;
		wxToolBar *WxToolBar1;
		wxBoxSizer *WxBoxSizer1;
		////GUI Control Declaration End
		
	private:
		//Note: if you receive any error with these enum IDs, then you need to
		//change your old form code that are based on the #define control IDs.
		//#defines may replace a numeric value for the enum names.
		//Try copy and pasting the below block in your old form header files.
		enum
		{
			////GUI Enum Control ID Start
			tbEntry = 13,
			mnuFile = 11,
			mnuQuit = 12,
			
			tbPerson = 7,
			ID_WXTOOLBAR1 = 10,
			////GUI Enum Control ID End
			ID_DUMMY_VALUE_ //don't remove this value unless you have other enum values
		};
		
	private:
		void OnClose(wxCloseEvent& event);
		void CreateGUIControls();
};

#endif
