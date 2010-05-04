var __IEcreateElement = document.createElement;

document.createElement = function(tagName)
{
    var element = __IEcreateElement(tagName);
    
    var interface = new Element;
    for (method in interface) 
        element[method] = interface[method];
    
    return element;
}
