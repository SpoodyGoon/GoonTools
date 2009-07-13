#ifndef FRMMAIN_H
#define FRMMAIN_H

#include <QtGui/QMainWindow>

namespace Ui
{
    class frmMain;
}

class frmMain : public QMainWindow
{
    Q_OBJECT

public:
    frmMain(QWidget *parent = 0);
    ~frmMain();

private:
    Ui::frmMain *ui;
};

#endif // FRMMAIN_H
