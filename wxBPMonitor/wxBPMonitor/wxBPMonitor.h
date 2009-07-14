///////////////////////////////////////////////////////////////////////////
// C++ code generated with wxFormBuilder (version Apr 16 2008)
// http://www.wxformbuilder.org/
//
// PLEASE DO "NOT" EDIT THIS FILE!
///////////////////////////////////////////////////////////////////////////

#ifndef __wxBPMonitor__
#define __wxBPMonitor__

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
#include <wx/sizer.h>
#include <wx/statusbr.h>
#include <wx/frame.h>
#include <wx/stattext.h>
#include <wx/textctrl.h>
#include <wx/button.h>
#include <wx/statline.h>
#include <wx/grid.h>
#include <wx/dialog.h>
#include <wx/statbmp.h>
#include <wx/choice.h>
#include <wx/datectrl.h>
#include <wx/dateevt.h>
#include <wx/spinctrl.h>

///////////////////////////////////////////////////////////////////////////

#define wxID_frmMainGUI 1000
#define wxID_mnuNewEntry 1001
#define wxID_mnuUserEdit 1002
#define wxID_mnuQuit 1003
#define wxID_mnuAbout 1004
#define wxID_tbNewEntry 1005
#define wxID_tbUserEdit 1006
#define wxID_tbQuit 1007
#define wxID_sbMain 1008
#define wxID_frmPersonGUI 1009
#define wxID_m_staticText1 1010
#define wxID_txtPersonName 1011
#define wx_IDbtnAddEdit 1012
#define wxID_m_staticline1 1013
#define wxID_dgPerson 1014
#define wxID_m_staticline3 1015
#define ID_btnClose 1016
#define wxID_frmEntryGUI 1017
#define wxID_m_staticText2 1018
#define wxID_imgHeader 1019
#define wxID_m_staticText8 1020
#define wxID_ddlName 1021
#define wxID_m_staticText9 1022
#define wxID_dteEntryDate 1023
#define wxID_m_staticText10 1024
#define wxID_txtSystolic 1025
#define wxID_m_staticText11 1026
#define wxID_txtDiastolic 1027
#define wxID_m_staticText12 1028
#define wxID_txtHeartRate 1029
#define wxID_m_staticText13 1030
#define wxID_txtNotes 1031
#define wxID_m_staticline2 1032
#define wxID_btnCancel2 1033
#define wxID_btnOk2 1034
#define wxID_frmAboutGUI 1035
#define wxID_m_bitmap2 1036
#define wxID_btnClose3 1037
#define wxID_frmMedicineGUI 1038

///////////////////////////////////////////////////////////////////////////////
/// Class frmMainGUI
///////////////////////////////////////////////////////////////////////////////
class frmMainGUI : public wxFrame 
{
	private:
	
	protected:
		wxMenuBar* m_menubar1;
		wxMenu* mnuFile;
		wxMenu* mnuHelp;
		wxToolBar* tbMain;
		wxStatusBar* sbMain;
		
		// Virtual event handlers, overide them in your derived class
		virtual void mnuNewEntry_Clicked( wxCommandEvent& event ){ event.Skip(); }
		virtual void mnuUserEdit_Clicked( wxCommandEvent& event ){ event.Skip(); }
		virtual void mnuQuit_Clicked( wxCommandEvent& event ){ event.Skip(); }
		virtual void mnuAbout_Clicked( wxCommandEvent& event ){ event.Skip(); }
		virtual void tbNewEntry_MenuSelect( wxCommandEvent& event ){ event.Skip(); }
		virtual void tbNewEntry_Clicked( wxCommandEvent& event ){ event.Skip(); }
		virtual void tbEditUsers_Clicked( wxCommandEvent& event ){ event.Skip(); }
		virtual void tbQuit_Clicked( wxCommandEvent& event ){ event.Skip(); }
		
	
	public:
		wxMenuItem* mnuNewEntry;
		wxMenuItem* mnuUserEdit;
		frmMainGUI( wxWindow* parent, wxWindowID id = wxID_frmMainGUI, const wxString& title = wxT("Blood Pressure Monitor"), const wxPoint& pos = wxDefaultPosition, const wxSize& size = wxSize( 500,446 ), long style = wxCAPTION|wxCLOSE_BOX|wxDEFAULT_FRAME_STYLE|wxMAXIMIZE_BOX|wxMINIMIZE_BOX|wxRESIZE_BORDER|wxSYSTEM_MENU|wxDOUBLE_BORDER|wxRAISED_BORDER|wxSTATIC_BORDER|wxTAB_TRAVERSAL, const wxString& name = wxT("frmMain") );
		~frmMainGUI();
	
};

///////////////////////////////////////////////////////////////////////////////
/// Class frmPersonGUI
///////////////////////////////////////////////////////////////////////////////
class frmPersonGUI : public wxDialog 
{
	private:
	
	protected:
		
		wxStaticText* m_staticText1;
		wxTextCtrl* txtPersonName;
		wxButton* btnClear;
		wxButton* btnAddEdit;
		wxStaticLine* m_staticline1;
		
		wxGrid* dgPerson;
		wxStaticLine* m_staticline3;
		wxButton* btnClose;
		
