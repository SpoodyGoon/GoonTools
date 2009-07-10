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

	WxBoxSizer1 = new wxBoxSizer(wxVERTICAL);
	this->SetSizer(WxBoxSizer1);
	this->SetAutoLayout(true);

	WxBoxSizer2 = new wxBoxSizer(wxHORIZONTAL);
	WxBoxSizer1->Add(WxBoxSizer2, 3, wxALIGN_LEFT | wxALIGN_RIGHT | wxALIGN_TOP | wxALIGN_CENTER | wxALIGN_CENTER_HORIZONTAL | wxEXPAND | wxALL | wxLEFT | wxRIGHT | wxTOP | wxBOTTOM, 5);

	WxStaticText1 = new wxStaticText(this, ID_WXSTATICTEXT1, wxT("Person Name:"), wxPoint(5, 9), wxDefaultSize, 0, wxT("WxStaticText1"));
	WxBoxSizer2->Add(WxStaticText1,0,wxALIGN_CENTER | wxALL,5);

	txtPersonName = new wxTextCtrl(this, ID_TXTPERSONNAME, wxT(""), wxPoint(86, 8), wxSize(121, 19), 0, wxDefaultValidator, wxT("txtPersonName"));
	WxBoxSizer2->Add(txtPersonName,0,wxALIGN_CENTER | wxALL,5);

	btnAddEdit = new wxButton(this, ID_BTNADDEDIT, wxT("Add/Edit"), wxPoint(217, 5), wxSize(75, 25), 0, wxDefaultValidator, wxT("btnAddEdit"));
	WxBoxSizer2->Add(btnAddEdit,0,wxALIGN_CENTER | wxALL,5);

	WxBoxSizer3 = new wxBoxSizer(wxHORIZONTAL);
	WxBoxSizer1->Add(WxBoxSizer3, 8, wxALIGN_LEFT | wxALIGN_RIGHT | wxALIGN_CENTER | wxEXPAND | wxALL, 5);

	dgPerson = new wxGrid(this, ID_DGPERSON, wxPoint(5, 5), wxSize(500, 250));
	dgPerson->SetDefaultColSize(50);
	dgPerson->SetDefaultRowSize(25);
	dgPerson->SetRowLabelSize(50);
	dgPerson->SetColLabelSize(25);
	dgPerson->CreateGrid(5,5,wxGrid::wxGridSelectCells);
	WxBoxSizer3->Add(dgPerson,5,wxALIGN_LEFT | wxALIGN_RIGHT | wxALIGN_CENTER | wxEXPAND | wxALL,5);

	WxStaticLine1 = new wxStaticLine(this, ID_WXSTATICLINE1, wxPoint(185, 320), wxSize(150, -1), wxLI_HORIZONTAL);
	WxBoxSizer1->Add(WxStaticLine1,0,wxALIGN_CENTER | wxALL,5);

	WxBoxSizer4 = new wxBoxSizer(wxHORIZONTAL);
	WxBoxSizer1->Add(WxBoxSizer4, 0, wxALIGN_BOTTOM | wxALIGN_CENTER_HORIZONTAL | wxEXPAND | wxBOTTOM, 5);

	WxButton2 = new wxButton(this, ID_WXBUTTON2, wxT("WxButton2"), wxPoint(5, 5), wxSize(75, 25), 0, wxDefaultValidator, wxT("WxButton2"));
	WxBoxSizer4->Add(WxButton2,0,wxALIGN_CENTER | wxALL,5);

	WxButton3 = new wxButton(this, ID_WXBUTTON3, wxT("WxButton3"), wxPoint(90, 5), wxSize(75, 25), 0, wxDefaultValidator, wxT("WxButton3"));
	WxBoxSizer4->Add(WxButton3,0,wxALIGN_CENTER | wxALL,5);

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
