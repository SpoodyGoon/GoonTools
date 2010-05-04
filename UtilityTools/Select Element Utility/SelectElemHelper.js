/*
 A collection of javascript functions that can be
 helpful when dealing with select/option elements
 i.e. .NET dropdownlists
 */
// this can be used by referece files to
// determine if this file is loaded
var SelectElemHelper_Loaded = true;
function AddOption(SelectElem, text, value)
{
	try 
	{
		
		// check to see if we have a select element
		if (SelectElem.tagName.toLowerCase() != "select") 
			throw "Invalid element type at AddOption";
		var optn = document.createElement("option");
		optn.text = text;
		optn.value = value;
		SelectElem.options.add(optn);
	} 
	catch (ex) 
	{
		alert(ex);
	}
}

/* ########################## */
/* BEGIN VALIDATION FUNCTIONS */
// is this element a select element
function IsSelect(SelectElem)
{
	
if (SelectElem.tagName.toLowerCase() == "select") 
	{
		
		return true;
	}
	else 
	{
		alert('Invalid element type at SetSelectedIndex');
		
		return false;
	}
	
	return false;
}

// function to check to see if the select element
// is set to mutli-select
function IsMultiSelect(SelectElem)
{
	
	// first check to see if it is a select element	
	if (IsSelect(SelectElem)) 
	{
		
if (SelectElem.multiple == true) 
		{
			
			return true;
		}
		else 
		{
			alert("Select Element is not set to allow Multiple Selects at MultiSelectGet");
			
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
	var Ret = -1;
	
	// check to see if we have a select element
	if (IsSelect(SelectElem)) 
	{
		for (var i = 0; i < SelectElem.options.length; i++) 
		{
			
if (SelectElem.options[i].value.toLower() == SelectedValue.toLower()) 
			{
				
				return i;
			}
		}
		
		return -1;
	}
	
	return -1;
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
			
if (SelectElem.options[i].text.toLower() == SelectedText.toLower()) 
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
function MultiSelectGet(SelectElem)
{
	var SelectedArray = null;
	try 
	{		
		if (IsMultiSelect(SelectElem)) 
		{
			SelectedArray = new Array();
			
			if (SelectElem.selectedIndex != -1) 
			{
				for (var i = 0; i < SelectedElem.options.lenght; i++) 
				{					
					if (SelectElem.options[i].selected) 
					{
						SelectedArray.push(SelectElem.options[i].value);
					}
				}
			}
		}
	} 
	catch (ex) 
	{
		alert(ex);
	}
	
	return SelectedArray;
}

// set all the selected options in a select/list element
// and from a supplied array
function MultiSelectSet(SelectElem, SelectArray)
{
	try 
	{
		// check to see if we have a select element
		if (IsMultiSelect(SelectElem)) 
		{
			
			if (isNaN(GenUtil_Loaded) || GenUtil_Loaded == null || GenUtil_Loaded == undefined) 
				throw "Missing Refernce to GenUtil.js file at MultiSelectSet";
			
			if (typeOf(SelectArray) != "array") 
				throw "Invalid Array Passed into function at MultiSelectSet";
				
			for (var i = 0; i < SelectedElem.options.lenght; i++) 
			{				
				if (SelectArray.indexOf(SelectElem.options[i].value) > -1) 
				{
					SelectElem.options[i].selected = true;
				}
			}
		}
	} 
	catch (ex) 
	{
		alert(ex);
	}
	
	return SelectedArray;
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
	if (SelectElem.tagName.toLowerCase() == "select") 
	{
		while (SelectElem.options.length > 0) 
		{
			SelectElem.options[0] = null;
		}
	}
	else 
	{
		alert('Invalid element type at SetSelectedIndex');
	}
}

// used to clear all the select elements in a page, form
// or other child elements
function ClearAllLists(ParentElem)
{
	
	// if a parent element is supplied then get only
	// the select elements that are children of that parent
	if (ParentElem != null) 
	{
		var ddlIDArray = ParentElem.getElementsByTagName("select");
		for (var i = 0; i < ddlIDArray.lenght; i++) 
		{
			ClearDropDown(ddlIDArray[i]);
			ddlIDArray[i].selectedIndex = -1;
		}
	}
	else 
	{
		// if no parent is supplied process all the select elements on that page/document
		var ddlIDArray = document.getElementsByTagName("select");
		for (var i = 0; i < ddlIDArray.lenght; i++) 
		{
			ClearDropDown(ddlIDArray[i]);
			ddlIDArray[i].selectedIndex = -1;
		}
	}
}

/* END CLEAR ELEMENT FUNCTIONS */
/* ########################### */
