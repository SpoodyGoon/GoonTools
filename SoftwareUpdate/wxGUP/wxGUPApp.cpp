//---------------------------------------------------------------------------
//
// Name:        wxGUPApp.cpp
// Author:      Andrew York
// Created:     5/26/2008 11:12:49 AM
// Description: 
//
//---------------------------------------------------------------------------

#include "wxGUPApp.h"
#include "wxGUPDlg.h"

IMPLEMENT_APP(wxGUPDlgApp)

bool wxGUPDlgApp::OnInit()
{
	wxGUPDlg* dialog = new wxGUPDlg(NULL);
	SetTopWindow(dialog);
	dialog->Show(true);		
	return true;
}
 
int wxGUPDlgApp::OnExit()
{
	return 0;
}