		// Virtual event handlers, overide them in your derived class
		virtual void btnClear_Clicked( wxCommandEvent& event ){ event.Skip(); }
		virtual void btnAddEdit_OnClick( wxCommandEvent& event ){ event.Skip(); }
		virtual void dgPerson_CellSelected( wxGridEvent& event ){ event.Skip(); }
		virtual void btnClose_Clicked( wxCommandEvent& event ){ event.Skip(); }
		
	
	public:
		frmPersonGUI( wxWindow* parent, wxWindowID id = wxID_frmPersonGUI, const wxString& title = wxT("Add/Edit Person"), const wxPoint& pos = wxDefaultPosition, const wxSize& size = wxSize( 438,402 ), long style = wxCAPTION|wxCLOSE_BOX|wxDEFAULT_DIALOG_STYLE|wxRESIZE_BORDER|wxSTAY_ON_TOP, const wxString& name = wxT("frmPerson") );
		~frmPersonGUI();
	
};

///////////////////////////////////////////////////////////////////////////////
/// Class frmEntryGUI
///////////////////////////////////////////////////////////////////////////////
class frmEntryGUI : public wxDialog 
{
	private:
	
	protected:
		wxStaticText* m_staticText2;
		wxStaticText* m_staticText8;
		wxChoice* ddlName;
		wxStaticText* m_staticText9;
		wxDatePickerCtrl* dteEntryDate;
		wxStaticText* m_staticText10;
		wxSpinCtrl* txtSystolic;
		wxStaticText* m_staticText11;
		wxSpinCtrl* txtDiastolic;
		wxStaticText* m_staticText12;
		wxSpinCtrl* txtHeartRate;
		wxStaticText* m_staticText13;
		wxTextCtrl* txtNotes;
		wxStaticLine* m_staticline2;
		wxButton* btnCancel;
		wxButton* btnOk;
		
		// Virtual event handlers, overide them in your derived class
		virtual void btnCancel_Clicked( wxCommandEvent& event ){ event.Skip(); }
		virtual void btnOk_Clicked( wxCommandEvent& event ){ event.Skip(); }
		
	
	public:
		wxStaticBitmap* imgHeader;
		frmEntryGUI( wxWindow* parent, wxWindowID id = wxID_frmEntryGUI, const wxString& title = wxT("Blood Presure Entry"), const wxPoint& pos = wxDefaultPosition, const wxSize& size = wxSize( 493,498 ), long style = wxCAPTION|wxDEFAULT_DIALOG_STYLE );
		~frmEntryGUI();
	
};

///////////////////////////////////////////////////////////////////////////////
/// Class frmAboutGUI
///////////////////////////////////////////////////////////////////////////////
class frmAboutGUI : public wxDialog 
{
	private:
	
	protected:
		wxStaticBitmap* m_bitmap2;
		wxStaticText* m_staticText9;
		wxButton* btnClose;
		
		// Virtual event handlers, overide them in your derived class
		virtual void btnClose_Clicked( wxCommandEvent& event ){ event.Skip(); }
		
	
	public:
		frmAboutGUI( wxWindow* parent, wxWindowID id = wxID_frmAboutGUI, const wxString& title = wxT("About wx BP Monitor"), const wxPoint& pos = wxDefaultPosition, const wxSize& size = wxSize( 513,531 ), long style = wxCAPTION|wxDEFAULT_DIALOG_STYLE|wxSTAY_ON_TOP );
		~frmAboutGUI();
	
};

///////////////////////////////////////////////////////////////////////////////
/// Class frmMedicineGUI
///////////////////////////////////////////////////////////////////////////////
class frmMedicineGUI : public wxDialog 
{
	private:
	
	protected:
		
		wxGrid* dgMedicine;
		wxButton* btnDelete;
		wxButton* btnEdit;
		wxButton* btnNew;
		wxStaticLine* m_staticline1;
		
		wxStaticText* m_staticText18;
		wxTextCtrl* txtMedicine;
		wxStaticText* m_staticText19;
		wxTextCtrl* txtDosage;
		wxStaticText* m_staticText20;
		wxDatePickerCtrl* dteStartDate;
		wxStaticText* m_staticText21;
		wxDatePickerCtrl* dteEndDate;
		wxStaticText* m_staticText22;
		wxTextCtrl* txtDoctorName;
		wxStaticLine* m_staticline3;
		wxButton* btnClose;
		
		// Virtual event handlers, overide them in your derived class
		virtual void dgParent_CellChanged( wxGridEvent& event ){ event.Skip(); }
		virtual void dgParent_RightClick( wxGridEvent& event ){ event.Skip(); }
		virtual void btnDelete_Clicked( wxCommandEvent& event ){ event.Skip(); }
		virtual void btnEdit_OnClick( wxCommandEvent& event ){ event.Skip(); }
		virtual void btnNew_Clicked( wxCommandEvent& event ){ event.Skip(); }
		virtual void btnClose_Clicked( wxCommandEvent& event ){ event.Skip(); }
		
	
	public:
		frmMedicineGUI( wxWindow* parent, wxWindowID id = wxID_frmMedicineGUI, const wxString& title = wxT("Manage Medicine List"), const wxPoint& pos = wxDefaultPosition, const wxSize& size = wxSize( 544,498 ), long style = wxDEFAULT_DIALOG_STYLE );
		~frmMedicineGUI();
	
};

#endif //__wxBPMonitor__
