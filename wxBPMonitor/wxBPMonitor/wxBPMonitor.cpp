///////////////////////////////////////////////////////////////////////////
// C++ code generated with wxFormBuilder (version Apr 16 2008)
// http://www.wxformbuilder.org/
//
// PLEASE DO "NOT" EDIT THIS FILE!
///////////////////////////////////////////////////////////////////////////

#include "wxBPMonitor.h"

///////////////////////////////////////////////////////////////////////////

frmMain::frmMain( wxWindow* parent, wxWindowID id, const wxString& title, const wxPoint& pos, const wxSize& size, long style, const wxString& name ) : wxFrame( parent, id, title, pos, size, style, name )
{
	this->SetSizeHints( wxDefaultSize, wxDefaultSize );
	
	m_menubar1 = new wxMenuBar( 0 );
	mnuFile = new wxMenu();
	wxMenuItem* mnuNewEntry;
	mnuNewEntry = new wxMenuItem( mnuFile, wxID_ANY, wxString( wxT("New Entry") ) , wxEmptyString, wxITEM_NORMAL );
	mnuFile->Append( mnuNewEntry );
	
	wxMenuItem* mnuUserEdit;
	mnuUserEdit = new wxMenuItem( mnuFile, wxID_ANY, wxString( wxT("Users") ) , wxEmptyString, wxITEM_NORMAL );
	mnuFile->Append( mnuUserEdit );
	
	wxMenuItem* mnuQuit;
	mnuQuit = new wxMenuItem( mnuFile, wxID_ANY, wxString( wxT("Quit") ) , wxEmptyString, wxITEM_NORMAL );
	mnuFile->Append( mnuQuit );
	
	m_menubar1->Append( mnuFile, wxT("File") );
	
	mnuHelp = new wxMenu();
	wxMenuItem* mnuAbout;
	mnuAbout = new wxMenuItem( mnuHelp, wxID_ANY, wxString( wxT("About") ) , wxEmptyString, wxITEM_NORMAL );
	mnuHelp->Append( mnuAbout );
	
	m_menubar1->Append( mnuHelp, wxT("Help") );
	
	this->SetMenuBar( m_menubar1 );
	
	tbMain = this->CreateToolBar( wxTB_HORIZONTAL, wxID_ANY );
	tbMain->SetToolSeparation( 8 );
	tbMain->SetMargins( wxSize( 3,3 ) );
	tbMain->SetToolPacking( 2 );
	tbMain->AddSeparator();
	tbMain->AddTool( wxID_ANY, wxT("New BP Entry"), wxBitmap( wxT("images/edit_add.png"), wxBITMAP_TYPE_ANY ), wxNullBitmap, wxITEM_NORMAL, wxT("New BP Entry"), wxT("New BP Entry") );
	tbMain->AddTool( wxID_ANY, wxT("Edit Users"), wxBitmap( wxT("images/edit_user.png"), wxBITMAP_TYPE_ANY ), wxNullBitmap, wxITEM_NORMAL, wxT("Edit Users"), wxT("Edit Users") );
	tbMain->AddSeparator();
	tbMain->AddTool( wxID_ANY, wxT("Exit Program"), wxBitmap( wxT("images/exit.png"), wxBITMAP_TYPE_ANY ), wxNullBitmap, wxITEM_NORMAL, wxT("Exit Program"), wxT("Exit Program") );
	tbMain->Realize();
	
	wxBoxSizer* bSizer13;
	bSizer13 = new wxBoxSizer( wxVERTICAL );
	
	bSizer13->SetMinSize( wxSize( 350,350 ) ); 
	this->SetSizer( bSizer13 );
	this->Layout();
	sbMain = this->CreateStatusBar( 1, wxST_SIZEGRIP, wxID_ANY );
	
	this->Centre( wxBOTH );
	
	// Connect Events
	this->Connect( mnuNewEntry->GetId(), wxEVT_COMMAND_MENU_SELECTED, wxCommandEventHandler( frmMain::mnuNewEntry_Clicked ) );
	this->Connect( mnuUserEdit->GetId(), wxEVT_COMMAND_MENU_SELECTED, wxCommandEventHandler( frmMain::mnuUserEdit_Clicked ) );
	this->Connect( mnuQuit->GetId(), wxEVT_COMMAND_MENU_SELECTED, wxCommandEventHandler( frmMain::mnuQuit_Clicked ) );
	this->Connect( mnuAbout->GetId(), wxEVT_COMMAND_MENU_SELECTED, wxCommandEventHandler( frmMain::mnuAbout_Clicked ) );
	this->Connect( wxID_ANY, wxEVT_COMMAND_TOOL_CLICKED, wxCommandEventHandler( frmMain::tbNewEntry_Clicked ) );
	this->Connect( wxID_ANY, wxEVT_COMMAND_TOOL_CLICKED, wxCommandEventHandler( frmMain::tbEditUsers_Clicked ) );
	this->Connect( wxID_ANY, wxEVT_COMMAND_TOOL_CLICKED, wxCommandEventHandler( frmMain::tbQuit_Clicked ) );
}

