$(function () {
    $("[id$=txtFromDate]").datepicker({
        showOn: 'button',
        buttonImageOnly: true,
        buttonImage: '../Image/calendar.png'
    });   
});

$(function () {
    $("[id$=txtToDate]").datepicker({
        showOn: 'button',
        buttonImageOnly: true,
        buttonImage: '../Image/calendar.png'
    });
});

$(function () {
    $("[id$=newDate]").datepicker({
        showOn: 'button',
        setDate: new Date(),
        buttonImageOnly: true,
        buttonImage: '../Image/calendar.png'
    });
});

$(function () {
    $("input[type=text][id*=AdjustmentDate]").datepicker({
        showOn: 'button',
        buttonImageOnly: true,
        buttonImage: '../Image/calendar.png'
    });
});


$(function () {
    $("#dialog").dialog({
        autoOpen: false,
        show: {
            effect: "blind",
            duration: 1000
        },
        hide: {
            effect: "explode",
            duration: 1000
        }
    });

    $("#btnAddNewAdjustments").on("click", function () {
        $("#dialog").dialog("open");
    });
    
});


function onlyDotsAndNumbers(event) {
    var charCode = (event.which) ? event.which : event.keyCode
    if (charCode === 46) {
        return true;
    }
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

function onlyNumbers(event) {
    var charCode = (event.which) ? event.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

function noAlphabets(event) {
    var charCode = (event.which) ? event.which : event.keyCode
    if ((charCode >= 97) && (charCode <= 122) || (charCode >= 65) && (charCode <= 90))
        return false;

    return true;
}