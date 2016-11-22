 
var i=1;
function InsertHTML () {
    //var selected = select.selectedIndex;
    //var where = select.options[selected].value;

    var relTo = document.getElementById("relTo");

    //method 1:shift + space and type in the space
            
    var htmlToInsert = "The          " + i++ + " time";
    htmlToInsert = htmlToInsert.replace(/\s/g, "&nbsp;")
   
    //htmlToInsert = htmlToInsert.replace('&#32;', "&nbsp;")
    //var htmlToInsert = '<option value="' + i + '">' + a + '</option>';
            
            

    if (relTo.insertAdjacentHTML) {        // Internet Explorer, Opera, Google Chrome and Safari
        relTo.insertAdjacentHTML("afterEnd", htmlToInsert);
    }
    else {
        alert ("Your browser does not support the insertAdjacentHTML method!");
    }
}
 