/*
	A collection of javascript functions that can be
	helpful when dealing with select/option elements
	i.e. .NET dropdownlists
*/
// this can be used by referece files to
// determine if this file is loaded
var SelectElemHelper_Loaded = true;

/* ####################### */
/* BEGIN OPTION ADD REMOVE */

function AddOption(SelectElem, text, value)
{
	if (IsSelect(SelectElem)) 
	{			
		var optn = document.createElement("option");
		optn.text = text;
		optn.value = value;
		SelectElem.options.add(optn);
	}
}

function RemoveSelectedOption(SelectElem)
{
	if (IsSelect(SelectElem)) 
	{
		for (var i = 0; i < SelectElem.options.length; i++) 
		{			
			if (SelectElem.options[i].selected) 
			{				
				SelectElem.remove(i);
			}
		}	
	}
}

function RemoveOptionByValue(SelectElem, SelectValue)
{
	if (IsSelect(SelectElem)) 
	{
		// there may be more than one option with the same value
		// so loop through all of them
		for (var i = 0; i < SelectElem.options.length; i++) 
		{			
			if (SelectElem.options[i].value.toLowerCase() == SelectedValue.toLowerCase()) 
			{				
				SelectElem.remove(i);
			}
		}			
	}
}

function RemoveOptionByText(SelectElem, SelectedText)
{
	try
	{
		if (IsSelect(SelectElem)) 
		{
			// there may be more than one option with the same value
			// so loop through all of them
			for (var i = 0; i < SelectElem.options.length; i++) 
			{			
				if (SelectElem.options[i].text.toLowerCase() == SelectedText.toLowerCase()) 
				{				
					SelectElem.remove(i);
				}
			}			
		}
	}
	catch(ex)
	{
		throw ex;
	}
}

function RemoveAllOptions(SelectElem)
{
	try
	{
		if (IsSelect(SelectElem)) 
		{
			for(var i = SelectElem.options.length - 1; i >= 0; i--)
			{
				SelectElem.remove(i);
			}		
		}
	}
	catch(ex)
	{
		throw ex;
	}
}

/* END OPTION ADD REMOVE */
/* ##################### */

/* ===================================================== */

/* ########################## */
/* BEGIN VALIDATION FUNCTIONS */

// is this element a select element
function IsSelect(SelectElem)
{	
	if (SelectElem.tagName.trim().toLowerCase() == "select") 
	{		
		return true;
	}
	else 
	{		
		throw "Referenced Element is not a select element";
		return false;
	}	
	return false;
}

// function to check to see if the select element
// is set to mutli-select
function IsMultiSelect(SelectElem)
{	
	// first check to see if it is a select element	
	if(IsSelect(SelectElem))
	{	
		if(SelectElem.multiple == true)
		{				
			return true;
		}
		else 
		{		
			throw "Select Element is not set to allow Multiple Selections";
			return false;
		}	
	}
	return false;
}

/* END VALIDATION FUNCTIONS */
/* ######################## */

/* ===================================================== */

/* ############################ */
/* BEGIN SET SELECTED FUNCTIONS */

