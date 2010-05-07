function ClearAllTextElements(ParentElem)
{
	var InputArray;
	if(ParentElem != null)	
	{
		InputArray = ParentElem.getElementsByTagName("input");
	}
	else
	{
		InputArray = document.getElementsByTagName("input");
	}
	for(var i = 0; i < InputArray.lenght; i++)
	{
		if(InputArray[i].type.toLower() == "text" || InputArray[i].type.toLower() == "text")
		{
			InputArray[i].value = "";
		}

	}
}