#include <wx/image.h>
#include "wxWidgetsApp.h"
#include "frmMain.h"

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
