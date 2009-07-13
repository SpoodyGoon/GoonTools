/********************************************************************************
** Form generated from reading ui file 'frmmain.ui'
**
** Created: Sun Jul 12 20:58:10 2009
**      by: Qt User Interface Compiler version 4.4.3
**
** WARNING! All changes made in this file will be lost when recompiling ui file!
********************************************************************************/

#ifndef UI_FRMMAIN_H
#define UI_FRMMAIN_H

#include <QtCore/QVariant>
#include <QtGui/QAction>
#include <QtGui/QApplication>
#include <QtGui/QButtonGroup>
#include <QtGui/QMainWindow>
#include <QtGui/QMenu>
#include <QtGui/QMenuBar>
#include <QtGui/QStatusBar>
#include <QtGui/QToolBar>
#include <QtGui/QWidget>

QT_BEGIN_NAMESPACE

class Ui_frmMain
{
public:
    QAction *actionNew_Entry;
    QAction *actionUsers;
    QAction *actionQuit;
    QAction *actionAbout;
    QWidget *centralWidget;
    QMenuBar *menuBar;
    QMenu *menuFile;
    QMenu *menuHelp;
    QToolBar *mainToolBar;
    QStatusBar *statusBar;

    void setupUi(QMainWindow *frmMain)
    {
    if (frmMain->objectName().isEmpty())
        frmMain->setObjectName(QString::fromUtf8("frmMain"));
    frmMain->resize(720, 530);
    actionNew_Entry = new QAction(frmMain);
    actionNew_Entry->setObjectName(QString::fromUtf8("actionNew_Entry"));
    actionUsers = new QAction(frmMain);
    actionUsers->setObjectName(QString::fromUtf8("actionUsers"));
    actionQuit = new QAction(frmMain);
    actionQuit->setObjectName(QString::fromUtf8("actionQuit"));
    actionAbout = new QAction(frmMain);
    actionAbout->setObjectName(QString::fromUtf8("actionAbout"));
    centralWidget = new QWidget(frmMain);
    centralWidget->setObjectName(QString::fromUtf8("centralWidget"));
    frmMain->setCentralWidget(centralWidget);
    menuBar = new QMenuBar(frmMain);
    menuBar->setObjectName(QString::fromUtf8("menuBar"));
    menuBar->setGeometry(QRect(0, 0, 720, 29));
    menuFile = new QMenu(menuBar);
    menuFile->setObjectName(QString::fromUtf8("menuFile"));
    menuHelp = new QMenu(menuBar);
    menuHelp->setObjectName(QString::fromUtf8("menuHelp"));
    frmMain->setMenuBar(menuBar);
    mainToolBar = new QToolBar(frmMain);
    mainToolBar->setObjectName(QString::fromUtf8("mainToolBar"));
    frmMain->addToolBar(Qt::TopToolBarArea, mainToolBar);
    frmMain->insertToolBarBreak(mainToolBar);
    statusBar = new QStatusBar(frmMain);
    statusBar->setObjectName(QString::fromUtf8("statusBar"));
    frmMain->setStatusBar(statusBar);

    menuBar->addAction(menuFile->menuAction());
    menuBar->addAction(menuHelp->menuAction());
    menuFile->addAction(actionNew_Entry);
    menuFile->addAction(actionUsers);
    menuFile->addSeparator();
    menuFile->addAction(actionQuit);
    menuHelp->addAction(actionAbout);
    mainToolBar->addSeparator();

    retranslateUi(frmMain);

    QMetaObject::connectSlotsByName(frmMain);
    } // setupUi

    void retranslateUi(QMainWindow *frmMain)
    {
    frmMain->setWindowTitle(QApplication::translate("frmMain", "frmMain", 0, QApplication::UnicodeUTF8));
    actionNew_Entry->setText(QApplication::translate("frmMain", "New Entry", 0, QApplication::UnicodeUTF8));
    actionUsers->setText(QApplication::translate("frmMain", "Users", 0, QApplication::UnicodeUTF8));
    actionQuit->setText(QApplication::translate("frmMain", "Quit", 0, QApplication::UnicodeUTF8));
    actionAbout->setText(QApplication::translate("frmMain", "About", 0, QApplication::UnicodeUTF8));
    menuFile->setTitle(QApplication::translate("frmMain", "File", 0, QApplication::UnicodeUTF8));
    menuHelp->setTitle(QApplication::translate("frmMain", "Help", 0, QApplication::UnicodeUTF8));
    } // retranslateUi

};

namespace Ui {
    class frmMain: public Ui_frmMain {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_FRMMAIN_H
