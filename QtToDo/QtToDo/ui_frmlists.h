/********************************************************************************
** Form generated from reading ui file 'frmlists.ui'
**
** Created: Fri May 15 15:36:30 2009
**      by: Qt User Interface Compiler version 4.5.1
**
** WARNING! All changes made in this file will be lost when recompiling ui file!
********************************************************************************/

#ifndef UI_FRMLISTS_H
#define UI_FRMLISTS_H

#include <QtCore/QVariant>
#include <QtGui/QAction>
#include <QtGui/QApplication>
#include <QtGui/QButtonGroup>
#include <QtGui/QDialog>
#include <QtGui/QDialogButtonBox>
#include <QtGui/QHeaderView>
#include <QtGui/QLabel>
#include <QtGui/QTreeView>
#include <QtGui/QVBoxLayout>
#include <QtGui/QWidget>

QT_BEGIN_NAMESPACE

class Ui_frmLists
{
public:
    QDialogButtonBox *buttonBox;
    QWidget *verticalLayoutWidget;
    QVBoxLayout *vl1;
    QLabel *label;
    QWidget *verticalLayoutWidget_2;
    QVBoxLayout *verticalLayout;
    QTreeView *treeView;

    void setupUi(QDialog *frmLists)
    {
        if (frmLists->objectName().isEmpty())
            frmLists->setObjectName(QString::fromUtf8("frmLists"));
        frmLists->resize(400, 360);
        buttonBox = new QDialogButtonBox(frmLists);
        buttonBox->setObjectName(QString::fromUtf8("buttonBox"));
        buttonBox->setGeometry(QRect(100, 320, 181, 32));
        buttonBox->setOrientation(Qt::Horizontal);
        buttonBox->setStandardButtons(QDialogButtonBox::Cancel|QDialogButtonBox::Ok);
        verticalLayoutWidget = new QWidget(frmLists);
        verticalLayoutWidget->setObjectName(QString::fromUtf8("verticalLayoutWidget"));
        verticalLayoutWidget->setGeometry(QRect(0, 0, 401, 51));
        vl1 = new QVBoxLayout(verticalLayoutWidget);
        vl1->setObjectName(QString::fromUtf8("vl1"));
        vl1->setContentsMargins(0, 0, 0, 0);
        label = new QLabel(verticalLayoutWidget);
        label->setObjectName(QString::fromUtf8("label"));
        QSizePolicy sizePolicy(QSizePolicy::Expanding, QSizePolicy::Expanding);
        sizePolicy.setHorizontalStretch(0);
        sizePolicy.setVerticalStretch(0);
        sizePolicy.setHeightForWidth(label->sizePolicy().hasHeightForWidth());
        label->setSizePolicy(sizePolicy);
        QFont font;
        font.setFamily(QString::fromUtf8("Arial Black"));
        font.setPointSize(14);
        font.setBold(false);
        font.setItalic(false);
        font.setWeight(10);
        label->setFont(font);
        label->setFrameShape(QFrame::WinPanel);
        label->setFrameShadow(QFrame::Plain);
        label->setScaledContents(true);
        label->setAlignment(Qt::AlignHCenter|Qt::AlignTop);

        vl1->addWidget(label);

        verticalLayoutWidget_2 = new QWidget(frmLists);
        verticalLayoutWidget_2->setObjectName(QString::fromUtf8("verticalLayoutWidget_2"));
        verticalLayoutWidget_2->setGeometry(QRect(0, 50, 401, 201));
        verticalLayout = new QVBoxLayout(verticalLayoutWidget_2);
        verticalLayout->setObjectName(QString::fromUtf8("verticalLayout"));
        verticalLayout->setContentsMargins(0, 0, 0, 0);
        treeView = new QTreeView(verticalLayoutWidget_2);
        treeView->setObjectName(QString::fromUtf8("treeView"));

        verticalLayout->addWidget(treeView);


        retranslateUi(frmLists);
        QObject::connect(buttonBox, SIGNAL(accepted()), frmLists, SLOT(accept()));
        QObject::connect(buttonBox, SIGNAL(rejected()), frmLists, SLOT(reject()));

        QMetaObject::connectSlotsByName(frmLists);
    } // setupUi

    void retranslateUi(QDialog *frmLists)
    {
        frmLists->setWindowTitle(QApplication::translate("frmLists", "Dialog", 0, QApplication::UnicodeUTF8));
        label->setStyleSheet(QApplication::translate("frmLists", "color: rgb(255, 255, 255);\n"
"background-color: rgb(82, 91, 141);\n"
"font: 87 14pt \"Arial Black\";", 0, QApplication::UnicodeUTF8));
        label->setText(QApplication::translate("frmLists", "Task Lists", 0, QApplication::UnicodeUTF8));
        Q_UNUSED(frmLists);
    } // retranslateUi

};

namespace Ui {
    class frmLists: public Ui_frmLists {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_FRMLISTS_H
