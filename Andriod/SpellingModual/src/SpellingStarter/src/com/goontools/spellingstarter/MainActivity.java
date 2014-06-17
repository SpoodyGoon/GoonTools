package com.goontools.spellingstarter;

import android.os.Bundle;
import android.app.Activity;
import android.view.Menu;
import android.content.res.TypedArray;
import android.graphics.Typeface;
import android.util.AttributeSet;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;

public class MainActivity extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}
	
	private char[] letters = {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
	private void LoadSelectableLeters()
	{
		int resourceID = R.id.letterSelectTableLayout;
		TableLayout tableView = (TableLayout) this.findViewById(resourceID);
		int nRows=3;
		int nCols = 5;
		
		for(int i=0; i<nRows; i++)
		{
			TableRow row = new TableRow(this);
			for(int j = 0; j<nCols;i++)
			{
				TextView textView = new TextView(this);
				textView.setText(String.valueOf(letters[i + j]));
				textView.setTextSize((float) 15.5);
				textView.setTypeface(Typeface.DEFAULT_BOLD);
				
			}
		}
		
		
		
	}
	
	private void AddTableRow(TableLayout tableView)
	{
		
		
	}

}
