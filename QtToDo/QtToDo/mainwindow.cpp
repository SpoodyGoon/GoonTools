#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "frmlists.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent), ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_actionOpen_activated()
{

}

void MainWindow::on_pushButton_clicked()
{
    frmLists* fm = new frmLists(this);
    fm->show();
}
