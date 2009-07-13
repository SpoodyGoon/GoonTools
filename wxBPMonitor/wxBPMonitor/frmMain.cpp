#include "frmMain.h"
#include "frmAbout.h"
#include "frmEntry.h"
#include "frmPerson.h"
#include <wx/app.h>

frmMain::frmMain( wxWindow* parent )
:
frmMainGUI( parent )
{

}

void frmMain::mnuNewEntry_Clicked( wxCommandEvent& event )
{
	// TODO: Implement mnuNewEntry_Clicked
}

void frmMain::mnuUserEdit_Clicked( wxCommandEvent& event )
{
	// TODO: Implement mnuUserEdit_Clicked
}

void frmMain::mnuQuit_Clicked( wxCommandEvent& event )
{
	wxTheApp->Exit();
}

void frmMain::mnuAbout_Clicked( wxCommandEvent& event )
{
	// TODO: Implement mnuAbout_Clicked
}

void frmMain::tbNewEntry_MenuSelect( wxCommandEvent& event )
{
	// TODO: Implement tbNewEntry_MenuSelect
}

void frmMain::tbNewEntry_Clicked( wxCommandEvent& event )
{
	// TODO: Implement tbNewEntry_Clicked
}

void frmMain::tbEditUsers_Clicked( wxCommandEvent& event )
{
	frmPerson* fm = new frmPerson((wxWindow*)NULL);
	fm->ShowModal();
	
}

void frmMain::tbQuit_Clicked( wxCommandEvent& event )
{
	wxTheApp->Exit();
}
