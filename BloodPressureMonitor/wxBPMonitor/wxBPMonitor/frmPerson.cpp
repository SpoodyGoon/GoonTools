#include "frmPerson.h"
#include <wx/msgdlg.h>

frmPerson::frmPerson( wxWindow* parent )
:
frmPersonGUI( parent )
{

}

void frmPerson::btnClear_Clicked( wxCommandEvent& event )
{
    txtPersonName->Clear();
}

void frmPerson::btnAddEdit_OnClick( wxCommandEvent& event )
{
    wxString strPersonName = txtPersonName->GetValue();
    if(strPersonName.Length() > 0)
    {
        
    }
    else
    {
	   wxMessageDialog *dial = new wxMessageDialog(NULL, wxT("Person's Name is requred."), wxT("Name Required"), wxOK);
       dial->ShowModal();
    }
}

void frmPerson::dgPerson_CellSelected( wxGridEvent& event )
{
	// TODO: Implement dgPerson_CellSelected
}

void frmPerson::btnClose_Clicked( wxCommandEvent& event )
{
	this->Close();
}
