package pkgMain;

import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JButton;
import javax.swing.SpringLayout;
import java.awt.GridLayout;
import javax.swing.BoxLayout;
import java.awt.GridBagLayout;
import java.awt.GridBagConstraints;
import java.awt.Insets;
import javax.swing.JLabel;
import java.awt.Font;
import java.awt.Toolkit;
import javax.swing.ImageIcon;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;

public class frmMain {

	private JFrame frmBloodPressureMonitor;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					frmMain window = new frmMain();
					window.frmBloodPressureMonitor.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the application.
	 */
	public frmMain() {
		initialize();
	}

	/**
	 * Initialize the contents of the frame.
	 */
	private void initialize() {
		frmBloodPressureMonitor = new JFrame();
		frmBloodPressureMonitor.setIconImage(Toolkit.getDefaultToolkit().getImage(frmMain.class.getResource("/images/icon_small.png")));
		frmBloodPressureMonitor.setTitle("Blood Pressure Monitor");
		frmBloodPressureMonitor.setBounds(100, 100, 339, 254);
		frmBloodPressureMonitor.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		GridBagLayout gridBagLayout = new GridBagLayout();
		gridBagLayout.columnWidths = new int[]{50, 0, 50, 0};
		gridBagLayout.rowHeights = new int[]{35, 35, 35, 35, 35, 0};
		gridBagLayout.columnWeights = new double[]{1.0, 0.0, 1.0, Double.MIN_VALUE};
		gridBagLayout.rowWeights = new double[]{0.0, 0.0, 0.0, 0.0, 0.0, Double.MIN_VALUE};
		frmBloodPressureMonitor.getContentPane().setLayout(gridBagLayout);
		
		JLabel lblBloodPresureMonitor = new JLabel("Blood Presure Monitor");
		lblBloodPresureMonitor.setFont(new Font("DejaVu Sans", Font.BOLD, 12));
		GridBagConstraints gbc_lblBloodPresureMonitor = new GridBagConstraints();
		gbc_lblBloodPresureMonitor.anchor = GridBagConstraints.SOUTH;
		gbc_lblBloodPresureMonitor.insets = new Insets(0, 0, 5, 5);
		gbc_lblBloodPresureMonitor.gridx = 1;
		gbc_lblBloodPresureMonitor.gridy = 0;
		frmBloodPressureMonitor.getContentPane().add(lblBloodPresureMonitor, gbc_lblBloodPresureMonitor);
		
		JLabel lblDesktopVersion = new JLabel(" Desktop Version");
		lblDesktopVersion.setFont(new Font("DejaVu Sans", Font.ITALIC, 12));
		GridBagConstraints gbc_lblDesktopVersion = new GridBagConstraints();
		gbc_lblDesktopVersion.anchor = GridBagConstraints.NORTH;
		gbc_lblDesktopVersion.insets = new Insets(0, 0, 5, 5);
		gbc_lblDesktopVersion.gridx = 1;
		gbc_lblDesktopVersion.gridy = 1;
		frmBloodPressureMonitor.getContentPane().add(lblDesktopVersion, gbc_lblDesktopVersion);
		
		JButton btnNewReading = new JButton("New Reading...");
		btnNewReading.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				btnNewReadingMouseClicked(e);
			}
		});
		GridBagConstraints gbc_btnNewReading = new GridBagConstraints();
		gbc_btnNewReading.fill = GridBagConstraints.HORIZONTAL;
		gbc_btnNewReading.insets = new Insets(0, 0, 5, 5);
		gbc_btnNewReading.gridx = 1;
		gbc_btnNewReading.gridy = 2;
		frmBloodPressureMonitor.getContentPane().add(btnNewReading, gbc_btnNewReading);
		
		JButton btnOptions = new JButton("Options...");
		GridBagConstraints gbc_btnOptions = new GridBagConstraints();
		gbc_btnOptions.anchor = GridBagConstraints.BELOW_BASELINE;
		gbc_btnOptions.fill = GridBagConstraints.HORIZONTAL;
		gbc_btnOptions.insets = new Insets(0, 0, 5, 5);
		gbc_btnOptions.gridx = 1;
		gbc_btnOptions.gridy = 3;
		frmBloodPressureMonitor.getContentPane().add(btnOptions, gbc_btnOptions);
		
		JButton btnQuit = new JButton("Quit");
		btnQuit.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				btnQuitMouseClicked(e);
			}
		});
		btnQuit.setIcon(new ImageIcon(frmMain.class.getResource("/images/exit.png")));
		GridBagConstraints gbc_btnQuit = new GridBagConstraints();
		gbc_btnQuit.insets = new Insets(0, 0, 0, 5);
		gbc_btnQuit.fill = GridBagConstraints.HORIZONTAL;
		gbc_btnQuit.gridx = 1;
		gbc_btnQuit.gridy = 4;
		frmBloodPressureMonitor.getContentPane().add(btnQuit, gbc_btnQuit);
	}
	protected static void btnQuitMouseClicked(MouseEvent e) {
	}
	protected static void btnNewReadingMouseClicked(MouseEvent e) {
		frmNewReading fm = new frmNewReading();
		fm.setVisible(true);
	}
}
