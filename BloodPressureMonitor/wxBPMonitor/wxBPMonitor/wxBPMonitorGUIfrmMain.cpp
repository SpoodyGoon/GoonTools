#include "wxBPMonitorGUIfrmMain.h"
#include <wx/msgdlg.h>
wxBPMonitorGUIfrmMain::wxBPMonitorGUIfrmMain( wxWindow* parent )
:
frmMain( parent )
{

}

void wxBPMonitorGUIfrmMain::mnuNewEntry_Clicked( wxCommandEvent& event )
{
	wxMessageBox( wxT("OnButtonSendClick() event fired.") );

}

void wxBPMonitorGUIfrmMain::mnuUserEdit_Clicked( wxCommandEvent& event )
{
	// TODO: Implement mnuUserEdit_Clicked
}

void wxBPMonitorGUIfrmMain::mnuQuit_Clicked( wxCommandEvent& event )
{
	// TODO: Implement mnuQuit_Clicked
}

void wxBPMonitorGUIfrmMain::mnuAbout_Clicked( wxCommandEvent& event )
{
	wxMessageBox( wxT("OnButtonSendClick() event fired.") );
}

void wxBPMonitorGUIfrmMain::tbNewEntry_MenuSelect( wxCommandEvent& event )
{
	wxMessageBox( wxT("OnButtonSendClick() event fired.") );

}

void wxBPMonitorGUIfrmMain::tbNewEntry_Clicked( wxCommandEvent& event )
{
	// TODO: Implement tbNewEntry_Clicked
}

void wxBPMonitorGUIfrmMain::tbEditUsers_Clicked( wxCommandEvent& event )
{
	// TODO: Implement tbEditUsers_Clicked
}

void wxBPMonitorGUIfrmMain::tbQuit_Clicked( wxCommandEvent& event )
{
	// TODO: Implement tbQuit_Clicked
}