$(document).ready(function () {
    $('.animate').waypoint(function () {
        //retrieving 'datas'
        var domElement = this.element;
        var jqueryElement = $(domElement);
        var animation = jqueryElement.data("animate");
        var delay = jqueryElement.data("delay") != null ? jqueryElement.data("delay") : "0";
        var offset = jqueryElement.data("offset") != null ? jqueryElement.data("offset") : "88%";
        jqueryElement.delay(delay).queue(function () {
            jqueryElement.addClass(animation + " animated");
        });
    }, { offset: "80%" }
    );
});
