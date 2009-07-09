//---------------------------------------------------------------------------
//
// Name:        frmMain.cpp
// Author:      ayork
// Created:     7/8/2009 4:01:45 PM
// Description: frmMain class implementation
//
//---------------------------------------------------------------------------

#include "frmMain.h"
#include "frmEntry.h"
//Do not add custom headers between
//Header Include Start and Header Include End
//wxDev-C++ designer will remove them
////Header Include Start
#include "Images/frmMain_tbNewEntry_XPM.xpm"
////Header Include End
//----------------------------------------------------------------------------
// frmMain
//----------------------------------------------------------------------------
//Add Custom Events only in the appropriate block.
//Code added in other places will be removed by wxDev-C++
////Event Table Start
BEGIN_EVENT_TABLE(frmMain,wxFrame)
	////Manual Code Start
	////Manual Code End
	
	EVT_CLOSE(frmMain::OnClose)
	EVT_MENU(ID_TBNEWENTRY,frmMain::tbNewEntryClick)
END_EVENT_TABLE()
////Event Table End

frmMain::frmMain(wxWindow *parent, wxWindowID id, const wxString &title, const wxPoint &position, const wxSize& size, long style)
: wxFrame(parent, id, title, position, size, style)
{
	CreateGUIControls();
}

frmMain::~frmMain()
{
}

void frmMain::CreateGUIControls()
{
	//Do not add custom code between
	//GUI Items Creation Start and GUI Items Creation End
	//wxDev-C++ designer will remove them.
	//Add the custom code before or after the blocks
	////GUI Items Creation Start

	WxToolBar1 = new wxToolBar(this, ID_WXTOOLBAR1, wxPoint(0,0), wxSize(312,21));
	WxToolBar1->SetFont(wxFont(8, wxSWISS, wxNORMAL,wxNORMAL, false, wxT("Tahoma")));

	wxBitmap tbNewEntry_BITMAP (frmMain_tbNewEntry_XPM);
	wxBitmap tbNewEntry_DISABLE_BITMAP (wxNullBitmap);
	WxToolBar1->AddTool(ID_TBNEWENTRY, wxT("New Entry"), tbNewEntry_BITMAP, tbNewEntry_DISABLE_BITMAP, wxITEM_NORMAL, wxT("New Entry"), wxT("Click here to enter a new blood pressure reading"));

	WxToolBar1->SetToolBitmapSize(wxSize(16,16));
	WxToolBar1->Realize();
	SetToolBar(WxToolBar1);
	SetTitle(wxT("Blood Pressure Monitor"));
	SetIcon(wxNullIcon);
	SetSize(8,8,320,334);
	Center();
	
	////GUI Items Creation End
}

void frmMain::OnClose(wxCloseEvent& event)
{
	Destroy();
}

/*
 * tbNewEntryClick
 */
void frmMain::tbNewEntryClick(wxCommandEvent& event)
{
	frmEntry* fm = new frmEntry(NULL);
	fm->ShowModal();

}
