$("#urgentTasksLink, #otherTasksLink").click(function (e) {
    e.preventDefault();
    $("#wrapper").addClass("toggled");
});

$("#goalsLink").click(function (e) {
    e.preventDefault();
    $.get("/Main/LoadGoals", function (data) { $("#sidebar-wrapper").html(data); });
    $("#wrapper").removeClass("toggled");
});

$("#categoriesLink").click(function (e) {
    e.preventDefault();
    $.get("/Main/LoadCategories", function (data) { $("#sidebar-wrapper").html(data); });
    $("#wrapper").removeClass("toggled");
});
