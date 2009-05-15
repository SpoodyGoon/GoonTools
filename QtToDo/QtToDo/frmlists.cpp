#include "frmlists.h"
#include "ui_frmlists.h"

frmLists::frmLists(QWidget *parent) :
    QDialog(parent),
    m_ui(new Ui::frmLists)
{
    m_ui->setupUi(this);
}

frmLists::~frmLists()
{
    delete m_ui;
}

void frmLists::changeEvent(QEvent *e)
{
    QDialog::changeEvent(e);
    switch (e->type()) {
    case QEvent::LanguageChange:
        m_ui->retranslateUi(this);
        break;
    default:
        break;
    }
}