frmMain::~frmMain()
{
	// Disconnect Events
	this->Disconnect( wxID_ANY, wxEVT_COMMAND_MENU_SELECTED, wxCommandEventHandler( frmMain::mnuNewEntry_Clicked ) );
	this->Disconnect( wxID_ANY, wxEVT_COMMAND_MENU_SELECTED, wxCommandEventHandler( frmMain::mnuUserEdit_Clicked ) );
	this->Disconnect( wxID_ANY, wxEVT_COMMAND_MENU_SELECTED, wxCommandEventHandler( frmMain::mnuQuit_Clicked ) );
	this->Disconnect( wxID_ANY, wxEVT_COMMAND_MENU_SELECTED, wxCommandEventHandler( frmMain::mnuAbout_Clicked ) );
	this->Disconnect( wxID_ANY, wxEVT_COMMAND_TOOL_CLICKED, wxCommandEventHandler( frmMain::tbNewEntry_Clicked ) );
	this->Disconnect( wxID_ANY, wxEVT_COMMAND_TOOL_CLICKED, wxCommandEventHandler( frmMain::tbEditUsers_Clicked ) );
	this->Disconnect( wxID_ANY, wxEVT_COMMAND_TOOL_CLICKED, wxCommandEventHandler( frmMain::tbQuit_Clicked ) );
}

frmPerson::frmPerson( wxWindow* parent, wxWindowID id, const wxString& title, const wxPoint& pos, const wxSize& size, long style, const wxString& name ) : wxDialog( parent, id, title, pos, size, style, name )
{
	this->SetSizeHints( wxDefaultSize, wxDefaultSize );
	
	wxBoxSizer* bSizer1;
	bSizer1 = new wxBoxSizer( wxVERTICAL );
	
	
	bSizer1->Add( 0, 4, 0, wxALIGN_TOP|wxALL|wxEXPAND, 0 );
	
	wxBoxSizer* bSizer2;
	bSizer2 = new wxBoxSizer( wxHORIZONTAL );
	
	m_staticText1 = new wxStaticText( this, wxID_ANY, wxT("Persons Name:"), wxDefaultPosition, wxDefaultSize, 0 );
	m_staticText1->Wrap( -1 );
	bSizer2->Add( m_staticText1, 0, wxALIGN_CENTER|wxALL, 5 );
	
	txtPersonName = new wxTextCtrl( this, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, 0 );
	bSizer2->Add( txtPersonName, 10, wxALL, 5 );
	
	btnAddEdit = new wxButton( this, wxID_ANY, wxT("Add/Edit"), wxDefaultPosition, wxDefaultSize, 0 );
	bSizer2->Add( btnAddEdit, 0, wxALL, 5 );
	
	bSizer1->Add( bSizer2, 0, wxALIGN_CENTER_HORIZONTAL|wxALIGN_TOP|wxALL|wxBOTTOM|wxSHAPED|wxTOP, 5 );
	
	m_staticline1 = new wxStaticLine( this, wxID_ANY, wxDefaultPosition, wxDefaultSize, wxLI_HORIZONTAL );
	bSizer1->Add( m_staticline1, 0, wxALL|wxEXPAND, 5 );
	
	
	bSizer1->Add( 0, 8, 0, 0, 5 );
	
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
	bSizer1->Add( dgPerson, 5, wxALIGN_CENTER_HORIZONTAL|wxALL, 5 );
	
	m_staticline3 = new wxStaticLine( this, wxID_ANY, wxDefaultPosition, wxDefaultSize, wxLI_HORIZONTAL );
	bSizer1->Add( m_staticline3, 0, wxEXPAND | wxALL, 5 );
	
	wxBoxSizer* bSizer12;
	bSizer12 = new wxBoxSizer( wxVERTICAL );
	
	btnClose = new wxButton( this, wxID_ANY, wxT("Close"), wxDefaultPosition, wxDefaultSize, 0 );
	bSizer12->Add( btnClose, 0, wxALIGN_CENTER_HORIZONTAL, 5 );
	
	bSizer1->Add( bSizer12, 0, wxALL|wxEXPAND, 5 );
	
	this->SetSizer( bSizer1 );
	this->Layout();
	
	// Connect Events
	btnAddEdit->Connect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( frmPerson::btnAddEdit_OnClick ), NULL, this );
	btnClose->Connect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( frmPerson::btnClose_Clicked ), NULL, this );
}

