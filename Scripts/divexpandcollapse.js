function divexpandcollapse(divname) {
    var img = "img" + divname;
    if ($("#" + img).attr("src") == "images/plus.jpeg") {
        $("#" + img)
    .closest("tr")
    .after("" + $("#" + divname)
    .html() + "")
        $("#" + img).attr("src", "images/minus.jpeg");
    } else {
        $("#" + img).closest("tr").next().remove();
        $("#" + img).attr("src", "images/plus.jpeg");
    }
}
