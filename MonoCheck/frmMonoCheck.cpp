//---------------------------------------------------------------------------
//
// Name:        frmMonoCheck.cpp
// Author:      Andrew York
// Created:     1/12/2008 2:08:22 PM
// Description: frmMonoCheck class implementation
//
//---------------------------------------------------------------------------


#include <wx/file.h>
#include <wx/process.h>
#include <wx/protocol/protocol.h>
#include <wx/protocol/ftp.h>
#include <wx/msw/registry.h>
#include "frmMonoCheck.h"
//Do not add custom headers between
//Header Include Start and Header Include End
//wxDev-C++ designer will remove them
////Header Include Start
////Header Include End

//----------------------------------------------------------------------------
// frmMonoCheck
//----------------------------------------------------------------------------
//Add Custom Events only in the appropriate block.
//Code added in other places will be removed by wxDev-C++
////Event Table Start
BEGIN_EVENT_TABLE(frmMonoCheck,wxFrame)
	////Manual Code Start
	////Manual Code End
	
	EVT_CLOSE(frmMonoCheck::OnClose)
	EVT_BUTTON(ID_CMDYES,frmMonoCheck::cmdYesClick)
	EVT_BUTTON(ID_CMDNO,frmMonoCheck::cmdNoClick)
END_EVENT_TABLE()
////Event Table End

frmMonoCheck::frmMonoCheck(wxWindow *parent, wxWindowID id, const wxString &title, const wxPoint &position, const wxSize& size, long style)
: wxFrame(parent, id, title, position, size, style)
{
    wxRegKey *pRegKey = new wxRegKey("HKEY_LOCAL_MACHINE\\SOFTWARE\\Novell\\Mono DefaultCLR");
    
    // see if Mono is installed
    if( !pRegKey->Exists() )
    {
         wxMessageBox(  wxT("Mono Not Found"),  wxT("Mono Not Found"), wxOK|wxICON_INFORMATION, this );   
    }
    else
    {
        wxMessageBox(  wxT("Mono Found"),  wxT("Mono Found"), wxOK|wxICON_INFORMATION, this );
        wxString strApp = "C:\\Documents and Settings\\Andy\\My Documents\\SharpDevelop Projects\\YahtzeeSharp-Mono\\YahtzeeSharp\\bin\\Debug\\YahtzeeSharp.exe";
        wxProcess _process = new wxProcess();
        wxExecute(strApp, int flags, _process);
    }
	//Query for the Value and Retrieve it
    //long lMyVal;
//    wxString strTemp;
//    pRegKey->QueryValue("DefaultCLR",strTemp);
//    strTemp.Printf("%d",lMyVal);
    //wxMessageBox(  wxT("Goodbye world!"),  wxT(strTemp), wxOK|wxICON_INFORMATION, this );
 
    GetConfig();
    CreateGUIControls();
	
}

frmMonoCheck::~frmMonoCheck()
{
}

