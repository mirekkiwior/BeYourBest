$("#urgentTasksLink, #otherTasksLink").click(function (e) {
    e.preventDefault();
    $("#wrapper").addClass("toggled");
});

$("#goalsLink, #categoriesLink").click(function (e) {
    e.preventDefault();
    $("#wrapper").removeClass("toggled");
});
