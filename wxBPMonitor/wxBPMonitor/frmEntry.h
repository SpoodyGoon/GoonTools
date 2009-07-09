//---------------------------------------------------------------------------
//
// Name:        frmEntry.h
// Author:      ayork
// Created:     7/8/2009 4:40:18 PM
// Description: frmEntry class declaration
//
//---------------------------------------------------------------------------

#ifndef __FRMENTRY_h__
#define __FRMENTRY_h__

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
#include <wx/button.h>
#include <wx/textctrl.h>
#include <wx/spinctrl.h>
#include <wx/datectrl.h>
#include <wx/dateevt.h>
#include <wx/stattext.h>
#include <wx/statbox.h>
////Header Include End

////Dialog Style Start
#undef frmEntry_STYLE
#define frmEntry_STYLE wxCAPTION | wxSYSTEM_MENU | wxSTAY_ON_TOP | wxDIALOG_NO_PARENT | wxMINIMIZE_BOX | wxCLOSE_BOX
////Dialog Style End

class frmEntry : public wxDialog
{
	private:
		DECLARE_EVENT_TABLE();
		
	public:
		frmEntry(wxWindow *parent, wxWindowID id = 1, const wxString &title = wxT("New Blood Pressure Entry"), const wxPoint& pos = wxDefaultPosition, const wxSize& size = wxDefaultSize, long style = frmEntry_STYLE);
		virtual ~frmEntry();
		void btnOkClick(wxCommandEvent& event);
		void btnCancelClick(wxCommandEvent& event);
	
	private:
		//Do not add custom control declarations between 
		//GUI Control Declaration Start and GUI Control Declaration End.
		//wxDev-C++ will remove them. Add custom code after the block.
		////GUI Control Declaration Start
		wxButton *btnOk;
		wxButton *btnCancel;
		wxTextCtrl *txtNotes;
		wxSpinCtrl *txtHeartRate;
		wxSpinCtrl *txtDiastolic;
		wxSpinCtrl *txtSystolic;
		wxDatePickerCtrl *calEntryDate;
		wxStaticText *Notes;
		wxStaticText *WxStaticText4;
		wxStaticText *WxStaticText3;
		wxStaticText *WxStaticText2;
		wxStaticText *WxStaticText1;
		wxStaticBox *sbMain;
		////GUI Control Declaration End
		
	private:
		//Note: if you receive any error with these enum IDs, then you need to
		//change your old form code that are based on the #define control IDs.
		//#defines may replace a numeric value for the enum names.
		//Try copy and pasting the below block in your old form header files.
		enum
		{
			////GUI Enum Control ID Start
			ID_BTNOK = 1015,
			ID_BTNCANCEL = 1013,
			ID_TXTNOTES = 1012,
			ID_TXTHEARTRATE = 1011,
			ID_TXTDIASTOLIC = 1010,
			ID_TXTSYSTOLIC = 1009,
			ID_CALENTRYDATE = 1008,
			ID_NOTES = 1007,
			ID_WXSTATICTEXT4 = 1006,
			ID_WXSTATICTEXT3 = 1005,
			ID_WXSTATICTEXT2 = 1004,
			ID_WXSTATICTEXT1 = 1003,
			ID_SBMAIN = 1002,
			////GUI Enum Control ID End
			ID_DUMMY_VALUE_ //don't remove this value unless you have other enum values
		};
	
	private:
		void OnClose(wxCloseEvent& event);
		void CreateGUIControls();
};

#endif
