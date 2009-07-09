///////////////////////////////////////////////////////////////////////////
// C++ code generated with wxFormBuilder (version Apr 16 2008)
// http://www.wxformbuilder.org/
//
// PLEASE DO "NOT" EDIT THIS FILE!
///////////////////////////////////////////////////////////////////////////

#include "PBMonitorGUI.h"

///////////////////////////////////////////////////////////////////////////

frmMain::frmMain( wxWindow* parent, wxWindowID id, const wxString& title, const wxPoint& pos, const wxSize& size, long style, const wxString& name ) : wxFrame( parent, id, title, pos, size, style, name )
{
	this->SetSizeHints( wxDefaultSize, wxDefaultSize );
	
	m_menubar1 = new wxMenuBar( 0 );
	mnuFile = new wxMenu();
	wxMenuItem* mnuQuit;
	mnuQuit = new wxMenuItem( mnuFile, wxID_ANY, wxString( wxT("Quit") ) , wxEmptyString, wxITEM_NORMAL );
	mnuFile->Append( mnuQuit );
	
	m_menubar1->Append( mnuFile, wxT("File") );
	
	this->SetMenuBar( m_menubar1 );
	
	tbMain = this->CreateToolBar( wxTB_HORIZONTAL, wxID_ANY );
	tbMain->SetToolSeparation( 8 );
	tbMain->SetMargins( wxSize( 3,3 ) );
	tbMain->SetToolPacking( 2 );
	tbMain->AddTool( wxID_ANY, wxT("Add BP Entry"), wxBitmap( wxT("images/edit_add.png"), wxBITMAP_TYPE_ANY ), wxNullBitmap, wxITEM_NORMAL, wxT("Add BP Entry"), wxT("Add BP Entry") );
	tbMain->AddTool( wxID_ANY, wxT("Add User"), wxBitmap( wxT("images/edit_user.png"), wxBITMAP_TYPE_ANY ), wxNullBitmap, wxITEM_NORMAL, wxT("Add User"), wxT("Add User") );
	tbMain->AddSeparator();
	tbMain->AddTool( wxID_ANY, wxT("Exit Program"), wxBitmap( wxT("images/exit.png"), wxBITMAP_TYPE_ANY ), wxNullBitmap, wxITEM_NORMAL, wxT("Exit Program"), wxT("Exit Program") );
	tbMain->Realize();
	
	sbMain = this->CreateStatusBar( 1, wxST_SIZEGRIP, wxID_ANY );
	
	this->Centre( wxBOTH );
	
	// Connect Events
	this->Connect( mnuQuit->GetId(), wxEVT_COMMAND_MENU_SELECTED, wxCommandEventHandler( frmMain::mnuQuit_Clicked ) );
	this->Connect( wxID_ANY, wxEVT_COMMAND_TOOL_CLICKED, wxCommandEventHandler( frmMain::tbAddEntry_Clicked ) );
	this->Connect( wxID_ANY, wxEVT_COMMAND_TOOL_CLICKED, wxCommandEventHandler( frmMain::tbUser_Clicked ) );
	this->Connect( wxID_ANY, wxEVT_COMMAND_TOOL_CLICKED, wxCommandEventHandler( frmMain::tbQuit_Clicked ) );
}

frmMain::~frmMain()
{
	// Disconnect Events
	this->Disconnect( wxID_ANY, wxEVT_COMMAND_MENU_SELECTED, wxCommandEventHandler( frmMain::mnuQuit_Clicked ) );
	this->Disconnect( wxID_ANY, wxEVT_COMMAND_TOOL_CLICKED, wxCommandEventHandler( frmMain::tbAddEntry_Clicked ) );
	this->Disconnect( wxID_ANY, wxEVT_COMMAND_TOOL_CLICKED, wxCommandEventHandler( frmMain::tbUser_Clicked ) );
	this->Disconnect( wxID_ANY, wxEVT_COMMAND_TOOL_CLICKED, wxCommandEventHandler( frmMain::tbQuit_Clicked ) );
}

