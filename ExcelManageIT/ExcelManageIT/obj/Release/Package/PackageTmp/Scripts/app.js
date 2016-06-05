var canExpandCollapse = true;
$(document).ready(function () {
    
  //  $('#menuplace').load("../pages/masterlayout.html");
  
    $.getScript("../Scripts/jquery.metisMenu.js", function () {
      /*====================================
      METIS MENU 
      ======================================*/
        $('#main-menu').metisMenu();
    });

     /*====================================
      LOAD APPROPRIATE MENU BAR
   ======================================*/
    $(window).bind("load resize", function () {
        if ($(this).width() < 768) {
            $('div.sidebar-collapse').addClass('collapse')
        } else {
            $('div.sidebar-collapse').removeClass('collapse')
        }
    });
   $("#wrapper").css("min-height",$(window).height());
   $("#page-wrapper").css("min-height",($("#wrapper").height() -  ($("#topbar").height())));

    //Theme Chooser
    $(document.body).addClass("k-content");

    // theme chooser dropdown
    $(".themeChooser").kendoDropDownList({
        dataSource: [
          { text: "Black", value: "black" },
          { text: "Blue Opal", value: "blueopal" },
          { text: "Default", value: "default" },
          { text: "Material", value: "material" },
          { text: "Metro", value: "metro" },
          { text: "Silver", value: "silver" }
        ],
        dataTextField: "text",
        dataValueField: "value",
        change: function (e) {
            var theme = (this.value() || "default").toLowerCase();

            changeTheme(theme);
        }
    });
    // loads new stylesheet
    function changeTheme(skinName, animate) {
        var doc = document,
            kendoLinks = $("link[href*='kendo.']"),
            commonLink = kendoLinks.filter("[href*='kendo.common']"),
            skinLink = kendoLinks.filter(":not([href*='kendo.common'])"),
            href = location.href,
            skinRegex = /kendo\.\w+(\.min)?\.css/i,
            extension = skinLink.attr("rel") === "stylesheet" ? ".css" : ".less",
            newSkinUrl = skinLink.attr("href").replace(skinRegex, "kendo." + skinName + "$1" + extension);

        function preloadStylesheet(file, callback) {
            var element = $("<link rel='stylesheet' href='" + file + "' \/>").appendTo("head");

            setTimeout(function () {
                callback();
                element.remove();
            }, 100);
        }

        function replaceTheme() {
            var browser = kendo.support.browser,
                oldSkinName = $(doc).data("kendoSkin"),
                newLink;

            if (browser.msie && browser.version < 10) {
                newLink = doc.createStyleSheet(newSkinUrl);
            } else {
                newLink = skinLink.eq(0).clone().attr("href", newSkinUrl);
                newLink.insertBefore(skinLink[0]);
            }

            skinLink.remove();

            $(doc.documentElement).removeClass("k-" + oldSkinName).addClass("k-" + skinName);
        }

        if (animate) {
            preloadStylesheet(url, replaceTheme);
        } else {
            replaceTheme();
        }
    };

    //Panel Bar
    $(".panelbar").kendoPanelBar({
        expandMode: "multiple",
        collapse: cancelExpandCollapse,
        expand: cancelExpandCollapse
    });
    if ($("#leftDiv").height() > $("#rightDiv").height()) {
        $("#rightDiv").height($("#leftDiv").height());
    }
    if ($("#leftDiv").height() < $("#rightDiv").height()) {
        $("#leftDiv").height($("#rightDiv").height());
    }
    if ($("#leftDiv1").height() > $("#rightDiv1").height()) {
        $("#rightDiv1").height($("#leftDiv1").height());
    }
    if ($("#leftDiv1").height() < $("#rightDiv1").height()) {
        $("#leftDiv1").height($("#rightDiv1").height());
    }
});

 function cancelExpandCollapse(e) {
     if (!canExpandCollapse) {
         e.preventDefault();
         canExpandCollapse = true;
     }
 }

