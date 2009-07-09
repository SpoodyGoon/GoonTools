//---------------------------------------------------------------------------
//
// Name:        frmPerson.cpp
// Author:      ayork
// Created:     7/9/2009 10:04:09 AM
// Description: frmPerson class implementation
//
//---------------------------------------------------------------------------

#include "frmPerson.h"

//Do not add custom headers
//wxDev-C++ designer will remove them
////Header Include Start
////Header Include End

//----------------------------------------------------------------------------
// frmPerson
//----------------------------------------------------------------------------
//Add Custom Events only in the appropriate block.
//Code added in other places will be removed by wxDev-C++
////Event Table Start
BEGIN_EVENT_TABLE(frmPerson,wxDialog)
	////Manual Code Start
	////Manual Code End
	
	EVT_CLOSE(frmPerson::OnClose)
END_EVENT_TABLE()
////Event Table End

frmPerson::frmPerson(wxWindow *parent, wxWindowID id, const wxString &title, const wxPoint &position, const wxSize& size, long style)
: wxDialog(parent, id, title, position, size, style)
{
	CreateGUIControls();
}

frmPerson::~frmPerson()
{
} 

void frmPerson::CreateGUIControls()
{
	//Do not add custom code between
	//GUI Items Creation Start and GUI Items Creation End.
	//wxDev-C++ designer will remove them.
	//Add the custom code before or after the blocks
	////GUI Items Creation Start

	WxFlexGridSizer1 = new wxFlexGridSizer(0, 1, 0, 0);
	this->SetSizer(WxFlexGridSizer1);
	this->SetAutoLayout(true);

	WxFlexGridSizer2 = new wxFlexGridSizer(0, 2, 0, 0);
	WxFlexGridSizer1->Add(WxFlexGridSizer2, 1, wxALIGN_CENTER | wxALL, 5);

	WxStaticText1 = new wxStaticText(this, ID_WXSTATICTEXT1, wxT("WxStaticText1"), wxPoint(5,9), wxDefaultSize, 0, wxT("WxStaticText1"));
	WxStaticText1->SetFont(wxFont(8, wxSWISS, wxNORMAL,wxNORMAL, false, wxT("Tahoma")));
	WxFlexGridSizer2->Add(WxStaticText1,0,wxALIGN_CENTER | wxALL,5);

	WxButton1 = new wxButton(this, ID_WXBUTTON1, wxT("WxButton1"), wxPoint(90,5), wxSize(88,25), 0, wxDefaultValidator, wxT("WxButton1"));
	WxButton1->SetFont(wxFont(8, wxSWISS, wxNORMAL,wxNORMAL, false, wxT("Tahoma")));
	WxFlexGridSizer2->Add(WxButton1,0,wxALIGN_CENTER | wxALL,5);

	dgPerson = new wxGrid(this, ID_DGPERSON, wxPoint(5,50), wxSize(337,315));
	dgPerson->SetFont(wxFont(8, wxSWISS, wxNORMAL,wxNORMAL, false, wxT("Tahoma")));
	dgPerson->SetDefaultColSize(100);
	dgPerson->SetDefaultRowSize(25);
	dgPerson->SetRowLabelSize(50);
	dgPerson->SetColLabelSize(25);
	dgPerson->CreateGrid(5,2,wxGrid::wxGridSelectCells);
	WxFlexGridSizer1->Add(dgPerson,0,wxALIGN_CENTER | wxALL,5);

	SetTitle(wxT("Person Dialog"));
	SetIcon(wxNullIcon);
	
	GetSizer()->Layout();
	GetSizer()->Fit(this);
	GetSizer()->SetSizeHints(this);
	Center();
	
	////GUI Items Creation End
}

void frmPerson::OnClose(wxCloseEvent& /*event*/)
{
	Destroy();
}

/*
 * WxGrid1CellChange
 */
void frmPerson::WxGrid1CellChange(wxGridEvent& event)
{
	
}
