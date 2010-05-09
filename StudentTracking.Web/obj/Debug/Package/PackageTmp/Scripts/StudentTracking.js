// Apply the appropriate classes to tables etc.
$(function() {
    // Style tables
    $(".st-table th").each(function() { $(this).addClass("ui-state-default"); });
    $(".st-table td").each(function() { $(this).addClass("ui-widget-content"); });
    $(".st-table tr").hover(
				function() { $(this).children("td").addClass("ui-state-hover"); },
				function() { $(this).children("td").removeClass("ui-state-hover"); });
    
    // Make tables sortable
    $(".st-table").tablesorter();


    // Style buttons/links
    $(".st-button").each(function() {
        $(this).button();
    });
    $(".st-back-button").each(function() {
        $(this).button({ icons: { primary: 'ui-icon-triangle-1-w'} });
    });

    // Setup DatePicker
    $(".st-date").each(function() {
        $(this).datepicker({ changeMonth: true, changeYear: true, dateFormat: "dd/mm/yy", yearRange: "-60:+5" });
    });

    // Initialise the DetailsDialog modal
    $("#DetailsDialog").dialog({ autoOpen: false, title: "Details", show: "blind", position: "top" });

    // Initialise the accordion
    $('#Accordion').accordion({ collapsible: true, active: false });
});

// Show the DetailsDialog modal
function ShowDetailsDialog(){
    $('#DetailsDialog').dialog('open');
}


