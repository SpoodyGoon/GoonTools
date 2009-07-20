var IE = document.all?true:false;


function ShowHelpMe(elemID) {

var offsetTrail = document.getElementById(elemID.id);
    var offsetLeft = 0;
    var offsetTop = 0;
    while (offsetTrail) {
        offsetLeft += offsetTrail.offsetLeft;
        offsetTop += offsetTrail.offsetTop;
        offsetTrail = offsetTrail.offsetParent;
    }
    if (navigator.userAgent.indexOf("Mac") != -1 && 
        typeof document.body.leftMargin != "undefined") {
        offsetLeft += document.body.leftMargin;
        offsetTop += document.body.topMargin;
    }

var tmp = document.getElementById('Message');
tmp.innerHTML = elemID.alt;
var tip = document.getElementById('HelpMess');

  tip.style.position = 'absolute';
  tip.style.top = (offsetTop - 5) + 'px';
  tip.style.left = (offsetLeft - 50) + 'px';
  tip.style.visibility = 'visible';
}

function HideHelpMe(e) {
  var tip = document.getElementById('HelpMess');
  tip.style.visibility = 'hidden';
}