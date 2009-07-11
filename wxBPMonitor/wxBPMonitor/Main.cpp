#include "Main.h"
#include "wxBPMonitorGUIfrmMain.h"

IMPLEMENT_APP(wxWidgetsApp)

wxWidgetsApp::wxWidgetsApp()
{
}

wxWidgetsApp::~wxWidgetsApp()
{
}


bool wxWidgetsApp::OnInit()
{
    frmMain* fm = new frmMain( (wxWindow*)NULL );
    fm ->Show();
    SetTopWindow( fm );
    return true;
}
