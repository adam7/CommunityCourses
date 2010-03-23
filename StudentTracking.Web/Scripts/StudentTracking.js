// Apply the appropriate classes to tables etc.
$(function() {
    // Style tables
    $(".st-table th").each(function() { $(this).addClass("ui-state-default"); });
    $(".st-table td").each(function() { $(this).addClass("ui-widget-content"); });
    $(".st-table tr").hover(
				function() { $(this).children("td").addClass("ui-state-hover"); },
				function() { $(this).children("td").removeClass("ui-state-hover"); });
    $(".st-table tr").click(function() { $(this).children("td").toggleClass("ui-state-highlight"); });
    // Style links

    // Style buttons
    $(".st-back-button, .st-button").each(function() 
    {
        $(this).addClass("ui-state-default");
        $(this).addClass("ui-corner-all");
        $(this).hover(
	        function() {
	            $(this).addClass("ui-state-hover");
	        },
	        function() {
	            $(this).removeClass("ui-state-hover");
	        }
        );
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


