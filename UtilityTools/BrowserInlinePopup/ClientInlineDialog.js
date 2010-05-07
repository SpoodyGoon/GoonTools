/*
 * MS Ref = http://msdn.microsoft.com/en-us/library/ms532998(VS.85).aspx
 */

function ShowInlineDialog(strMessage, ElemParent)
{
	try 
	
	{
		var ParentElem = document.getElementById(ElemParent);
		// validate needed functions
		if (!document.createElement) 
			throw ("Browser not able to process Javascript function createElement()");		
		if (!document.createTextNode) 
			throw ("Browser not able to process Javascript function createTextNode()");		
		if (!document.getElementById) 
			throw ("Browser not able to process Javascript function getElementById()");		
		if (!document.appendChild) 
			throw ("Browser not able to process Javascript function appendChild()");		
		if (!document.removeChild) 
			throw ("Browser not able to process Javascript function removeChild()");
			
		var divWindow = document.createElement("div");
		var tblParent = document.createElement("table");
		var trBaseRow;
		var thTitle = document.createTHead();
		var tdContent;
		var tdFooter = document.createTFoot();
		// put it together
		/*
		trBaseRow.appendChild(thTitle);
		tblParent.appendChild(trBaseRow);
		trBaseRow = document.createElement("tr");
		trBaseRow.appendChild(tdContent);
		tblParent.appendChild(trBaseRow);
		//alert("got here " + tblParent.style.top.toString());
		trBaseRow = document.createElement("tr");
		trBaseRow.appendChild(tdFooter);
		tblParent.appendChild(trBaseRow);
		*/
		
		trBaseRow = tblParent.insertRow();
		thTitle = trBaseRow.insertCell();
		thTitle.innerHTML="Title";
		trBaseRow = tblParent.insertRow();
		tdContent = trBaseRow.insertCell();
		tdContent.innerHTML = "Content";
		trBaseRow = tblParent.insertRow();
		tdContent = trBaseRow.insertCell();
		tdContent.innerHTML = "Foot";
		
		ParentElem.appendChild(tblParent);
		
		tblParent.id = "tblParent";
		tblParent.name = "tblParent";
		thTitle.id = "thTitle";
		thTitle.name = "thTitle";
		tdContent.id = "tdContent";
		tdContent.name = "tdContent";
		tdFooter.id = "tdFooter";
		tdFooter.name = "tdFooter";
		
		tblParent.style.position = "absolute";
		tblParent.border = 1;
		tblParent.style.top = "100px";
		tblParent.style.left = "100px";
		tblParent.style.width = "390px";
		tblParent.style.height = "350px";
		//tblParent.style.display = "block";
		tblParent.style.zIndex = 999; 
		tblParent.style.backgroundColor = "#c9c9c9";
		
		thTitle.innerHTML = "Title";
		tdContent.innerHTML = "Content";
		tdFooter.innerHTML = "Footer";
		/*
		var rem = document.createElement("div");
		rem.innerHTML = '<iframe style="display:none" src="about:blank" id="rpc" name="rpc"></iframe>'
		ParentElem.appendChild(rem);
		*/
	} 
	catch (ex) 
	{
		alert(ex)
	}
}
