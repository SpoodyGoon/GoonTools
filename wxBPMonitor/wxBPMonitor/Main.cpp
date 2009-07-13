#include <wx/image.h>
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
    wxImage::AddHandler( new wxPNGHandler );
    frmMain* fm = new frmMain( (wxWindow*)NULL );
    fm ->Show();
    SetTopWindow( fm );
    return true;
}