frmPerson::frmPerson( wxWindow* parent, wxWindowID id, const wxString& title, const wxPoint& pos, const wxSize& size, long style, const wxString& name ) : wxDialog( parent, id, title, pos, size, style, name )
{
	this->SetSizeHints( wxDefaultSize, wxDefaultSize );
	
	wxBoxSizer* bSizer1;
	bSizer1 = new wxBoxSizer( wxVERTICAL );
	
	
	bSizer1->Add( 0, 0, 1, wxALIGN_TOP|wxALL|wxEXPAND, 0 );
	
	wxBoxSizer* bSizer2;
	bSizer2 = new wxBoxSizer( wxHORIZONTAL );
	
	m_staticText1 = new wxStaticText( this, wxID_ANY, wxT("Persons Name:"), wxDefaultPosition, wxDefaultSize, 0 );
	m_staticText1->Wrap( -1 );
	bSizer2->Add( m_staticText1, 0, wxALIGN_CENTER|wxALL, 5 );
	
	txtPersonName = new wxTextCtrl( this, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, 0 );
	bSizer2->Add( txtPersonName, 10, wxALL, 5 );
	
	btnAddEdit = new wxButton( this, wxID_ANY, wxT("Add/Edit"), wxDefaultPosition, wxDefaultSize, 0 );
	bSizer2->Add( btnAddEdit, 0, wxALL, 5 );
	
	bSizer1->Add( bSizer2, 4, wxALIGN_CENTER_HORIZONTAL|wxALIGN_TOP|wxALL|wxBOTTOM|wxSHAPED|wxTOP, 5 );
	
	m_staticline1 = new wxStaticLine( this, wxID_ANY, wxDefaultPosition, wxDefaultSize, wxLI_HORIZONTAL );
	bSizer1->Add( m_staticline1, 0, wxEXPAND | wxALL, 5 );
	
	dgPerson = new wxGrid( this, wxID_ANY, wxDefaultPosition, wxDefaultSize, 0 );
	
	// Grid
	dgPerson->CreateGrid( 5, 2 );
	dgPerson->EnableEditing( true );
	dgPerson->EnableGridLines( true );
	dgPerson->EnableDragGridSize( false );
	dgPerson->SetMargins( 0, 0 );
	
	// Columns
	dgPerson->SetColSize( 0, 250 );
	dgPerson->SetColSize( 1, 50 );
	dgPerson->EnableDragColMove( false );
	dgPerson->EnableDragColSize( true );
	dgPerson->SetColLabelSize( 30 );
	dgPerson->SetColLabelValue( 0, wxT("Person") );
	dgPerson->SetColLabelValue( 1, wxT("Edit") );
	dgPerson->SetColLabelAlignment( wxALIGN_CENTRE, wxALIGN_CENTRE );
	
	// Rows
	dgPerson->AutoSizeRows();
	dgPerson->EnableDragRowSize( false );
	dgPerson->SetRowLabelSize( 0 );
	dgPerson->SetRowLabelAlignment( wxALIGN_CENTRE, wxALIGN_CENTRE );
	
	// Label Appearance
	
	// Cell Defaults
	dgPerson->SetDefaultCellAlignment( wxALIGN_LEFT, wxALIGN_TOP );
	bSizer1->Add( dgPerson, 28, wxALIGN_CENTER|wxALIGN_TOP|wxALL|wxEXPAND|wxTOP, 5 );
	
	this->SetSizer( bSizer1 );
	this->Layout();
	
	// Connect Events
	btnAddEdit->Connect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( frmPerson::btnAddEdit_OnClick ), NULL, this );
}

frmPerson::~frmPerson()
{
	// Disconnect Events
	btnAddEdit->Disconnect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( frmPerson::btnAddEdit_OnClick ), NULL, this );
}

frmEntry::frmEntry( wxWindow* parent, wxWindowID id, const wxString& title, const wxPoint& pos, const wxSize& size, long style ) : wxDialog( parent, id, title, pos, size, style )
{
	this->SetSizeHints( wxDefaultSize, wxDefaultSize );
	
	wxBoxSizer* bSizer3;
	bSizer3 = new wxBoxSizer( wxVERTICAL );
	
	wxBoxSizer* bSizer4;
	bSizer4 = new wxBoxSizer( wxHORIZONTAL );
	
	m_staticText2 = new wxStaticText( this, wxID_ANY, wxT("New Blood Presure Entry"), wxDefaultPosition, wxDefaultSize, 0 );
	m_staticText2->Wrap( -1 );
	m_staticText2->SetFont( wxFont( 16, 74, 93, 92, false, wxT("Times New Roman") ) );
	
	bSizer4->Add( m_staticText2, 0, wxALL, 5 );
	
	m_bitmap1 = new wxStaticBitmap( this, wxID_ANY, wxBitmap( wxT("images/package_favourite.png"), wxBITMAP_TYPE_ANY ), wxDefaultPosition, wxDefaultSize, 0 );
	bSizer4->Add( m_bitmap1, 0, wxALL, 5 );
	
	bSizer3->Add( bSizer4, 1, wxALIGN_CENTER_HORIZONTAL|wxALIGN_TOP|wxEXPAND|wxLEFT|wxSHAPED|wxTOP, 5 );
	
	wxBoxSizer* bSizer5;
	bSizer5 = new wxBoxSizer( wxHORIZONTAL );
	
	m_staticText3 = new wxStaticText( this, wxID_ANY, wxT("MyLabel"), wxDefaultPosition, wxDefaultSize, 0 );
	m_staticText3->Wrap( -1 );
	bSizer5->Add( m_staticText3, 0, wxALL, 5 );
	
	m_comboBox1 = new wxComboBox( this, wxID_ANY, wxT("Combo!"), wxDefaultPosition, wxDefaultSize, 0, NULL, 0 ); 
	bSizer5->Add( m_comboBox1, 0, wxALL, 5 );
	
	bSizer3->Add( bSizer5, 1, wxEXPAND, 5 );
	
	wxBoxSizer* bSizer6;
	bSizer6 = new wxBoxSizer( wxHORIZONTAL );
	
	m_staticText4 = new wxStaticText( this, wxID_ANY, wxT("MyLabel"), wxDefaultPosition, wxDefaultSize, 0 );
	m_staticText4->Wrap( -1 );
	bSizer6->Add( m_staticText4, 0, wxALL, 5 );
	
	m_datePicker1 = new wxDatePickerCtrl( this, wxID_ANY, wxDefaultDateTime, wxDefaultPosition, wxDefaultSize, wxDP_DEFAULT );
	bSizer6->Add( m_datePicker1, 0, wxALL, 5 );
	
	bSizer3->Add( bSizer6, 1, wxEXPAND, 5 );
	
	this->SetSizer( bSizer3 );
	this->Layout();
}

frmEntry::~frmEntry()
{
}
