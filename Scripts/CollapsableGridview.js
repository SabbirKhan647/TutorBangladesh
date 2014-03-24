//--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

$("[src*=plus]").live("click", function () {
    $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
    $(this).attr("src", "../Images/minus.gif");
});
$("[src*=minus]").live("click", function () {
    $(this).attr("src", "../Images/plus.gif");
    $(this).closest("tr").next().remove();
});