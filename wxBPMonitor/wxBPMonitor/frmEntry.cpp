//---------------------------------------------------------------------------
//
// Name:        frmEntry.cpp
// Author:      ayork
// Created:     7/8/2009 4:40:18 PM
// Description: frmEntry class implementation
//
//---------------------------------------------------------------------------

#include "frmEntry.h"

//Do not add custom headers
//wxDev-C++ designer will remove them
////Header Include Start
////Header Include End

//----------------------------------------------------------------------------
// frmEntry
//----------------------------------------------------------------------------
//Add Custom Events only in the appropriate block.
//Code added in other places will be removed by wxDev-C++
////Event Table Start
BEGIN_EVENT_TABLE(frmEntry,wxDialog)
	////Manual Code Start
	////Manual Code End
	
	EVT_CLOSE(frmEntry::OnClose)
	EVT_BUTTON(ID_BTNOK,frmEntry::btnOkClick)
	EVT_BUTTON(ID_BTNCANCEL,frmEntry::btnCancelClick)
END_EVENT_TABLE()
////Event Table End

frmEntry::frmEntry(wxWindow *parent, wxWindowID id, const wxString &title, const wxPoint &position, const wxSize& size, long style)
: wxDialog(parent, id, title, position, size, style)
{
	CreateGUIControls();
}

frmEntry::~frmEntry()
{
} 

void frmEntry::CreateGUIControls()
{
	//Do not add custom code between
	//GUI Items Creation Start and GUI Items Creation End.
	//wxDev-C++ designer will remove them.
	//Add the custom code before or after the blocks
	////GUI Items Creation Start

	btnOk = new wxButton(this, ID_BTNOK, wxT("Ok"), wxPoint(280, 377), wxSize(85, 29), 0, wxDefaultValidator, wxT("btnOk"));

	btnCancel = new wxButton(this, ID_BTNCANCEL, wxT("Cancel"), wxPoint(123, 377), wxSize(85, 29), 0, wxDefaultValidator, wxT("btnCancel"));

	txtNotes = new wxTextCtrl(this, ID_TXTNOTES, wxT("txtNotes"), wxPoint(143, 176), wxSize(320, 161), wxTE_LEFT | wxTE_BESTWRAP | wxTE_LINEWRAP | wxTE_MULTILINE, wxDefaultValidator, wxT("txtNotes"));

	txtHeartRate = new wxSpinCtrl(this, ID_TXTHEARTRATE, wxT("0"), wxPoint(144, 140), wxSize(62, 22), wxSP_ARROW_KEYS, 0, 100, 0);

	txtDiastolic = new wxSpinCtrl(this, ID_TXTDIASTOLIC, wxT("0"), wxPoint(143, 109), wxSize(60, 22), wxSP_ARROW_KEYS, 0, 100, 0);

	txtSystolic = new wxSpinCtrl(this, ID_TXTSYSTOLIC, wxT("0"), wxPoint(143, 79), wxSize(56, 22), wxSP_ARROW_KEYS, 0, 100, 0);

	wxDateTime calEntryDate_Date(8,wxDateTime::Jul,2009,16,52,28,565);
	calEntryDate = new wxDatePickerCtrl(this, ID_CALENTRYDATE, calEntryDate_Date, wxPoint(145, 49), wxSize(89, 21) , wxDP_DROPDOWN, wxDefaultValidator, wxT("calEntryDate"));

	Notes = new wxStaticText(this, ID_NOTES, wxT("Notes:"), wxPoint(101, 172), wxDefaultSize, 0, wxT("Notes"));

	WxStaticText4 = new wxStaticText(this, ID_WXSTATICTEXT4, wxT("Heart Rate:"), wxPoint(84, 143), wxDefaultSize, 0, wxT("WxStaticText4"));

	WxStaticText3 = new wxStaticText(this, ID_WXSTATICTEXT3, wxT("Diastolic:"), wxPoint(97, 112), wxDefaultSize, 0, wxT("WxStaticText3"));

	WxStaticText2 = new wxStaticText(this, ID_WXSTATICTEXT2, wxT("Systolic:"), wxPoint(100, 82), wxDefaultSize, 0, wxT("WxStaticText2"));

	WxStaticText1 = new wxStaticText(this, ID_WXSTATICTEXT1, wxT("Date:"), wxPoint(114, 52), wxDefaultSize, 0, wxT("WxStaticText1"));

	sbMain = new wxStaticBox(this, ID_SBMAIN, wxT("Add a new blood pressure reading"), wxPoint(16, 10), wxSize(468, 352));
	sbMain->SetForegroundColour(wxColour(128,0,0));
	sbMain->SetFont(wxFont(9, wxSWISS, wxNORMAL, wxNORMAL, false));

	SetTitle(wxT("New Blood Pressure Entry"));
	SetIcon(wxNullIcon);
	SetSize(8,8,512,457);
	Center();
	
	////GUI Items Creation End
}

void frmEntry::OnClose(wxCloseEvent& /*event*/)
{
	Destroy();
}

/*
 * btnOkClick
 */
void frmEntry::btnOkClick(wxCommandEvent& event)
{
	
}

/*
 * btnCancelClick
 */
void frmEntry::btnCancelClick(wxCommandEvent& event)
{
	// insert your code here
}
