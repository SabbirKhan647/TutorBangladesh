function currentdate() {

    var currentDate = new Date();
    var day = currentDate.getDate();
    var month = currentDate.getMonth() + 1;
    var year = currentDate.getFullYear();

    var date = year + "-" + month + "-" + day;

    // document.write(date)
    //   return date;
 //   document.getElementById('HiddenField1').value = date;

    document.getElementById('CurrentDateInMasterPage').value = date;
  //  document.getElementById('lblDate').innerHTML = date;
    //                                var time=date+" "+currenttime();
    //                                document.getElementById('myHiddenFieldTime').value =time;
}