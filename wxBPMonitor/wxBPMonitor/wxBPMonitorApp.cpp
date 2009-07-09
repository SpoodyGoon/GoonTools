//---------------------------------------------------------------------------
//
// Name:        wxBPMonitorApp.cpp
// Author:      ayork
// Created:     7/8/2009 4:01:45 PM
// Description: 
//
//---------------------------------------------------------------------------

#include "wxBPMonitorApp.h"
#include "frmMain.h"

IMPLEMENT_APP(frmMainApp)

bool frmMainApp::OnInit()
{
    frmMain* frame = new frmMain(NULL);
    SetTopWindow(frame);
    frame->Show();
    return true;
}
 
int frmMainApp::OnExit()
{
	return 0;
}
