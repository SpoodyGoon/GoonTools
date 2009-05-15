#ifndef FRMLISTS_H
#define FRMLISTS_H

#include <QtGui/QDialog>

namespace Ui {
    class frmLists;
}

class frmLists : public QDialog {
    Q_OBJECT
    Q_DISABLE_COPY(frmLists)
public:
    explicit frmLists(QWidget *parent = 0);
    virtual ~frmLists();

protected:
    virtual void changeEvent(QEvent *e);

private:
    Ui::frmLists *m_ui;
};

#endif // FRMLISTS_H
