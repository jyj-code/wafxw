<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LogLB.ascx.cs" Inherits="UI.UCControl.LogLB" %>
<script type="text/javascript">
    var curIndex = 0;
    var timeInterval = 6000;
    var arr = new Array();
    arr[0] = "../App_Themes/Image/images/Carousel/0.jpg";
    arr[1] = "../App_Themes/Image/images/Carousel/1.jpg";
    arr[2] = "../App_Themes/Image/images/Carousel/2.jpg";
    arr[3] = "../App_Themes/Image/images/Carousel/3.jpg";
    arr[4] = "../App_Themes/Image/images/Carousel/4.jpg";
    arr[5] = "../App_Themes/Image/images/Carousel/5.jpg";
    setInterval(changeImg, timeInterval);
    function changeImg() {
        var obj = document.getElementById("obj");
        if (curIndex == arr.length - 1) {
            curIndex = 0;
        } else {
            curIndex += 1;
        }
        obj.src = arr[curIndex];
    }
</script>
<img title="爱生活,爱分享全在我爱分享网" alt="我爱分享网,分享从这里起航……"  id="obj" src="../App_Themes/Image/images/Carousel/4.jpg" border="0"  />