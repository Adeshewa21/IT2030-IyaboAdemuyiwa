$(function () {
    // Clicking on hide button will hide paragraphs with class "hide_content"
    $("#hide_btn").click(function () {
        $(".hide_content").hide();
    }); 

    $("#show_btn").click(function () {
        $(".hide_content").show();
    });

    $("#red_btn").click(function () {
        $("#mainJQ").children("p").toggleClass("red important");
        $("mainJQ").find("a").css({ "color": "purple" });
    });
});