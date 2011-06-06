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
			
		var divOverlay = document.createElement("div");
		divOverlay.style.position = "absolute";
		divOverlay.style.left = "0px";
		divOverlay.style.top = "0px"
		divOverlay.style.marginLeft = "0px";
		divOverlay.style.marginRight = "0px";
		divOverlay.style.marginTop = "0px";
		divOverlay.style.marginBottom = "0px";
		
		//divOverlay.style.display = "none";
		//display:none;	left:0;	top:0; width:100%; background-color:#000000; opacity:0.7;
		divOverlay.style.width = "100%";
		divOverlay.style.height = "100%";
		divOverlay.style.backgroundColor = "#000000";
		divOverlay.style.opacity = 0.7;
		divOverlay.style.zIndex = 9150;
		var divWindow = document.createElement("div");
		var tblParent = document.createElement("table");
		tblParent.id = "tblParent";
		tblParent.name = "tblParent";
		tblParent.style.position = "absolute";
		tblParent.border = 0;
		tblParent.style.top = "100px";
		tblParent.style.left = "100px";
		tblParent.style.width = "390px";
		tblParent.style.height = "350px";
		//tblParent.style.display = "block";
		tblParent.style.zIndex = 9151; 
		tblParent.style.backgroundColor = "#c9c9c9";
		tblParent.style.border = "solid 1px #000000";
		tblParent.cellPadding="0px";
		tblParent.cellSpacing="0px";
		
		var tblHead = document.createElement("thead");
		var tblBody = document.createElement("tbody");
		var tblFooter = document.createElement("tfoot");

		var trRow;
		var tdCell;
		
		trRow = document.createElement("tr");
		tdCell = document.createElement("th");
		tdCell.id = "thTitle";
		tdCell.name = "thTitle";
		tdCell.style.height = "25px";
		//tdCell.style.paddingTop = "3px";
		//tdCell.style.paddingBottom = "3px";
		tdCell.style.backgroundColor = "#1D5451";
		tdCell.style.color = "#ffffff";
		tdCell.innerHTML = "Title";
		trRow.appendChild(tdCell);
		tblHead.appendChild(trRow);
		
		trRow = document.createElement("tr");
		tdCell = document.createElement("td");
		tdCell.id = "tdContent";
		tdCell.name = "tdContent";
		tdCell.innerHTML = "Content";
		trRow.appendChild(tdCell);
		tblBody.appendChild(trRow);
		
		trRow = document.createElement("tr");
		tdCell = document.createElement("td");
		tdCell.id = "tdFooter";
		tdCell.name = "tdFooter";
		tdCell.style.height = "25px";
		tdCell.style.paddingBottom = "5px";
		tdCell.style.paddingTop = "5px";
		tdCell.align = "center";
		tdCell.valign = "middle";
		tdCell.innerHTML = "<input type=\"button\" value=\"Close\" style=\"width:50px;\" onclick=\"javascript:document.getElementById('" + ParentElem.id + "').innerHTML = '';\" />";
		trRow.appendChild(tdCell);
		tblFooter.appendChild(trRow);
		
		tblParent.appendChild(tblHead);
		tblParent.appendChild(tblBody);
		tblParent.appendChild(tblFooter);
		
		var preConsole = document.getElementById("preConsole");
		
		ParentElem.appendChild(divOverlay);
		ParentElem.appendChild(tblParent);
		preConsole.innerHTML = tblParent.nodeValue;
		
	} 
	catch (ex) 
	{
		alert("An error occured while creating the base inline dialog window\n\n" + ex.message)
	}
}
