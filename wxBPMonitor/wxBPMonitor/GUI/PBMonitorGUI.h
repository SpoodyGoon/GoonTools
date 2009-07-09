///////////////////////////////////////////////////////////////////////////
// C++ code generated with wxFormBuilder (version Apr 16 2008)
// http://www.wxformbuilder.org/
//
// PLEASE DO "NOT" EDIT THIS FILE!
///////////////////////////////////////////////////////////////////////////

#ifndef __PBMonitorGUI__
#define __PBMonitorGUI__

#include <wx/string.h>
#include <wx/bitmap.h>
#include <wx/image.h>
#include <wx/icon.h>
#include <wx/menu.h>
#include <wx/gdicmn.h>
#include <wx/font.h>
#include <wx/colour.h>
#include <wx/settings.h>
#include <wx/toolbar.h>
#include <wx/statusbr.h>
#include <wx/frame.h>
#include <wx/stattext.h>
#include <wx/textctrl.h>
#include <wx/button.h>
#include <wx/sizer.h>
#include <wx/statline.h>
#include <wx/grid.h>
#include <wx/dialog.h>
#include <wx/statbmp.h>
#include <wx/combobox.h>
#include <wx/datectrl.h>
#include <wx/dateevt.h>

///////////////////////////////////////////////////////////////////////////


///////////////////////////////////////////////////////////////////////////////
/// Class frmMain
///////////////////////////////////////////////////////////////////////////////
class frmMain : public wxFrame 
{
	private:
	
	protected:
		wxMenuBar* m_menubar1;
		wxMenu* mnuFile;
		wxToolBar* tbMain;
		wxStatusBar* sbMain;
		
		// Virtual event handlers, overide them in your derived class
		virtual void mnuQuit_Clicked( wxCommandEvent& event ){ event.Skip(); }
		virtual void tbAddEntry_Clicked( wxCommandEvent& event ){ event.Skip(); }
		virtual void tbUser_Clicked( wxCommandEvent& event ){ event.Skip(); }
		virtual void tbQuit_Clicked( wxCommandEvent& event ){ event.Skip(); }
		
	
	public:
		frmMain( wxWindow* parent, wxWindowID id = wxID_ANY, const wxString& title = wxT("Blood Pressure Monitor"), const wxPoint& pos = wxDefaultPosition, const wxSize& size = wxSize( 500,446 ), long style = wxCAPTION|wxCLOSE_BOX|wxDEFAULT_FRAME_STYLE|wxMAXIMIZE_BOX|wxMINIMIZE_BOX|wxRESIZE_BORDER|wxSYSTEM_MENU|wxTAB_TRAVERSAL, const wxString& name = wxT("frmMainWindow") );
		~frmMain();
	
};

///////////////////////////////////////////////////////////////////////////////
/// Class frmPerson
///////////////////////////////////////////////////////////////////////////////
class frmPerson : public wxDialog 
{
	private:
	
	protected:
		
		wxStaticText* m_staticText1;
		wxTextCtrl* txtPersonName;
		wxButton* btnAddEdit;
		wxStaticLine* m_staticline1;
		wxGrid* dgPerson;
		
		// Virtual event handlers, overide them in your derived class
		virtual void btnAddEdit_OnClick( wxCommandEvent& event ){ event.Skip(); }
		
	
	public:
		frmPerson( wxWindow* parent, wxWindowID id = wxID_ANY, const wxString& title = wxT("Add/Edit Person"), const wxPoint& pos = wxDefaultPosition, const wxSize& size = wxSize( 438,421 ), long style = wxCAPTION|wxCLOSE_BOX|wxDEFAULT_DIALOG_STYLE|wxRESIZE_BORDER|wxSTAY_ON_TOP, const wxString& name = wxT("frmPersonWindow") );
		~frmPerson();
	
};

///////////////////////////////////////////////////////////////////////////////
/// Class frmEntry
///////////////////////////////////////////////////////////////////////////////
class frmEntry : public wxDialog 
{
	private:
	
	protected:
		wxStaticText* m_staticText2;
		wxStaticBitmap* m_bitmap1;
		wxStaticText* m_staticText3;
		wxComboBox* m_comboBox1;
		wxStaticText* m_staticText4;
		wxDatePickerCtrl* m_datePicker1;
	
	public:
		frmEntry( wxWindow* parent, wxWindowID id = wxID_ANY, const wxString& title = wxT("Blood Presure Entry"), const wxPoint& pos = wxDefaultPosition, const wxSize& size = wxSize( 493,388 ), long style = wxCAPTION|wxDEFAULT_DIALOG_STYLE );
		~frmEntry();
	
};

#endif //__PBMonitorGUI__
