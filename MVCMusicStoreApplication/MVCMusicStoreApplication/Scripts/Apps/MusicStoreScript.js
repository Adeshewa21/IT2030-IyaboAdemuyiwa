function searchFailed() {
    $("#searchresults").html("Search failed. Please try again.");
}

$(function () {
    $(".RemoveLink").click(function () {
        alert("link clicked");
        var id = $(this).attr("data-id")
        $.post("/ShoppingCart/RemoveFromCart", { "id": id }, function (data) {

            // the function is going to  Populate element in the view with data from the controller 
            $("#update-message").text(data.Message);
            $("#cart-total").text(data.CartTotal);
            $("#cart-total").text(data.CartTotal);
            $("#item-count-" + data.DeleteId).text(data.itemCount);

            if (data.itemCount < 1)
            $("#record-" + data.DeleteId).fadeOut(); // Remove or Hide a row if count = 0


        });
    });
});