frmPerson::~frmPerson()
{
	// Disconnect Events
	btnAddEdit->Disconnect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( frmPerson::btnAddEdit_OnClick ), NULL, this );
	btnClose->Disconnect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( frmPerson::btnClose_Clicked ), NULL, this );
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
	
	bSizer4->Add( m_staticText2, 1, wxALL, 5 );
	
	imgHeader = new wxStaticBitmap( this, wxID_ANY, wxBitmap( wxT("images/package_favourite.png"), wxBITMAP_TYPE_ANY ), wxPoint( -1,-1 ), wxSize( -1,-1 ), 0 );
	bSizer4->Add( imgHeader, 0, wxALL, 5 );
	
	bSizer3->Add( bSizer4, 0, wxALIGN_CENTER_HORIZONTAL|wxALL, 11 );
	
	wxGridSizer* gSizer1;
	gSizer1 = new wxGridSizer( 4, 2, 5, 5 );
	
	m_staticText8 = new wxStaticText( this, wxID_ANY, wxT("Name:"), wxDefaultPosition, wxDefaultSize, 0 );
	m_staticText8->Wrap( -1 );
	gSizer1->Add( m_staticText8, 0, wxALIGN_CENTER_VERTICAL|wxALIGN_RIGHT|wxALL, 5 );
	
	wxArrayString ddlNameChoices;
	ddlName = new wxChoice( this, wxID_ANY, wxDefaultPosition, wxSize( 175,-1 ), ddlNameChoices, 0 );
	ddlName->SetSelection( 0 );
	gSizer1->Add( ddlName, 0, wxALL, 5 );
	
	m_staticText9 = new wxStaticText( this, wxID_ANY, wxT("Date:"), wxDefaultPosition, wxDefaultSize, 0 );
	m_staticText9->Wrap( -1 );
	gSizer1->Add( m_staticText9, 0, wxALIGN_CENTER_VERTICAL|wxALIGN_RIGHT|wxALL, 5 );
	
	dteEntryDate = new wxDatePickerCtrl( this, wxID_ANY, wxDefaultDateTime, wxDefaultPosition, wxDefaultSize, wxDP_DEFAULT );
	gSizer1->Add( dteEntryDate, 0, wxALL, 5 );
	
	m_staticText10 = new wxStaticText( this, wxID_ANY, wxT("Systolic:"), wxDefaultPosition, wxDefaultSize, 0 );
	m_staticText10->Wrap( -1 );
	gSizer1->Add( m_staticText10, 0, wxALIGN_CENTER_VERTICAL|wxALIGN_RIGHT|wxALL, 5 );
	
	txtSystolic = new wxSpinCtrl( this, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, wxSP_ARROW_KEYS, 0, 10, 0 );
	gSizer1->Add( txtSystolic, 0, wxALL, 5 );
	
	m_staticText11 = new wxStaticText( this, wxID_ANY, wxT("Diastolic:"), wxDefaultPosition, wxDefaultSize, 0 );
	m_staticText11->Wrap( -1 );
	gSizer1->Add( m_staticText11, 0, wxALIGN_CENTER_VERTICAL|wxALIGN_RIGHT|wxALL, 5 );
	
	txtDiastolic = new wxSpinCtrl( this, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, wxSP_ARROW_KEYS, 0, 10, 0 );
	gSizer1->Add( txtDiastolic, 0, wxALL, 5 );
	
	m_staticText12 = new wxStaticText( this, wxID_ANY, wxT("Heart Rate:"), wxDefaultPosition, wxDefaultSize, 0 );
	m_staticText12->Wrap( -1 );
	gSizer1->Add( m_staticText12, 0, wxALIGN_CENTER_VERTICAL|wxALIGN_RIGHT|wxALL, 5 );
	
	txtHeartRate = new wxSpinCtrl( this, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, wxSP_ARROW_KEYS, 0, 10, 0 );
	gSizer1->Add( txtHeartRate, 0, wxALL, 5 );
	
	bSizer3->Add( gSizer1, 2, wxALL, 5 );
	
	wxBoxSizer* bSizer10;
	bSizer10 = new wxBoxSizer( wxHORIZONTAL );
	
	bSizer10->SetMinSize( wxSize( -1,165 ) ); 
	m_staticText13 = new wxStaticText( this, wxID_ANY, wxT("Notes:"), wxDefaultPosition, wxDefaultSize, 0 );
	m_staticText13->Wrap( -1 );
	bSizer10->Add( m_staticText13, 0, wxALL, 5 );
	
	txtNotes = new wxTextCtrl( this, wxID_ANY, wxEmptyString, wxDefaultPosition, wxSize( 300,150 ), wxTE_MULTILINE|wxTE_PROCESS_ENTER|wxTE_PROCESS_TAB|wxTE_WORDWRAP );
	bSizer10->Add( txtNotes, 0, wxALIGN_CENTER_HORIZONTAL, 5 );
	
	bSizer3->Add( bSizer10, 3, wxALIGN_CENTER|wxTOP, 5 );
	
	m_staticline2 = new wxStaticLine( this, wxID_ANY, wxDefaultPosition, wxDefaultSize, wxLI_HORIZONTAL );
	bSizer3->Add( m_staticline2, 0, wxALIGN_BOTTOM|wxALIGN_CENTER|wxEXPAND, 11 );
	
	wxBoxSizer* bSizer11;
	bSizer11 = new wxBoxSizer( wxHORIZONTAL );
	
	btnCancel = new wxButton( this, wxID_ANY, wxT("Cancel"), wxDefaultPosition, wxDefaultSize, 0 );
	bSizer11->Add( btnCancel, 0, wxALIGN_BOTTOM|wxALL, 5 );
	
	btnOk = new wxButton( this, wxID_ANY, wxT("Ok"), wxDefaultPosition, wxDefaultSize, 0 );
	btnOk->SetDefault(); 
	bSizer11->Add( btnOk, 0, wxALIGN_BOTTOM|wxALL, 5 );
	
	bSizer3->Add( bSizer11, 1, wxALIGN_CENTER_HORIZONTAL|wxBOTTOM, 5 );
	
	this->SetSizer( bSizer3 );
	this->Layout();
	
	// Connect Events
	btnCancel->Connect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( frmEntry::btnCancel_Clicked ), NULL, this );
	btnOk->Connect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( frmEntry::btnOk_Clicked ), NULL, this );
}

