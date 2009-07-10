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
#include "frmPerson.h"
//Do not add custom headers between
//Header Include Start and Header Include End
//wxDev-C++ designer will remove them
////Header Include Start
#include "Images/frmMain_tbEntry_XPM.xpm"
#include "Images/frmMain_tbPerson_XPM.xpm"
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
	EVT_MENU(tbEntry,frmMain::tbEntryClick)
	EVT_MENU(mnuQuit, frmMain::mnuQuit_Clicked)
	EVT_MENU(tbPerson,frmMain::tbEditUserClick)
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

	WxBoxSizer1 = new wxBoxSizer(wxVERTICAL);
	this->SetSizer(WxBoxSizer1);
	this->SetAutoLayout(true);

	WxToolBar1 = new wxToolBar(this, ID_WXTOOLBAR1, wxPoint(0, 0), wxSize(312, 29), wxTB_DOCKABLE | wxTB_HORIZONTAL | wxTB_HORZ_LAYOUT);

	wxBitmap tbPerson_BITMAP (frmMain_tbPerson_XPM);
	wxBitmap tbPerson_DISABLE_BITMAP (wxNullBitmap);
	WxToolBar1->AddTool(tbPerson, wxT("New"), tbPerson_BITMAP, tbPerson_DISABLE_BITMAP, wxITEM_NORMAL, wxT("Edit Users"), wxT(""));

	WxMenuBar1 = new wxMenuBar();
	wxMenu *mnuFile_Mnu_Obj = new wxMenu(0);
	mnuFile_Mnu_Obj->Append(mnuQuit, wxT("Quit"), wxT(""), wxITEM_NORMAL);
	WxMenuBar1->Append(mnuFile_Mnu_Obj, wxT("File"));
	SetMenuBar(WxMenuBar1);

	wxBitmap tbEntry_BITMAP (frmMain_tbEntry_XPM);
	wxBitmap tbEntry_DISABLE_BITMAP (wxNullBitmap);
	WxToolBar1->AddTool(tbEntry, wxT(""), tbEntry_BITMAP, tbEntry_DISABLE_BITMAP, wxITEM_NORMAL, wxT(""), wxT(""));

	WxToolBar1->SetToolBitmapSize(wxSize(16,16));
	WxToolBar1->Realize();
	SetToolBar(WxToolBar1);
	SetTitle(wxT("Blood Pressure Monitor"));
	SetIcon(wxNullIcon);
	
	GetSizer()->Layout();
	GetSizer()->Fit(this);
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
void frmMain::tbEditUserClick(wxCommandEvent& event)
{    
	frmPerson* fm = new frmPerson(NULL);
	fm->ShowModal();

}

/*
 * mnuQuit_Clicked
 */
void frmMain::mnuQuit_Clicked(wxCommandEvent& event)
{
	// insert your code here
}

/*
 * tbEntryClick
 */
void frmMain::tbEntryClick(wxCommandEvent& event)
{	
	frmEntry* fm = new frmEntry(NULL);
	fm->ShowModal();
}
