//---------------------------------------------------------------------------
//
// Name:        MonoCheckApp.cpp
// Author:      Andrew York
// Created:     1/12/2008 2:08:22 PM
// Description: 
//
//---------------------------------------------------------------------------

#include "MonoCheckApp.h"
#include "frmMonoCheck.h"

IMPLEMENT_APP(frmMonoCheckApp)

bool frmMonoCheckApp::OnInit()
{
    frmMonoCheck* frame = new frmMonoCheck(NULL);
    SetTopWindow(frame);
    frame->Show();
    return true;
}
 
int frmMonoCheckApp::OnExit()
{
	return 0;
}
