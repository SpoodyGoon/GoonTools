/*
	A collection of generic javascript functions and prototypes
	that can be helpful when for simple operations
*/
// this can be used by referece files to
// determine if this file is loaded
var GenUtil_Loaded = true;

// Simple trim function
String.prototype.trim = function() 
{
	return this.replace(/^\s+|\s+$/g,"");
}

// index of fix for IE
if(!Array.indexOf){
	Array.prototype.indexOf = function(obj){
	    for(var i=0; i<this.length; i++){
	        if(this[i]==obj){
	            return i;
	        }
	    }
	    return -1;
	}
}

function Sleep(SleepSeconds)
{
	setTimeout( function () { return; }, SleepSeconds * 1000);
}

// validating an element to make sure it is valid
function ValidateElement(ValElem, ShowError)
{
	if(isNaN(ValElem) || ValElem == null)
	{
		if(ShowError == true)
			alert("Invalid HTML DOM Element");
			
		return false;
	}
	return true;
}

// first attempt at this function may be a bad idea
// the idea is to find a good IsNumeric function
String.prototype.IsNumeric = function() 
{
	// try catch should not be needed but lets
	// put it there anyways
	try
	{
		if(this.trim().length == 0)
		{
			return false;
		}
		return !isNaN(parseFloat(this)) && isFinite(this);
	}
	catch(e)
	{
		return false;	
	}
	return true;
}

// Is this string parsable to an int
String.prototype.IsInt = function() 
{
	try
	{
		if(this.trim().length == 0)
		{
			return false;
		}
		return !isNaN(parseInt(this));
	}
	catch(e)
	{
		return false;	
	}
	return true;
}

// typeof with array support
/* FIXME: Don't work in Firefox
function typeOf(obj) {
  if ( typeof(obj) == 'object' )
    if (obj.length)
      return 'array';
    else
      return 'object';
    } else
  return typeof(obj);
}
 */
String.prototype.CurrencyFormatted = function()
{
	var i = parseFloat(this);
	if(isNaN(i)) { i = 0.00; }
	var minus = '';
	if(i < 0) { minus = '-'; }
	i = Math.abs(i);
	i = parseInt((i + .005) * 100);
	i = i / 100;
	s = new String(i);
	if(s.indexOf('.') < 0) { s += '.00'; }
	if(s.indexOf('.') == (s.length - 2)) { s += '0'; }
	s = minus + s;
	return '$' + s;
}


function HandleError(CurrentError, Title)
{
	// TODO: finish this object
	/*
	this.ErrorDesc = CurrentError;
	this.ErrorTitle = Title;
	if(!isNaN(CurrentError.number) && CurrentError.number != null && CurrentError.number != undefined)
	{
		this.ErrorNum = CurrentError.number.toString();
	}
	else
	{
		this.ErrorNum = "";
	}
	
	if(this.Title != null && !isNaN(this.Title) && this.Title.length > 1)
	{
		alert("\t\t\t" + this.Title + "\n\n" + this.ErrorDesc);
	}
	else
	{
	*/
		alert(CurrentError);
	//}
	
}