// set the selected index of the passed in select element
// to the option of the value passed in
function GetSelectIndexByValue(SelectElem, SelectedValue)
{	
	// check to see if we have a select element
	if (IsSelect(SelectElem)) 
	{
		for (var i = 0; i < SelectElem.options.length; i++) 
		{			
			if (SelectElem.options[i].value.toString().toLowerCase() == SelectedValue.toString().toLowerCase()) 
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
	if (IsSelect(SelectElem)) 
	{
		for (var i = 0; i < SelectElem.options.length; i++) 
		{			
			if (SelectElem.options[i].text.toLowerCase() == SelectedText.toLowerCase()) 
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
function SetSelectIndexByValue(SelectElem, SelectedValue)
{	
	// check to see if we have a select element
	if (IsSelect(SelectElem)) 
	{
		SelectElem.selectedIndex = GetSelectIndexByValue(SelectElem, SelectedValue);
	}
}

// set the selected index of the passed in select element
// to the option of the value passed in
function SetSelectIndexByText(SelectElem, SelectedText)
{	
	// check to see if we have a select element
	if (IsSelect(SelectElem)) 
	{
		SelectElem.selectedIndex = GetSelectIndexByText(SelectElem, SelectedText);
	}
}

/* END SET SELECTED FUNCTIONS */
/* ########################## */

/* ===================================================== */

/* ############################ */
/* BEGIN MULTI-SELECT FUNCTIONS */

// gets all the selected options in a select/list element
// and returns them in an array
function MultiSelectGetByValue(SelectElem)
{
	var SelectArray = null;
	if(IsMultiSelect(SelectElem))
	{		
		SelectArray = new Array();
		if(SelectElem.selectedIndex != -1)
		{
			for(var i = 0; i < SelectElem.options.length; i ++)
			{
				if(SelectElem.options[i].selected)
				{
					SelectArray.push(SelectElem.options[i].value);
				}
			}
		}
	}
	return SelectArray;
}

// gets all the selected options in a select/list element
// and returns them in an array
function MultiSelectGetByText(SelectElem)
{
	var SelectArray = null;
	if(IsMultiSelect(SelectElem))
	{		
		SelectArray = new Array();
		if(SelectElem.selectedIndex != -1)
		{
			for(var i = 0; i < SelectElem.options.length; i ++)
			{
				if(SelectElem.options[i].selected)
				{
					SelectArray.push(SelectElem.options[i].test);
				}
			}
		}
	}
	return SelectArray;
}

// set all the selected options in a select/list element
// and from a supplied array
function MultiSelectByValueSet(SelectElem, SelectArray)
{
	if(IsMultiSelect(SelectElem))
	{		
		if(isNaN(GenUtil_Loaded) || GenUtil_Loaded == null || GenUtil_Loaded==undefined)
			throw "Missing Refernce to GenUtil.js file at MultiSelectSet";
		
		/*
		// FIXME Doesn't work	
		if(typeOf(SelectArray) != "array")
			throw "Invalid Array Passed into function at MultiSelectSet";
		*/
			
		for(var i = 0; i < SelectElem.options.length; i ++)
		{
			if(SelectArray.indexOf(SelectElem.options[i].value) > -1)
			{
				SelectElem.options[i].selected = true;
			}
		}
	}
	return SelectArray;
}

// set all the selected options in a select/list element
// and from a supplied array
function MultiSelectByTextSet(SelectElem, SelectArray)
{
	if(IsMultiSelect(SelectElem))
	{		
		if(isNaN(GenUtil_Loaded) || GenUtil_Loaded == null || GenUtil_Loaded==undefined)
			throw "Missing Refernce to GenUtil.js file at MultiSelectSet";
		
		/*
		// FIXME Doesn't work	
		if(typeOf(SelectArray) != "array")
			throw "Invalid Array Passed into function at MultiSelectSet";
		*/
			
		for(var i = 0; i < SelectElem.options.length; i ++)
		{
			if(SelectArray.indexOf(SelectElem.options[i].text) > -1)
			{
				SelectElem.options[i].selected = true;
			}
		}
	}
	return SelectArray;
}

/* END MULTI-SELECT FUNCTIONS */
/* ########################## */

/* ===================================================== */

/* ############################# */
/* BEGIN CLEAR ELEMENT FUNCTIONS */

// clears a select/dropdownlist element of all options
function ClearDropDown(SelectElem)
{
	// check to see if we have a select element
	if(IsSelect(SelectElem))
	{
		while(SelectElem.options.length > 0)
		{
			SelectElem.options[0] = null;
		}
	}
}

// used to clear all the select elements in a page, form
// or other child elements
function ClearAllLists(ParentElem)
{
	// if a parent element is supplied then get only
	// the select elements that are children of that parent
	if(ParentElem != null)
	{
		var ddlIDArray = ParentElem.getElementsByTagName("select");
		for(var i = 0; i < ddlIDArray.length; i++)
		{
			ClearDropDown(ddlIDArray[i]);
			ddlIDArray[i].selectedIndex = -1;
		}
	}
	else
	{
		// if no parent is supplied process all the select elements on that page/document
		var ddlIDArray = document.getElementsByTagName("select");
		for(var i = 0; i < ddlIDArray.length; i++)
		{
			ClearDropDown(ddlIDArray[i]);
			ddlIDArray[i].selectedIndex = -1;
		}
	}
}

/* END CLEAR ELEMENT FUNCTIONS */
/* ########################### */
