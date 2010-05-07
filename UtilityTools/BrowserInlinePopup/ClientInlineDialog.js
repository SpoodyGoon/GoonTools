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
		tblParent.style.position = "absolute";
		tblParent.style.top = "100px";
		tblParent.style.left = "100px";
		tblParent.style.width = "390px";
		tblParent.style.height = "350px";
		//tblParent.style.display = "block";
		tblParent.style.zIndex = 999; 
		tblParent.style.backgroundColor = "#c9c9c9";
		var trBaseRow = document.createElement("tr");
		var thTitle = document.createElement("th");
		thTitle.innerHTML = "Title";
		var tdContent = document.createElement("td");
		tdContent.innerHTML = "Content";
		var tdFooter = document.createElement("td");
		tdFooter.innerHTML = "Footer";
		// put it together
		trBaseRow.appendChild(thTitle);
		tblParent.appendChild(trBaseRow);
		
		trBaseRow = document.createElement("tr");
		trBaseRow.appendChild(tdContent);
		tblParent.appendChild(trBaseRow);
		alert("got here " + tblParent.style.top.toString());
		trBaseRow = document.createElement("tr");
		trBaseRow.appendChild(tdFooter);
		tblParent.appendChild(trBaseRow);
		ParentElem.appendChild(tblParent);
		
		
	} 
	catch (ex) 
	{
		alert(ex)
	}
}
