#include "frmPerson.h"

frmPerson::frmPerson( wxWindow* parent )
:
frmPersonGUI( parent )
{

}

void frmPerson::btnAddEdit_OnClick( wxCommandEvent& event )
{
	// TODO: Implement btnAddEdit_OnClick
}

void frmPerson::btnClose_Clicked( wxCommandEvent& event )
{
	this->Close();
}
