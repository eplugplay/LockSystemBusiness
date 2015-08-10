function InformationPopUp(msg) {
    $("#popupwindow").dialog({
        autoOpen: false,
        modal: true,
        show: "fade",
        title: "Information",
        buttons: {
            OK: function () { $(this).dialog("close"); }
        }
    });
    $('#popupwindow').html(msg);
    $("#popupwindow").dialog("open");
}

function LoadMsg(msg) {
    $("#popupwindow").dialog({
        autoOpen: false,
        modal: true,
        show: "fade",
        title: "Information",
        buttons: {
            OK: function () { $(this).dialog("close"); }
        }
    });
    $('#popupwindow').html(msg);
    $("#popupwindow").dialog("open");
}

function LoadSecondaryMsg(msg) {
    $("#popupwindow2").dialog({
        autoOpen: false,
        modal: true,
        show: "fade",
        title: "Information",
        buttons: {
            OK: function () { $(this).dialog("close"); }
        }
    });
    $('#popupwindow2').html(msg);
    $("#popupwindow2").dialog("open");
}

function ShowPopUp(title, width, height) {
    var isMobile = window.matchMedia("only screen and (max-width: 850px)");

    if (isMobile.matches) {
        width = '550';
        height = '450';
        //Conditional script here
    }
    $("#item_popupwindow").dialog({
        autoOpen: false,
        modal: true,
        height: height,
        width: width,
        show: "fade",
        title: title,
        buttons: {
            //Save: function () { $(this).dialog("close"); }
        }
    });
    $("#item_popupwindow").dialog("open");
}