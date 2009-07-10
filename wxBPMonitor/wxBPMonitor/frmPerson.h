//---------------------------------------------------------------------------
//
// Name:        frmPerson.h
// Author:      ayork
// Created:     7/9/2009 10:04:09 AM
// Description: frmPerson class declaration
//
//---------------------------------------------------------------------------

#ifndef __FRMPERSON_h__
#define __FRMPERSON_h__

#ifdef __BORLANDC__
	#pragma hdrstop
#endif

#ifndef WX_PRECOMP
	#include <wx/wx.h>
	#include <wx/dialog.h>
#else
	#include <wx/wxprec.h>
#endif

//Do not add custom headers between 
//Header Include Start and Header Include End.
//wxDev-C++ designer will remove them. Add custom headers after the block.
////Header Include Start
#include <wx/statline.h>
#include <wx/grid.h>
#include <wx/button.h>
#include <wx/textctrl.h>
#include <wx/stattext.h>
#include <wx/sizer.h>
////Header Include End

////Dialog Style Start
#undef frmPerson_STYLE
#define frmPerson_STYLE wxCAPTION | wxRESIZE_BORDER | wxSYSTEM_MENU | wxSTAY_ON_TOP | wxDIALOG_NO_PARENT | wxMINIMIZE_BOX | wxCLOSE_BOX
////Dialog Style End

class frmPerson : public wxDialog
{
	private:
		DECLARE_EVENT_TABLE();
		
	public:
		frmPerson(wxWindow *parent, wxWindowID id = 1, const wxString &title = wxT("Person Dialog"), const wxPoint& pos = wxDefaultPosition, const wxSize& size = wxDefaultSize, long style = frmPerson_STYLE);
		virtual ~frmPerson();
		void WxGrid1CellChange(wxGridEvent& event);
	
	private:
		//Do not add custom control declarations between 
		//GUI Control Declaration Start and GUI Control Declaration End.
		//wxDev-C++ will remove them. Add custom code after the block.
		////GUI Control Declaration Start
		wxButton *WxButton3;
		wxButton *WxButton2;
		wxBoxSizer *WxBoxSizer4;
		wxStaticLine *WxStaticLine1;
		wxGrid *dgPerson;
		wxBoxSizer *WxBoxSizer3;
		wxButton *btnAddEdit;
		wxTextCtrl *txtPersonName;
		wxStaticText *WxStaticText1;
		wxBoxSizer *WxBoxSizer2;
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
			ID_WXBUTTON3 = 1072,
			ID_WXBUTTON2 = 1071,
			ID_WXSTATICLINE1 = 1073,
			ID_DGPERSON = 1064,
			ID_BTNADDEDIT = 1061,
			ID_TXTPERSONNAME = 1060,
			ID_WXSTATICTEXT1 = 1059,
			////GUI Enum Control ID End
			ID_DUMMY_VALUE_ //don't remove this value unless you have other enum values
		};
	
	private:
		void OnClose(wxCloseEvent& event);
		void CreateGUIControls();
};

#endif