frmEntry::~frmEntry()
{
	// Disconnect Events
	btnCancel->Disconnect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( frmEntry::btnCancel_Clicked ), NULL, this );
	btnOk->Disconnect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( frmEntry::btnOk_Clicked ), NULL, this );
}

frmAbout::frmAbout( wxWindow* parent, wxWindowID id, const wxString& title, const wxPoint& pos, const wxSize& size, long style ) : wxDialog( parent, id, title, pos, size, style )
{
	this->SetSizeHints( wxDefaultSize, wxDefaultSize );
	
	wxBoxSizer* bSizer9;
	bSizer9 = new wxBoxSizer( wxVERTICAL );
	
	wxBoxSizer* bSizer11;
	bSizer11 = new wxBoxSizer( wxHORIZONTAL );
	
	m_bitmap2 = new wxStaticBitmap( this, wxID_ANY, wxBitmap( wxT("images/package_favourite.png"), wxBITMAP_TYPE_ANY ), wxDefaultPosition, wxDefaultSize, 0 );
	bSizer11->Add( m_bitmap2, 0, wxALL, 5 );
	
	m_staticText9 = new wxStaticText( this, wxID_ANY, wxT("MyLabel"), wxDefaultPosition, wxDefaultSize, 0 );
	m_staticText9->Wrap( -1 );
	bSizer11->Add( m_staticText9, 0, wxALL, 5 );
	
	bSizer9->Add( bSizer11, 1, wxEXPAND, 5 );
	
	wxBoxSizer* bSizer10;
	bSizer10 = new wxBoxSizer( wxHORIZONTAL );
	
	btnClose = new wxButton( this, wxID_ANY, wxT("Ok"), wxDefaultPosition, wxDefaultSize, 0 );
	btnClose->SetDefault(); 
	bSizer10->Add( btnClose, 0, wxALIGN_BOTTOM|wxALIGN_CENTER_HORIZONTAL|wxALL, 5 );
	
	bSizer9->Add( bSizer10, 1, wxALIGN_CENTER_HORIZONTAL, 5 );
	
	this->SetSizer( bSizer9 );
	this->Layout();
	
	// Connect Events
	btnClose->Connect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( frmAbout::btnClose_Clicked ), NULL, this );
}

frmAbout::~frmAbout()
{
	// Disconnect Events
	btnClose->Disconnect( wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler( frmAbout::btnClose_Clicked ), NULL, this );
}