void frmMonoCheck::CreateGUIControls()
{
	//Do not add custom code between
	//GUI Items Creation Start and GUI Items Creation End
	//wxDev-C++ designer will remove them.
	//Add the custom code before or after the blocks
	////GUI Items Creation Start

	WxPanel1 = new wxPanel(this, ID_WXPANEL1, wxPoint(0,0), wxSize(506,222));
	WxPanel1->SetBackgroundColour(wxSystemSettings::GetColour(wxSYS_COLOUR_SCROLLBAR));
	WxPanel1->SetFont(wxFont(8, wxSWISS, wxNORMAL,wxNORMAL, false, wxT("Tahoma")));

	WxStaticText1 = new wxStaticText(WxPanel1, ID_WXSTATICTEXT1, wxT("Mono Check"), wxPoint(198,14), wxDefaultSize, 0, wxT("WxStaticText1"));
	WxStaticText1->SetFont(wxFont(16, wxSWISS, wxNORMAL,wxBOLD, false, wxT("Arial")));

	WxStaticText2 = new wxStaticText(WxPanel1, ID_WXSTATICTEXT2, wxT("We could not find the Mono .NET Framework on your computer."), wxPoint(87,47), wxDefaultSize, wxALIGN_CENTRE, wxT("WxStaticText2"));
	WxStaticText2->SetFont(wxFont(9, wxSWISS, wxNORMAL,wxBOLD, false, wxT("Arial")));

	WxStaticText3 = new wxStaticText(WxPanel1, ID_WXSTATICTEXT3, wxT("This program requires Mono to run."), wxPoint(164,70), wxDefaultSize, 0, wxT("WxStaticText3"));
	WxStaticText3->SetFont(wxFont(9, wxSWISS, wxNORMAL,wxBOLD, false, wxT("Arial")));

	WxStaticLine1 = new wxStaticLine(WxPanel1, ID_WXSTATICLINE1, wxPoint(19,98), wxSize(472,-1), wxLI_HORIZONTAL);
	WxStaticLine1->SetForegroundColour(wxColour(*wxBLACK));
	WxStaticLine1->SetFont(wxFont(8, wxSWISS, wxNORMAL,wxNORMAL, false, wxT("Tahoma")));

	WxGauge1 = new wxGauge(WxPanel1, ID_WXGAUGE1, 100, wxPoint(139,125), wxSize(257,21), wxGA_HORIZONTAL, wxDefaultValidator, wxT("WxGauge1"));
	WxGauge1->SetRange(100);
	WxGauge1->SetValue(0);
	WxGauge1->SetFont(wxFont(8, wxSWISS, wxNORMAL,wxNORMAL, false, wxT("Tahoma")));

	cmdNo = new wxButton(WxPanel1, ID_CMDNO, wxT("No"), wxPoint(162,169), wxSize(75,25), 0, wxDefaultValidator, wxT("cmdNo"));
	cmdNo->SetFont(wxFont(8, wxSWISS, wxNORMAL,wxNORMAL, false, wxT("Tahoma")));

	cmdYes = new wxButton(WxPanel1, ID_CMDYES, wxT("Yes"), wxPoint(271,169), wxSize(75,25), 0, wxDefaultValidator, wxT("cmdYes"));
	cmdYes->SetFont(wxFont(8, wxSWISS, wxNORMAL,wxNORMAL, false, wxT("Tahoma")));

	SetTitle(wxT("Mono Check"));
	SetIcon(wxNullIcon);
	SetSize(8,8,514,256);
	Center();
	
	////GUI Items Creation End
}

void frmMonoCheck::OnClose(wxCloseEvent& event)
{
	Destroy();
}

void frmMonoCheck::GetConfig()
{
    wxString strFileName = ".\\MonoCheck.conf";
    if(wxFile::Exists(strFileName) == true)
    {
        
        wxFile m_File(strFileName, wxFile::read);

        char *strBuf, *strPtr, *strEnd;
        char ch, chLast = '\0';
        char buf[1024];
        int n, nRead;   
    
        do
        {
           m_File.Read(buf, WXSIZEOF(buf));
           wxMessageBox(  wxT(buf),  wxT("Bye bye!"), wxOK|wxICON_INFORMATION, this );
            
        } while ( nRead == WXSIZEOF(buf) );
    
    
        m_File.Close();
        
    }
    else
    {
        wxMessageBox(  wxT("File Not Found"),  wxT("Could Not Find File MonoCheck.conf"), wxOK|wxICON_INFORMATION, this );
    }
}

void GetFTPFile()
{    
    wxString strFileName = ".\\wxWidgets-4.2.0.tar.gz";
    
    wxFile m_File(strFileName, wxFile::write);
    wxFTP ftp;
    // if you don't use these lines anonymous login will be used
    ftp.SetUser("user");
    ftp.SetPassword("password");

    if ( !ftp.Connect("ftp.wxwindows.org") )
    {
        wxLogError("Couldn't connect");
        return;
    }

    ftp.ChDir("/pub");
    wxInputStream *in = ftp.GetInputStream("wxWidgets-4.2.0.tar.gz");
    if ( !in )
    {
        wxLogError("Coudln't get file");
    }
    else
    {
        size_t size = in->GetSize();
        char *data = new char[size];
        if ( !in->Read(data, size) )
        {
            wxLogError("Read error");
        }
        else
        {
            // file data is in the buffer
            if(wxFile::Exists(strFileName) == false)
            {
                //m_File.write(buf, WXSIZEOF(buf));
            }
        }

        delete [] data;
        delete in;
    }
}

/*
 * cmdYesClick
 */
void frmMonoCheck::cmdYesClick(wxCommandEvent& event)
{
	//GetFTPFile();
}

/*
 * cmdNoClick
 */
void frmMonoCheck::cmdNoClick(wxCommandEvent& event)
{
	Destroy();
}
