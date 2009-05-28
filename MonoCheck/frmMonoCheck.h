//---------------------------------------------------------------------------
//
// Name:        frmMonoCheck.h
// Author:      Andrew York
// Created:     1/12/2008 2:08:22 PM
// Description: frmMonoCheck class declaration
//
//---------------------------------------------------------------------------

#ifndef __FRMMONOCHECK_h__
#define __FRMMONOCHECK_h__

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
#include <wx/button.h>
#include <wx/gauge.h>
#include <wx/statline.h>
#include <wx/stattext.h>
#include <wx/panel.h>
////Header Include End

////Dialog Style Start
#undef frmMonoCheck_STYLE
#define frmMonoCheck_STYLE wxCAPTION | wxTHICK_FRAME
////Dialog Style End

class frmMonoCheck : public wxFrame
{
	private:
		DECLARE_EVENT_TABLE();
		
	public:
		frmMonoCheck(wxWindow *parent, wxWindowID id = 1, const wxString &title = wxT("Mono Check"), const wxPoint& pos = wxDefaultPosition, const wxSize& size = wxDefaultSize, long style = frmMonoCheck_STYLE);
		virtual ~frmMonoCheck();
		void cmdYesClick(wxCommandEvent& event);
		void cmdNoClick(wxCommandEvent& event);
		
	private:
		//Do not add custom control declarations between
		//GUI Control Declaration Start and GUI Control Declaration End.
		//wxDev-C++ will remove them. Add custom code after the block.
		////GUI Control Declaration Start
		wxButton *cmdYes;
		wxButton *cmdNo;
		wxGauge *WxGauge1;
		wxStaticLine *WxStaticLine1;
		wxStaticText *WxStaticText3;
		wxStaticText *WxStaticText2;
		wxStaticText *WxStaticText1;
		wxPanel *WxPanel1;
		////GUI Control Declaration End
		
	private:
		//Note: if you receive any error with these enum IDs, then you need to
		//change your old form code that are based on the #define control IDs.
		//#defines may replace a numeric value for the enum names.
		//Try copy and pasting the below block in your old form header files.
		enum
		{
			////GUI Enum Control ID Start
			ID_CMDYES = 1009,
			ID_CMDNO = 1008,
			ID_WXGAUGE1 = 1007,
			ID_WXSTATICLINE1 = 1006,
			ID_WXSTATICTEXT3 = 1005,
			ID_WXSTATICTEXT2 = 1003,
			ID_WXSTATICTEXT1 = 1002,
			ID_WXPANEL1 = 1001,
			////GUI Enum Control ID End
			ID_DUMMY_VALUE_ //don't remove this value unless you have other enum values
		};
		
	private:
		void OnClose(wxCloseEvent& event);
		void GetFTPFile();
		void CreateGUIControls();
		void GetConfig();
		wxString _FileLocation;
		wxString _AlwaysCheck;
};

#endif
