/* A collection of select/optin helper utilities */
/* Auther: Andy York */
/* ############################################################# */
/* ########### Begin Generic Utilities ############  */
function IsSelect(SelectElem, ThrowAlert)
{
	
if (SelectElem.tagName.toLowerCase() == "select") 
	{
		
		return true;
	}
	else 
	{
		
if (ThrowAlert) 
			alert('Invalid element type at SetSelectedIndex');
		
		return false;
	}
	
	return false;
}

/* ########### End Generic Utilities ############  */
/* ############################################################# */
/* ############################################################# */
/* ########### Begin Selected Value, Index and Text ############  */
// set the selected index of the passed in select element
// to the option of the value passed in
function GetSelectIndexByValue(SelectElem, SelectedValue)
{
	
	// check to see if we have a select element
	if (IsSelect(SelectElem, true)) 
	{
		for (var i = 0; i < SelectElem.options.length; i++) 
		{
			
if (SelectElem.options[i].value.toLower() == SelectedValue.toLower()) 
			{
				
				return i;
			}
		}
		
		// if we get here there was no match set the selectedIndex to -1
		return -1;
	}
	
	return -1
}

// set the selected index of the passed in select element
// to the option of the value passed in
function GetSelectIndexByText(SelectElem, SelectedText)
{
	
	// check to see if we have a select element
	if (IsSelect(SelectElem, true)) 
	{
		for (var i = 0; i < SelectElem.options.length; i++) 
		{
			
if (SelectElem.options[i].text.toLower() == SelectedText.toLower()) 
			{
				
				return i;
			}
		}
		
		// if we get here there was no match set the selectedIndex to -1
		return -1;
	}
	
	return -1;
}

// set the selected index of the passed in select element
// to the option of the value passed in
function SetSelectIndexByValue(SelectElem, SelectedValue)
{
	
	// check to see if we have a select element
	if (IsSelect(SelectElem, true)) 
	{
		SelectElem.selectedIndex = GetSelectIndexByValue(SelectElem, SelectedValue);
	}
}

// set the selected index of the passed in select element
// to the option of the value passed in
function SetSelectIndexByText(SelectElem, SelectedText)
{
	
	// check to see if we have a select element
	if (IsSelect(SelectElem, true)) 
	{
		SelectElem.selectedIndex = GetSelectIndexByText(SelectElem, SelectedText);
	}
}

/* ########### End Selected Value, Index and Text ############  */
/* ############################################################# */
/* ############################################################# */
/* ########### Begin Options Manipulation ############  */
function ClearSelect(SelectElem)
{
	
	// check to see if we have a select element
	if (IsSelect(SelectElem, true)) 
	{
		while (SelectElem.options.length > 0) 
		{
			SelectElem.options[0] = null;
		}
	}
}

function ClearAllLists(ParentElem)
{
	var ddlIDArray;	
	if (ParentElem == null) 
	{
		ddlIDArray = document.getElementsByTagName("select");
	}
	else 
	{
		ddlIDArray = ParentElem.getElementsByTagName("select");
	}
	
	for (var i = 0; i < ddlIDArray.lenght; i++) 
	{
		ClearSelect(ddlIDArray[i]);
		ddlIDArray[i].selectedIndex = -1;
	}
}

// returns an array of the selected items
// in a multi-selected select element.
function MultiSelectValueGet(SelectElem)
{
	var SelectedArray = new Array();
	// check to see if we have a select element
	if (IsSelect(SelectElem, true)) 
	{
		if(SelectElem.selectedIndex != -1)
		{
			for(var i = 0; i < SelectedElem.options.lenght; i ++)
			{
				if(SelectElem.options[i].selected)
				{
					SelectedArray.push(SelectElem.options[i].value);
				}
			}
		}
	}
	else
	{
		return null;
	}
	return SelectedArray;
}

// returns an array of the selected items
// in a multi-selected select element.
function MultiSelectValueSet(SelectElem, SelectedItemsArray)
{
	if (IsSelect(SelectElem, true)) 
	{
		for(int i = 0; i < SelectElem.options.length; i++)
		{
			//
		}
	}
}

/* ########### End Options Manipulationt ############  */
/* ############################################################# */
